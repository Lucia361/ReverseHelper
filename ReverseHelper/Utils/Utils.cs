using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ReverseHelper
{
    internal class Utils
    {
        public static void Leave()
        {
            Program.Log("Press enter to leave...");
            Console.ReadLine();
            Process.GetCurrentProcess().Kill();
        }

        private static Random Random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "qwertyuioplkjhgfdsazxcvbnmABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}
