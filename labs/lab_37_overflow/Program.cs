using System;

namespace lab_37_overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            short s = 12345;
            int i = 1234567890;
            long l = 1234567890123456789;
            float f = 123456789012345678901234567890123456789.12345678901234567890f;
            double db = 12345678901234567890123456789012345678901234567890.12345678901234567890;
            decimal dc = 12345678901234567890123456789.12345678901234567890M;
            Console.WriteLine(f);
            Console.WriteLine(db);
            Console.WriteLine(dc);

            //default is unchecked because CPU intensive
            unchecked
            {
                //integer maximums 
                int bigInt = int.MaxValue;
                Console.WriteLine(bigInt);
                bigInt += 11;
                Console.WriteLine(bigInt);
                //if max is 4 -> 0,1,2,3, -4,-3,-2,-1,0,1,2,3, -4,...
            }
           

            DoThis();
        }
        static decimal counter = 0;

        static void DoThis()
        {
            counter++;
            Console.WriteLine(counter);
            DoThis();
        }
    }
}
