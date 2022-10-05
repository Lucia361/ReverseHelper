using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ReverseHelper.Patch;
using ReverseHelper.Patch.SaveData;

namespace ReverseHelper
{
    internal class Program
    {
        private static string File = null;
        public static string NewUrl = "https://github.com/CabboShiba"; //change ur custom url
        static void Main(string[] args)
        {
            Save.Init();
            Console.Title = ".NET ReverseEngineering Helper by Cabbo - https://github.com/CabboShiba";
            Log("ReverseHelper started!");
            try
            {
                File = args[0];
            }
            catch (Exception ex)
            {
                Log("Please use Drag&Drop.");
                Utils.Leave();
            }
            try
            {
                object[] parameters = null;
                var assembly = Assembly.LoadFile(Path.GetFullPath(File));
                var paraminfo = assembly.EntryPoint.GetParameters();
                parameters = new object[paraminfo.Length];
                Harmony patch = new Harmony("DotNetReverseHelper_https://github.com/CabboShiba");
                patch.PatchAll(Assembly.GetExecutingAssembly());
                assembly.EntryPoint.Invoke(null, parameters);
            }
            catch (Exception ex)
            {
                Log($"Could not load {File}\n{ex}");
            }
            Console.ReadLine();
        }
        public static void Log(string Data)
        {
            string Log = $"[{DateTime.Now} - RE ] {Data}";
            Console.WriteLine(Log);
        }
    }
}
