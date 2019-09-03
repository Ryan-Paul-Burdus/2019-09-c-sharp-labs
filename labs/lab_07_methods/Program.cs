using System;

namespace lab_07_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            DoThis();//calls the dothis method
            DoThisAswell();
            Mammal m = new Mammal();
            m.GetOlder();

            //method inside another method
            void DoThis()
            {
                Console.WriteLine("doing something!");
            }

            CountNumbers(5000);
            CountNumbers(5000, 300);

            OutParameters(10, 10, out int a);
            Console.WriteLine($"out paramter was {a}");

            var tupleOutput = TupleMethod();
            Console.WriteLine($"{tupleOutput.x}, {tupleOutput.y}, {tupleOutput.z}");

        }

        static void DoThisAswell()
        {
            Console.WriteLine("doing something aswell");
        }

        static void CountNumbers(int y, int x = 100)
        {
            Console.WriteLine(x*y);
        }

        static void OutParameters(int x, int y, out int z)
        {
            z = x * y;
        }

        static (int x, string y, bool z) TupleMethod()
        {
            return (10, "hi", true);
        }
    }

    class Mammal
    {
        public int Age { get; set; }
        public void GetOlder() { Age++; }
    }
}
