using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseHelper.Patch
{
    internal class ClearConsole
    {
        [HarmonyPatch(typeof(System.Console), nameof(System.Console.Clear), MethodType.Normal)]
        class CLSPath
        {
            static bool Prefix()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                try
                {
                    Program.Log($"Triggered Console.Clear");
                }
                catch (Exception ex)
                {
                    Program.Log($"Error during Patch:\n {ex}");
                }
                Console.ResetColor();
                return false; // false = do not clear console   ----- true =  clear console
            }
        }
    }
}
