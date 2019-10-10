using System;
using System.Reflection;

namespace lab_44_assemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            // use int type as example
            var myType = typeof(int);
            //lets find dll where int lives in windows
            // ie assembly 
            var myAssembly = Assembly.GetAssembly(myType);
            Console.WriteLine($"Assembly is called {myAssembly.GetName()}\n\n");
            //check out all other types in the same assembly and print them out
            foreach(var type in myAssembly.GetTypes())
            {
                Console.WriteLine(type);
            }
        }
    }
}
