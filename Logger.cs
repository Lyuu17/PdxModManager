using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdxModManager
{
    internal class Logger
    {
        public static string LogFile = "mm.log";

        public static void Log(string text)
        {
            string path = Directory.GetCurrentDirectory() +
                "/" + LogFile;

            string dt = DateTime.Now.ToString("s");
            File.AppendAllText(path, 
                "[" + dt + "] " + text + Environment.NewLine);
        }
    }
}
