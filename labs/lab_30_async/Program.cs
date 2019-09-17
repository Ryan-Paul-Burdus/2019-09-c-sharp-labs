using System;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace lab_30_async
{
    class Program
    {
        static List<string> lines = new List<string>();
        static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {
            
            s.Start();

            //for (int i = 0; i < 10; i++)
            //{
            //    File.AppendAllText("data.txt", $"\nAdding Line {i} at {DateTime.Now}");
            //}


            DoThisLongThing();
            DoThisLongThingAsync();

            Console.WriteLine(s.Elapsed);
            Console.ReadLine();

        }

        static void DoThisLongThing()
        {
            Thread.Sleep(3000);
        }

        async static void DoThisLongThingAsync()
        {
            //stream in lines using stream reader -> good for when the length of data is unkown
            using (var reader = new StreamReader("data.txt"))
            {
                while (true)
                {
                    var line = await reader.ReadLineAsync();
                    if (line == null) { break; }
                    lines.Add(line);
                }
            };

            s.Stop();
            Console.WriteLine($"Finished reading {lines.Count} lines {s.ElapsedMilliseconds} milliseconds");
        }
    }
}
