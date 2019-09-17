using System;

namespace lab_27_interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Child();
            c.IDoThis();
            c.IDoThat();
            c.DoingParentThing();
            c.IalsoDoThat();
        }
    }

    class Parent
    {
        public void DoingParentThing() { Console.WriteLine("Doing Parent thing"); }
    }

    class Child : Parent, IUseThis, IUseThat, external.IAlsoDoThis
    {
        public void IDoThis() { Console.WriteLine("IDoThis"); }

        public void IDoThat() { Console.WriteLine("IDoThat"); }

        public void IalsoDoThat() { Console.WriteLine("I also do that"); }
    }

    interface IUseThis
    {
        void IDoThis();
    }

    interface IUseThat
    {
        void IDoThat();
    }
}

//can use 'using external' or just inherit with 'external.IAlsoDoThis'
namespace external
{
    interface IAlsoDoThis { void IalsoDoThat(); }
}
