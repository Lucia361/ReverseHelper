using HarmonyLib;
using ReverseHelper.Patch.SaveData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ReverseHelper.Patch
{
    internal class ProcessStart
    {
        [HarmonyPatch(typeof(System.Diagnostics.Process), nameof(System.Diagnostics.Process.Start), new[] { typeof(string) })]
        class ProcessStartPatch
        {
            static bool Prefix(ref string fileName)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                try
                {
                    Program.Log($"Triggered Process.Start with ProcessName: {fileName}");
                    //fileName = ""; //you can also patch filename / filepath
                }
                catch (Exception ex)
                {
                    Program.Log($"Error during Patch:\n {ex}");
                }
                Console.ResetColor();
                return false;
            }
        }
        [HarmonyPatch(typeof(System.Diagnostics.Process), nameof(System.Diagnostics.Process.Start), new[] { typeof(ProcessStartInfo) })]
        class ProcessStartPatchProcess
        {
            static bool Prefix(ref ProcessStartInfo startInfo)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                try
                {
                    Program.Log($"Triggered Process.Start with ProcessStartInfo: {startInfo.FileName}");
                    Program.Log($"Arguments: {startInfo.Arguments}");
                    Program.Log($"CreateNoWindow: {startInfo.CreateNoWindow}");
                    Program.Log($"UseShellExecute: {startInfo.UseShellExecute}");
                    //fileName = ""; //you can also patch filename / filepath

                }
                catch (Exception ex)
                {
                    Program.Log($"Error during Patch:\n {ex}");
                }
                Console.ResetColor();
                return false; //this will block Process.Start
            }
        }
    }
}
