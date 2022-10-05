using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReverseHelper.Patch.SaveData;

namespace ReverseHelper.Patch
{
    internal class ExtractStrings
    {
        [HarmonyPatch(typeof(System.Text.Encoding), nameof(System.Text.Encoding.Default.GetBytes), new[] { typeof(string) })]
        class GetStrings
        {
            static bool Prefix(ref string s)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                try
                {
                    Program.Log($"Triggered Encoding.Default.GetBytes: {s}");
                    Save.Strings(s);
                }
                catch (Exception ex)
                {
                    Program.Log($"Error during Patch:\n {ex}");
                }
                Console.ResetColor();
                return true;
            }
        }
    }
}
