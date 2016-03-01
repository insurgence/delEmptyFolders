using System;
using System.IO;
using System.Diagnostics;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delEmptyFolders
{
    public static class Program
    {
        public static uint count = 0;
        public static List<string> list = new List<string>();
        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();

            // my code

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);
        }
    }
}
