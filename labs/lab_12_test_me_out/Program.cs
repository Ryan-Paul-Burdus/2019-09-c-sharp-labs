using System;

namespace lab_12_test_me_out
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TestMeSomething.RunThisNow(10));
        }
    }

    public class TestMeSomething
    {
        public static int RunThisNow(int input)
        {
            return input * input;
        }
    }
}
