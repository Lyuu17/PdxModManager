using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PdxModManager
{
    internal partial class PdxMMHelper
    {
        public partial class ModConfig
        {
            private static string modConfig;

            public static void LoadConfig()
            {
                modConfig = File.ReadAllText(Directory.GetCurrentDirectory() +
                    "/mods.json");
            }

            public static dynamic? GetModConfigValue(long fileId, string key)
            {
                return GetModConfigValue(fileId, key, null);
            }

            public static dynamic? GetModConfigValue(long fileId, string key, dynamic? def)
            {
                try
                {
                    var result = JsonConvert.DeserializeObject<Dictionary<long, Dictionary<string, dynamic>>>(modConfig);
                    var mod = result[fileId];
                    var value = mod[key];
                    return value;
                }
                catch (Exception ex)
                {
                    return def;
                }
            }

            public static void SetModConfigValue(long fileId, string key, dynamic value)
            {
                Dictionary<long, Dictionary<string, dynamic>>? dict =
                    JsonConvert.DeserializeObject<Dictionary<long, Dictionary<string, dynamic>>>(modConfig);
                if (!dict.ContainsKey(fileId))
                {
                    dict[fileId] = new Dictionary<string, dynamic>();
                }

                dict[fileId][key] = value;

                modConfig = JsonConvert.SerializeObject(dict);

                File.WriteAllText(Directory.GetCurrentDirectory() +
                    "/mods.json", modConfig);
            }
        }
    }
}
