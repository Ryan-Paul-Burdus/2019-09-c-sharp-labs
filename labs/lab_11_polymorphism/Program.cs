using System;

namespace lab_11_polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal1 = new Animal();
            Dog dog1 = new Dog();
            
            for (int i = 1; i <= 10; i++)
            {
                animal1.increaseAge();
                dog1.increaseAge();
                Console.WriteLine("Dogs age is: " + animal1.age + ", age in dog years is: " + dog1.age);
            }
        }
    }

    class Animal
    {
        public string name { set; get; }
        public int age { set; get; }

        public Animal(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public virtual void increaseAge()
        {
            this.age++;
        }

        public Animal() { }
    }

    class Dog : Animal
    {
        public override void increaseAge() {
            if (this.age == 0) { this.age += 4; }
            else { this.age = this.age += 8; }
        }
    }
        
}
