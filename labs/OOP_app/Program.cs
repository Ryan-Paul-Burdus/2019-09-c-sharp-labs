using System;

namespace OOP_app
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Child();
            Console.WriteLine(c.DoThat("hello"));
            Console.WriteLine(c.DoThis("hello"));
            c.maybeDoThis();
        }
    }

    abstract class Parent : IDoThis, IDoThat
    {
        private string name;
        protected string lastName;
        internal int age;


        public abstract void maybeDoThis();

        public virtual void maybeDoThis(string input)
        {
            Console.WriteLine($"Child overriding parent with input: {input}");
        }

        public string DoThat(string input)
        {
            string readInput = Console.ReadLine();
            string output = input += $"readInput"; 
            return output;
        }

        public string DoThis(string input)
        {
            string output = $"{input} {input}";
            return output;
        }
    }

    class Child : Parent
    {
        public override void maybeDoThis()
        {
            Console.WriteLine("abstract override method");
        }
    }

    interface IDoThis
    {
        string DoThis(string input);
    }

    interface IDoThat
    {
        string DoThat(string input);
    }
}
