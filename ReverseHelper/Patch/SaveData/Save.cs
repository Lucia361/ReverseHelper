using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReverseHelper.Patch.SaveData
{
    internal class Save
    {
        private static string LogPath = Environment.CurrentDirectory + @"\HelperLog.txt";
        private static string ExtractedStrings = Environment.CurrentDirectory + @"\Strings.txt";
        public static bool Init()
        {
            try
            {
                if (!File.Exists(LogPath))
                {
                    File.Create(LogPath);
                }
                if (!File.Exists(ExtractedStrings))
                {
                    File.Create(ExtractedStrings);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public static bool Log(string Data)
        {
            try
            {
                File.AppendAllText(LogPath, $"{Data}\n");
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public static bool Strings(string Data)
        {
            try
            {
                File.AppendAllText(ExtractedStrings, $"{Data}\n");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
