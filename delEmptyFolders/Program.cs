using System;
using System.IO;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Security.Principal;

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

            processDirectory(@"F:\");
            Console.WriteLine(count);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);

            File.WriteAllLines(@"C:\empty.txt", list);
            Console.WriteLine("end of task...");
            Console.ReadLine();
        }

        private static void processDirectory(string startLocation)
        {
            foreach(var directory in Directory.GetDirectories(startLocation))
            {
                try
                {
                    System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(directory);
                    processDirectory(directory);
                    if (Directory.GetFiles(directory).Length == 0 &&
                        Directory.GetDirectories(directory).Length == 0)
                    {
                        // Directory.Delete(directory, false);
                        list.Add(directory);
                        ++count;
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
            }
        }
    }
}
