using HarmonyLib;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ReverseHelper.Patch
{
    internal class HWIDSpoof
    {
        private static bool SpoofHWID = true;
        [HarmonyPatch(typeof(System.Security.Principal.SecurityIdentifier), nameof(System.Security.Principal.SecurityIdentifier.Value), MethodType.Getter)]
        class Spoof
        {
            static bool Prefix(ref string __result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                try
                {
                    Program.Log("Triggered SecurityIdentifier.Value [HardWare-ID].");
                    if(SpoofHWID == true)
                    {
                        Program.Log("Spoofing HardWare-ID...");
                        string HWIDSpoofed = Utils.RandomString(45);
                        __result = HWIDSpoofed;
                        Program.Log($"Succesfully spoofed HardWare-ID [{__result}]");
                        Console.ResetColor();
                        return false;
                    }
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
