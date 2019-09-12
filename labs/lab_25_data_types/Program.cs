using System;

namespace lab_25_data_types
{
    class Program
    {
        static void Main(string[] args)
        {
            //integers
            byte bMin = 0;
            byte bMax = 255;
            byte b_min_in_binary = 0b_00000000; // = 0
            byte b_max_in_binary = 0b_11111111; // = 255
            byte b_min_in_hex = 0x_00; 
            byte b_max_in_hex = 0x_ff;
            //byte b_negative_is_invalid = -1;

            //letters are also stored as numbers
            char letter_01 = 'a';
            Console.WriteLine(letter_01); // prints a 
            Console.WriteLine((int)letter_01); // prints 97

            //a string is stored as an array of characters
            string s = "Hello";
            char[] s2 = "Hello".ToCharArray();
            Console.WriteLine($"first letter has index 0 ie {s[0]} and {s2[0]}");

            //whole numbers
            //int - has length of 32 bits, but 1 bit stores the sign which is either '+' or '-' so technically only has 31 bits
            var numberOfAnyType = 27;//will be made into an int
            Console.WriteLine(int.MaxValue);
            Console.WriteLine(int.MinValue);
            //short 
            short short01 = 25; // 16 bits
            //long
            long long01 = 2345234523452345123; //64 bits

            //decimal numbers
            //float 
            float f = 1.23F; // 32 bits
            //double 
            double d = 1.23D; // 64 bits
            //decimal
            decimal de = 1.23M; // 128 bits

            //floats and doubles are not ever exact ever because convert from binary to decimal
            double total = 0;
            for (int i = 0; i < 8192; i++)
            {
                total += 0.7;
            }
            Console.WriteLine(total);

            decimal totalDecimal = 0M;
            for (int i = 0; i < 8192; i++)
            {
                totalDecimal += 0.7M;
            }
            Console.WriteLine(totalDecimal);

            uint positiveInteger = 500;
            Console.WriteLine(uint.MaxValue); // 2^32


            //operators 
            //a+b=c <- Expression
            //a, b <- Operands
            //+, -, *, / <- Operator

            //Unary (one input)
            //increment
            int x = 10;
            x++;
            ++x;
            //both add 1
            int y1 = 1000;
            int y2 = 1000;
            int z1 = y1++;//equals then increment
            int z2 = ++y2;//increment then equals
            Console.WriteLine(z1);
            Console.WriteLine(z2);

            //NOT 
            Console.WriteLine(!true);//false
            Console.WriteLine(!!true);//true

            //binary 
            //modulus
            //integer division: take care because int/int = int 
            Console.WriteLine(9/4);
            //create a fractional answer its easy
            //9/4 = 2 remainder 1 = 2 1/4 
            //integer part: easy, divide integers
            //fractional part: use modulus (remainder) operator
            Console.WriteLine(9%4);
            //proper division: one number has to be a non-integer

            //Ternary operator 
            //if(condition) ? return this if true : return this if false;
            Console.WriteLine((10 > 4) ? "high" : "low"); // prints 'high'
            Console.WriteLine((10 < 4) ? "high" : "low"); // prints 'low'


            //nullable 
            int number = 100;
            int? number2 = 1000;
            //number2 is useful if we read from database and its possible the box is blank so returns null

            //null coalesce operator
            Console.WriteLine("somevalue"??"returnthisifnull"); //prints 'somevalue'
            Console.WriteLine(null??"returnthisifnull"); // prints 'returnthisifnull'

            //default value
            int somenumber = default; // assigned 0
            int? somenumber2 = default; // null
            if (somenumber2 == null) { Console.WriteLine("its null"); } //confirming number2 is null


            //bit shift (interest only)
            //shifting a binary 1 to the right it makes it divide by 2 
            //shifting a binary 1 to the left will double it 
            Console.WriteLine(0b_1010>>1); // 5
            Console.WriteLine(0b_1010<<1); // 20


        }
    }
}
