using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ReverseHelper.Patch
{
    internal class ThreadSleep
    {
       // [HarmonyPatch(typeof(System.Threading.Thread), nameof(System.Threading.Thread.Sleep), new[] {typeof(int)})]
        class ThreadSleepPatch
        {
            static bool Prefix(ref int millisecondsTimeout)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                try
                {
                    Program.Log($"Triggered Thread.Sleep with MS: {millisecondsTimeout}");
                    //millisecondsTimeout = 1000; //edit your value and return true;
                }
                catch (Exception ex)
                {
                    Program.Log($"Error during Patch:\n {ex}");
                }
                Console.ResetColor();
                return false; // false = 0 ms     --- true = custom ms
            }
        }
    }
}
