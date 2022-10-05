using HarmonyLib;
using ReverseHelper.Patch.SaveData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseHelper.Patch
{
    internal class StringEquals
    {
       // [HarmonyPatch(typeof(string), nameof(string.Equals), new[] { typeof(string), typeof(string) })]
        class StringEqualsPatch
        {
            static bool Prefix(ref string a, ref string b)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                try
                {
                    Console.WriteLine($"Triggered String.Equals:");
                    Console.WriteLine($"First string: {a}\nSecond string: {b}");
                    Save.Log($"String.Equals: {a} - {b}");
                    // a = "";
                    //b = "";  //you can modify also the strings
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
