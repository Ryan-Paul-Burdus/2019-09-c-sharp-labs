using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_02_class
{
    class Program
    {
        static void Main(string[] args)
        {
            var dog1 = new Dog();//creates a new instance of a dog object
            dog1.name = "fido";
            dog1.age = 1;
            dog1.height = 400;

            //dog growing with different ways of printing information
            dog1.Grow();
            Console.WriteLine("Age is: " + dog1.age + " and the height is: " + dog1.height);
            dog1.Grow();
            Console.WriteLine($"Age is: {dog1.age}, and the height is: {dog1.height}");
        }
    }

    //these are instructions for making a Dog object
    class Dog
    {
        public string name;
        public int age;
        public int height;

        public void Grow()
        {
            this.age++;//ages the dog by 1
            this.height += 10;//makes the dog grow by 10;
        }
    }


}
