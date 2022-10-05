using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseHelper.Patch
{
    internal class URLPatch
    {
        [HarmonyPatch(typeof(System.Net.WebRequest), nameof(System.Net.WebRequest.Create), new[] { typeof(Uri), typeof(bool) })]
        class URLRequestPatch
        {
            static bool Prefix(ref Uri requestUri, ref bool useUriBase)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                try
                {
                    Program.Log("Triggered WebRequest.Create with URL: " + requestUri.ToString());
                    Program.Log("Fixing...");
                    System.Uri Uri = new System.Uri(Program.NewUrl);
                    //requestUri = Uri;
                    Program.Log("Fixed URL: " + requestUri);
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
