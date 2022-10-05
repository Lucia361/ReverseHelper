using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseHelper.Patch
{
    internal class RequestStringBuilder
    {
        [HarmonyPatch(typeof(System.IO.StreamReader), nameof(System.IO.StreamReader.ReadToEnd), MethodType.Normal)] //used to download strings from webclient
        class StringBuilder
        {
            static bool Prefix(ref string __result)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                try
                {
                    Program.Log("Triggered StreamReader.ReadToEnd.");
                    //__result = ""; here you can choose your custom response
                }
                catch (Exception ex)
                {
                    Program.Log($"Error during Patch:\n {ex}");
                }
                Console.ResetColor();
                return false;
            }
        }
    }
}
