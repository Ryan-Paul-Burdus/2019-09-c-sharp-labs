using System;
using System.Collections.Generic;

namespace lab_5_list_objects
{
    class Program
    {
        static void Main(string[] args)
        {
            // count 1 to 10



            // create Rabbits



            // name = "Rabbit" + 0 + i    Rabbit01, Rabbit02,  
            // age = i
            // add to list of rabbits
            // print out list at end 

            List<Rabbit> rabbits = new List<Rabbit>();

            for  (int i = 1; i <= 10; i++)
            {
                Rabbit rabbit = new Rabbit();
                if (i < 10)
                {
                    rabbit.Name = "Rabbit" + 0 + i;
                }
                else
                {
                    rabbit.Name = "Rabbit" + i;
                }
                rabbit._age = i;
                rabbits.Add(rabbit);
            }

            

            foreach (Rabbit r in rabbits)
            {
                Console.WriteLine(r.Name + ", " + r._age);
            }
        }
    }

    class Rabbit
    {
        public int _age { get; set; }
        public string Name { get; set; }
    }
}
