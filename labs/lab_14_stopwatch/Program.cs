using System;
using System.Diagnostics;
using System.Linq;

namespace lab_14_stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Stopwatch();
            s.Start();

            var counter = 0;
            for (int i = 0; i < 100_000_000; i++)
            {
                counter++;
            }

            s.Stop();
            Console.WriteLine(s.Elapsed);
            Console.WriteLine(s.ElapsedMilliseconds);
            Console.WriteLine(s.ElapsedTicks);
        }
    }
}
