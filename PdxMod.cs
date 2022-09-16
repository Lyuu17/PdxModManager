using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdxModManager
{
    internal class PdxMod
    {
        public string name { get; set; }
        public string path { get; set; }
        public string picture { get; set; }
        public string version { get; set; }
        public string supportedGameVersion { get; set; }
        public long fileId { get; set; }

        public string publishedDate { get; set; }
        public string updatedDate { get; set; }
        public string size { get; set; }

        public PdxMod(string name, string path, string picture, string version, string supportedGameVersion, long fileId)
        {
            this.name = name;
            this.path = path;
            this.picture = picture;
            this.version = version;
            this.supportedGameVersion = supportedGameVersion;
            this.fileId = fileId;
        }

        public PdxMod(SteamWorkshop.FileDetails details)
        {
            this.name = details.name;
            this.fileId = details.fileId;
            this.publishedDate = details.publishedDate;
            this.updatedDate = details.updatedDate;
            this.size = details.size;
        }

        public PdxMod(string filePath)
        {
            PdxModDescriptor descriptor = new PdxModDescriptor(filePath);

            this.name = descriptor.getValue("name");
            this.path = descriptor.getValue("path");
            this.picture = descriptor.getValue("picture");
            this.version = descriptor.getValue("version");
            this.supportedGameVersion = descriptor.getValue("supported_version");
            this.fileId = Int64.Parse(descriptor.getValue("remote_file_id"));
        }
    }
}
