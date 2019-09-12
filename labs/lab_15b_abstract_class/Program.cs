using System;

namespace lab_15b_abstract_class
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new MakingCake();
        }
    }

    abstract public class Cake
    {
        public abstract void MakeCake();

        public void BuyIngrediants()
        {
            Console.WriteLine("buying ingrediants");
        }

        public void BuyUtensils()
        {
            Console.WriteLine("Buying utensils");
        }
    }

    public class MakingCake : Cake
    {
        public override void MakeCake()
        {
            Console.WriteLine("Making cake");
        }
    }
}
