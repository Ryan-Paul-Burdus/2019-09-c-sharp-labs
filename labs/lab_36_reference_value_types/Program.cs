using System;
using System.Collections.Generic;

namespace lab_36_reference_value_types
{
    class Program
    {
        static void Main(string[] args)
        {
            //primitive type : int, bool, struct, char, struct, etc
            //stored in fast stack memory
            // values stored with decleration in live, fast code
            // destroyed immediately aswell
            // == Value types as value stored in stack memory with decleration 
            // var x = 10; x and 10 stored in stack 
            //copy of value type is independant 
            decimal x = 10;
            decimal y = x;
            x = 1000;
            y = 3333;
            Console.WriteLine($"x is {x} and y is {y} \n");

            //pass x and y into a method
            DoThis(x, y);
            Console.WriteLine($"local x is {x} and y is {y} \n");

            //pass x and y by reference into DoThisPermanantly(x, y);
            DoThisPermanently(ref x, ref y);
            Console.WriteLine($"now local x is {x} and y is {y} \n");

            //reference types 
            //value types are primitive eg int, held on fast stack
            //reference types are large objects
            //shortcut(pointer) held on faast stack 
            //actual object held on slower heap (larger memory)
            //stack 
            //  int x=10
            //  list<string> mylist --> {"one", "two"}

            //copy reference type : by default you only copy the pointer
            var myArray = new int[] { 100, 200, 300 };
            var myArray2 = myArray; //copy pointer only!!! not a new object in heap memory

            Console.WriteLine(string.Join(",", myArray));
            Console.WriteLine(string.Join(",", myArray2));
            myArray[2] = 5000;
            myArray2[1] = 14000;
            Console.WriteLine(string.Join(",", myArray));
            Console.WriteLine(string.Join(",", myArray2));

            //reference types are naturally treated as global when passed into a method
            var myList = new List<string>() { "first", "second" };
            DoThisToMyList(myList);
            Console.WriteLine(string.Join(", ", myList));
        }

        static void DoThisToMyList(List<string> list)
        {
            list.Add("Three");
            list.Add("four");
        }

        //method to change x and y: x will got to x squared and y will go to y cubed
        static void DoThis(decimal x, decimal y)
        {
            x = (x * x);
            y = (y * y * y);
            Console.WriteLine($"private x is {x} and y is {y}");
        }

        static void DoThisPermanently(ref decimal x, ref decimal y)
        {
            x = (x * x);
            y = (y * y * y);
            Console.WriteLine($"ref x is {x} and y is {y}");
        }
    }
}
