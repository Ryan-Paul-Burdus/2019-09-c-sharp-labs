using System;

namespace lab_32_events
{
    class Program
    {
        public delegate void myDelegate();

        public static event myDelegate MyEvent;

        static void Main(string[] args)
        {
            MyEvent += MethodA; //pointer to a method but dont call the method right now (callback)
            MyEvent += MethodB;
            MyEvent += MethodC;
            MyEvent();
        }

        static void MethodA() { Console.WriteLine("Method A"); }

        static void MethodB() { Console.WriteLine("Method B"); }

        static void MethodC() { Console.WriteLine("Method C"); }
    }
}
