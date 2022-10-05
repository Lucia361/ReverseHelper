using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseHelper.Patch
{
    internal class ProcessKill
    {
        //[HarmonyPatch(typeof(System.Diagnostics.Process), nameof(System.Diagnostics.Process.Kill), MethodType.Normal)] //it has some bugs, I'll try to fix :)
        class ProcessKillPatch
        {
            static bool Prefix()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                try
                {
                    Program.Log("Triggered Process.Kill");
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
