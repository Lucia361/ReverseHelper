using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseHelper.Patch
{
    internal class FileDelete
    {
        [HarmonyPatch(typeof(System.IO.File), nameof(System.IO.File.Delete), new[] { typeof(string) })]
        class FileDeletePatch
        {
            static bool Prefix(ref string path)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                try
                {
                    Program.Log($"Triggered File.Delete with FilePath: {path}");
                    //path = ""; use custom path if you want
                }
                catch (Exception ex)
                {
                    Program.Log($"Error during Patch:\n {ex}");
                }
                Console.ResetColor();
                return true; //leave true
            }
        }
    }
}
