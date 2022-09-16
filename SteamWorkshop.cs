using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using AngleSharp;
using AngleSharp.Css;
using Newtonsoft.Json;
using static PdxModManager.ZipFileExtensions;

namespace PdxModManager
{
    internal class SteamWorkshop
    {
        public class FileDetails
        {
            public string name { get; set; }
            public string description { get; set; }
            public string size { get; set; }
            public string publishedDate { get; set; }
            public string updatedDate { get; set; }
            public long fileId { get; set; }
        }

        public static async Task<FileDetails> GetFileDetailsAsync(long fileId)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync("https://www.steamcommunity.com/sharedfiles/filedetails/?id=" + fileId);

            var title = document.QuerySelector("div.workshopItemTitle").TextContent;
            var description = document.QuerySelector("div.workshopItemDescription").TextContent;
            var rightData = document.QuerySelectorAll("div.detailsStatRight");

            FileDetails fileDetails = new FileDetails();
            fileDetails.name = title;
            fileDetails.description = description;
            fileDetails.size = rightData[0].TextContent;
            fileDetails.publishedDate = rightData[1].TextContent;
            if (rightData.Length > 2) fileDetails.updatedDate = rightData[2].TextContent;
            else fileDetails.updatedDate = "";
            fileDetails.fileId = fileId;

            return fileDetails;
        }

        public class Downloader
        {
            private const string API_ENDPOINT = "https://node04.steamworkshopdownloader.io/prod/api/";

            public static async Task<bool> RequestFile(long fileId, string filePath, IProgress<float> progress = null)
            {
                var client = new HttpClient();

                var requestData = new
                {
                    publishedFileId = fileId,
                    collectionId = (string)null,
                    hidden = false,
                    downloadFormat = "raw",
                    autodownload = true
                };

                var response = await client.PostAsync(API_ENDPOINT + "download/request", JsonContent.Create(requestData));

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Logger.Log("[SteamWorkshop.cs|Downloader.RequestFile] Failed loading page " + API_ENDPOINT + ", status code " + response.StatusCode);

                    return false;
                }

                var requestContent = await response.Content.ReadAsStringAsync();
                var requestResponse = JsonConvert.DeserializeObject<dynamic>(requestContent);

                string uuid = requestResponse["uuid"];

                for (int i = 0; i < 10; i++)
                {
                    response = await client.PostAsync(API_ENDPOINT + "download/status", 
                        new StringContent("{\"uuids\":[\"" + uuid + "\"]}", Encoding.UTF8, "application/json"));

                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        Logger.Log("[SteamWorkshop.cs|Downloader.RequestFile] Failed loading page " + API_ENDPOINT + ", status code " + response.StatusCode);

                        return false;
                    }

                    var statusContent = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine(statusContent);

                    var statusResponse = JsonConvert.DeserializeObject<dynamic>(statusContent);

                    if (statusResponse[uuid]["status"] == "prepared")
                    {
                        string storageNode = statusResponse[uuid]["storageNode"];
                        string storagePath = statusResponse[uuid]["storagePath"];

                        return await Download(fileId, uuid, storageNode, storagePath, filePath, progress);
                    }

                    await Task.Delay(2000);
                }

                return false;
            }

            public static async Task<bool> Download(long fileId, string uuid, string storageNode, string storagePath, string filePath, IProgress<float> progress = null)
            {
                Logger.Log("[SteamWorkshop.cs|Downloader.Download] Downloading fileId:" + fileId + ", uuid:" + uuid + ", storageNode:" + storageNode + ", filePath:" + filePath);

                string url = "http://" + storageNode + "/prod/storage/" + storagePath + "?uuid=" + uuid;

                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(5);

                using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
                    await client.DownloadAsync(url, fs, progress);

                return true;
            }
        }

        public class Utils
        {
            public static async Task Extract(long fileId, string zipPath, IProgress<float> progress = null)
            {
                string folderPath = Path.GetFullPath(Path.GetDirectoryName(zipPath)) + "/" + fileId + "/";
                if (Directory.Exists(folderPath))
                    Directory.Delete(folderPath, true);

                Progress<ZipProgress> _progress = new Progress<ZipProgress>();

                _progress.ProgressChanged += (object sender, ZipProgress zipProgress) =>
                {
                    progress?.Report(zipProgress.Processed / zipProgress.Total * 100);
                };

                Logger.Log("[SteamWorkshop.cs|Utils.Extract] Extracting fileId:" + fileId + " into " + folderPath);
                using (FileStream zipStream = new FileStream(zipPath, FileMode.Open))
                {
                    using (ZipArchive zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Read))
                    {
                        await Task.Run(() => ZipFileExtensions.ExtractToDirectory(zipArchive, folderPath, _progress));
                    }
                }

                Logger.Log("[SteamWorkshop.cs:Extract] Deleting zip " + zipPath);
                File.Delete(zipPath);

                string modFilePath = PdxMMHelper.GetDocumentsGamePath() + "/mod/" + fileId + ".mod";
                Logger.Log("[SteamWorkshop.cs:Extract] Copying mod descriptor to " + modFilePath);

                File.Copy(folderPath + "descriptor.mod", modFilePath, true);
            }

            public static async Task SetupDescriptor(long fileId)
            {
                Logger.Log("[SteamWorkshop.cs|Utils.SetupDescriptor] Setting up descriptor for fileId:" + fileId);

                string folderPath = PdxMMHelper.GetDocumentsGamePath() + "/mod/" + fileId + "/";
                string descriptorPath = PdxMMHelper.GetDocumentsGamePath() + "/mod/" + fileId + ".mod";
                
                PdxModDescriptor descriptor = new PdxModDescriptor(descriptorPath);
                descriptor.setValue("path", folderPath.Replace("\\", "/"));
                descriptor.setValue("remote_file_id", fileId.ToString());
                descriptor.saveDescriptorContent();
            }

            public static async Task Delete(long fileId)
            {
                Logger.Log("[SteamWorkshop.cs|Utils.Delete] Deleting mod with fileId:" + fileId + " if exists");

                string folderPath = PdxMMHelper.GetDocumentsGamePath() + "/mod/" + fileId + "/";
                string descriptorPath = PdxMMHelper.GetDocumentsGamePath() + "/mod/" + fileId + ".mod";
                if (!Directory.Exists(folderPath))
                    return;

                Directory.Delete(folderPath, true);
                File.Delete(descriptorPath);
            }
        }
    }
}
