using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PdxModManager
{
    internal class PdxModDescriptor
    {
        private string filePath;
        private string[] descriptorContent;

        public PdxModDescriptor(string filePath)
        {
            ArrayList lines = new ArrayList();
            using (StreamReader fileReader = File.OpenText(filePath))
            {
                string line = "";
                while ((line = fileReader.ReadLine()) != null)
                {
                    lines.Add(line);
                }

                fileReader.Close();
            }

            this.filePath = filePath;
            this.descriptorContent = (string[])lines.ToArray(typeof(string));
        }

        public PdxModDescriptor(string[] content)
        {
            this.descriptorContent = content;
        }

        public string? getValue(string key)
        {
            foreach(string line in descriptorContent)
            {
                string[] parts = line.Split("=");

                if (parts.Length != 2) continue;
                if (parts[0] != key) continue;
                
                return parts[1].Replace("\"", "");
            }

            return null;
        }

        public void setValue(string key, string value)
        {
            string format = key + "=\"" + value + "\"";
            for (int i = 0; i < descriptorContent.Length; i++)
            {
                string line = descriptorContent[i];
                string[] parts = line.Split("=");

                if (parts.Length != 2) continue;
                if (parts[0] != key) continue;
                
                descriptorContent[i] = format;

                return;
            }

            var content = descriptorContent.ToList();
            content.Add(format);

            descriptorContent = content.ToArray();

            return;
        }

        public void saveDescriptorContent()
        {
            File.WriteAllLines(filePath, descriptorContent);
        }
    }
}
