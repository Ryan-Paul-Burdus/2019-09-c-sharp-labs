using System;
using System.Collections.Generic;
using System.Collections;

namespace lab_39_environment_variables
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = Environment.GetEnvironmentVariables();
            foreach(DictionaryEntry item in collection)
            {
                Console.WriteLine($"{item.Key}{item.Value}");
            }

            //query one 
            Console.WriteLine(Environment.GetEnvironmentVariable("WinDir"));

            //set one
            Environment.SetEnvironmentVariable("SecretPassword", "123");
            Console.WriteLine(Environment.GetEnvironmentVariable("SecretPassword"));
        }
    }
}
