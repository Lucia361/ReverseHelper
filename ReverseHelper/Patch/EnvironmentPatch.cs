using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseHelper.Patch
{
    internal class EnvironmentPatch
    {
        [HarmonyPatch(typeof(System.Environment), nameof(System.Environment.Exit), new[] { typeof(int) })]
        class FixEnvironmentExit
        {
            static bool Prefix(int exitCode)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Program.Log($"Triggered Environment.Exit with code: {exitCode}");
                Console.ResetColor();
                return false;
            }
        }
    }
}
