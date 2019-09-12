using System;
using System.IO;
using System.Linq;

namespace lab_13_files
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("myFile.txt"))
            {
                var string1 = File.ReadAllText("myFile.txt");
                Console.WriteLine(string1);
            }
            File.WriteAllText("output.txt", "Some data to be saved");

            Console.WriteLine("\n=== Save multiple lines ===\n");

            File.WriteAllText("multiplelines.txt", "some\ndata\non\ndifferent\nlines");
            Console.WriteLine(File.ReadAllText("multiplelines.txt"));

            File.WriteAllText("multiplelines.txt", "some" + Environment.NewLine + "text"
                + Environment.NewLine);

            Console.WriteLine("\n=== Saving Arrays to multiple lines ===\n");

            string[] myArray = new string[] { "some", "data", "in", "multiple", "lines" };
            File.WriteAllLines("multipleLineFile.txt", myArray);

            var outputArray = File.ReadAllLines("multipleLineFile.txt");
            Array.ForEach(outputArray, item => Console.WriteLine(item));

            Console.WriteLine("\n=== Logging ===\n");
            for (int i = 0; i < 10; i++)
            {
                File.AppendAllText("myLogFile.log", $"Event happened at time {DateTime.Now}\n");
                System.Threading.Thread.Sleep(300);
            }
            Console.WriteLine(File.ReadAllText("myLogFile.log"));
        }
    }
}
