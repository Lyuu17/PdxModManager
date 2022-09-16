using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdxModManager
{
    enum PdxGames
    {
        NONE,

        EU_IV_STEAM,
        EU_IV_EGS,
        HOI_IV_STEAM
    }

    internal partial class PdxMMHelper
    {
        /** paths **/
        public static string DOCS_PATH_EUIV_STEAM = "Paradox Interactive\\Europa Universalis IV\\";
        public static string DOCS_PATH_EUIV_EGS = "Paradox Interactive\\Europa Universalis IV EGS\\";
        public static string DOCS_PATH_HOIIV_STEAM = "Paradox Interactive\\Hearts of Iron IV\\";

        public static int MAX_MODS = 128;

        public static PdxGames PdxGame = PdxGames.NONE;

        public static readonly BindingList<PdxMod> ModList = new BindingList<PdxMod>();

        public static string GetDocumentsGamePath()
        {
            string path = "";
            switch (PdxGame)
            {
                case PdxGames.EU_IV_STEAM: path = DOCS_PATH_EUIV_STEAM; break;
                case PdxGames.EU_IV_EGS: path = DOCS_PATH_EUIV_EGS; break;
                case PdxGames.HOI_IV_STEAM: path = DOCS_PATH_HOIIV_STEAM; break;
            }

            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/" + path;
        }

        public static PdxMod GetModFromFileId(long fileId)
        {
            foreach(PdxMod mod in ModList)
            {
                if (mod.fileId != fileId) continue;

                return mod;
            }

            return null;
        }

        public static void ImportModsFromModDirectory()
        {
            ModList.Clear();

            foreach (string filePath in Directory.GetFiles(GetDocumentsGamePath() + "/mod/"))
            {
                string filename = Path.GetFileName(filePath);

                if (!filename.ToLower().EndsWith(".mod")) continue;

                PdxMod mod = new PdxMod(filePath);
                if (mod == null) continue;

                mod.size = ModConfig.GetModConfigValue(mod.fileId, "size", "");
                mod.publishedDate = ModConfig.GetModConfigValue(mod.fileId, "published_date", "");
                mod.updatedDate = ModConfig.GetModConfigValue(mod.fileId, "updated_date", "");

                Logger.Log("[PdxMMHelper.cs|ImportModsFromModDirectory] Importing mod " + mod.name);

                ModList.Add(mod);
            }
        }

        public static async Task RequestUpdateAllModsAsync(ProgressBar? progressBar = null, bool force = false)
        {
            foreach (PdxMod mod in ModList)
            {
                SteamWorkshop.FileDetails fileDetails = await SteamWorkshop.GetFileDetailsAsync(mod.fileId);

                string detailsDate = fileDetails.updatedDate == "" ? fileDetails.publishedDate : fileDetails.updatedDate;
                string modDate = mod.updatedDate == "" ? mod.publishedDate : mod.updatedDate;
                if (modDate == detailsDate && !force)
                {
                    mod.size = fileDetails.size;
                    mod.publishedDate = fileDetails.publishedDate;
                    mod.updatedDate = fileDetails.updatedDate;

                    ModConfig.SetModConfigValue(mod.fileId, "size", mod.size);
                    ModConfig.SetModConfigValue(mod.fileId, "published_date", mod.publishedDate);
                    ModConfig.SetModConfigValue(mod.fileId, "updated_date", mod.updatedDate);

                    Logger.Log("[PdxMMHelper.cs|RequestUpdateAllModsAsync] Mod " + mod.name + " doesn't require any update");

                    continue;
                }

                await UpdateModAsync(mod, progressBar);
            }
        }

        public static async Task<bool> UpdateModAsync(PdxMod mod, ProgressBar? progressBar = null)
        {
            Logger.Log("[PdxMMHelper.cs|UpdateModAsync] Downloading mod " + mod.fileId); 

            string zipPath = PdxMMHelper.GetDocumentsGamePath() + "/mod/" + mod.fileId + ".zip";
            string folderPath = Path.GetFullPath(Path.GetDirectoryName(zipPath)) + "/" + mod.fileId + "/";

            var queueMod = Queue.AddToQueue(mod.fileId, mod).Result;
            var progress = new Progress<float>(value => { 
                if (queueMod != null) queueMod.progress = value + " %"; 
            });

            if (!await SteamWorkshop.Downloader.RequestFile(mod.fileId, zipPath, progress))
            {
                Logger.Log("[PdxMMHelper.cs|UpdateModAsync] Failed to update mod " + mod.name);

                queueMod.statusCode = Queue.QueueStatus.ERROR;

                return false;
            }

            Logger.Log("[PdxMMHelper.cs|UpdateModAsync] Extracting mod " + mod.name);

            await SteamWorkshop.Utils.Extract(mod.fileId, zipPath, progress);
            await SteamWorkshop.Utils.SetupDescriptor(mod.fileId);

            if (progressBar != null) 
                progressBar.Value = 0;

            Queue.ModQueue.Remove(queueMod);

            Logger.Log("[PdxMMHelper.cs|UpdateModAsync] Done with updating mod " + mod.name);

            return true;
        }

        public class Queue
        {
            public class QueueMod
            {
                public string? name { get; set; }
                public string progress { get; set; }
                public string? eta { get; set; }
                public long fileId { get; set; }
                public PdxMod? mod { get; set; }
                public string status
                {
                    get
                    {
                        switch(statusCode)
                        {
                            case QueueStatus.OK: return "OK";
                            case QueueStatus.ERROR: return "ERROR";
                            default: return "";
                        }
                    }
                }
                public QueueStatus statusCode { get; set; }
            }

            public enum QueueStatus
            {
                OK = 0,
                ERROR = 1
            }

            public static readonly BindingList<QueueMod> ModQueue = new BindingList<QueueMod>();

            public static async Task<QueueMod> AddToQueue(long fileId, PdxMod? mod = null)
            {
                if (mod == null)
                    mod = new PdxMod(await SteamWorkshop.GetFileDetailsAsync(fileId));

                QueueMod queueMod = new QueueMod();
                queueMod.name = mod.name;
                queueMod.progress = "0 %";
                queueMod.eta = "";
                queueMod.fileId = fileId;
                queueMod.mod = mod;

                ModQueue.Add(queueMod);

                return queueMod;
            }
        }
    }
}
