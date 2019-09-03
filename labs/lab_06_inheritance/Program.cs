using System;

namespace lab_06_inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog d1 = new Dog();
            d1.name = "Fido";
            Labrador lab1 = new Labrador();
            lab1.name = "MansBestFriend";
            lab1.age = 2;
        }
    }

    class Dog
    {
        public string name { get; set; }
    }

    class Labrador : Dog
    {
        public int age { get; set; }
    }


}
