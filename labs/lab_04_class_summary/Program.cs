using System;

namespace lab_04_class_summary
{
    class Program
    {
        static void Main(string[] args)
        {
            var car1 = new Car();
            car1.name = "Audi a4";

            Console.Write("Enter a number for the model of the car: ");
            car1.SetModelNo(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine($" car name is: {car1.name}");
            Console.WriteLine($" model name is: {car1.GetModelNo()}");
        }
    }


    /*
     * class with:
     * - private/public field
     * - get/set methods 
     */
    class Car
    {
        public string name;
        private int modelNo;

        public int GetModelNo()
        {
            return this.modelNo;
        }
        public void SetModelNo(int modelNumber)
        {
            this.modelNo = modelNumber;
        }
    }
}
