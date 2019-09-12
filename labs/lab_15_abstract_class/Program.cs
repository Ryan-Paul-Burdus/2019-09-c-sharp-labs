using System;

namespace lab_15_abstract_class
{
    class Program
    {
        static void Main(string[] args)
        {
            //var h = new Holiday();

            var h = new HolidayWithTravel();

            string x = "Hello";
            Console.WriteLine(x);
            x = x.AmazingExtraString();
            Console.WriteLine(x);
        }
    }

    abstract public class Holiday
    {
        public abstract void Travel();

        public void Places()
        {
            Console.WriteLine("Visiting places");
        }

        public void Acitivities()
        {
            Console.WriteLine("Stuff to  do");
        }
    }

    public class HolidayWithTravel : Holiday
    {
        public override void Travel()
        {
            Console.WriteLine("Travelling by car");
        }
    }

    public static class AddingToStrings
    {
        public static string AmazingExtraString(this string s)
        {
            Console.WriteLine("=== Changing your string ===");
            s += " World";
            return s;
        }
    }
}
