using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_17_rabbit_database_explosion
{
    class Program
    {
        static List<Rabbit> rabbits;
        static void Main(string[] args)
        {
            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
            }

            PrintRabbits();

            //new rabbit : WPF Textbox01.text ==> use for Age, name (2 boxes)
            //buttonAdd : run this code
            var newRabbit = new Rabbit()
            {
                Age = 0,
                Name = $"Rabbit{rabbits.Count+1}"
            };

            using  (var db = new RabbitDbEntities())
            {
                db.Rabbits.Add(newRabbit);
                db.SaveChanges();
            }


            System.Threading.Thread.Sleep(200);

            Console.WriteLine("\n\n === After adding new Rabbits ===");
            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
                //prints rabbits
                PrintRabbits();
            }
            
        }

        static void PrintRabbits()
        {
            rabbits.ForEach(rabbit => Console.WriteLine($"{rabbit.RabbitId,-5}" +
                    $"{rabbit.Name,-12}{rabbit.Age}"));
        }
    }
}
