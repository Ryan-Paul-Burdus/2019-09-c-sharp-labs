﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace just_do_it_11_rabbit_explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            just_do_it_11_rabbit_exp.Rabbit_Exponential_Growth(100);
        }
    }

    public class just_do_it_11_rabbit_exp
    {
        static List<Rabbit> rabbits = new List<Rabbit>();

        public static void addRabbit(int population, int populationLimit)
        {
            if (population >= populationLimit) { return; }

            Rabbit rabbit = new Rabbit();
            rabbit.Name = $"Rabbit{population + 1}";
            rabbit.Age = 0;
            rabbits.Add(rabbit);
            File.AppendAllText("myLogFile.log", $"{rabbit.Name} created at time {DateTime.Now}\n");
        }

        public static (int iterations, int population) Rabbit_Exponential_Growth(int populationLimit)
        {
            int population = 0;
            int iterationCount = 0;
            int newRabbitPopulation = 0;

            while (population < populationLimit)
            {
                iterationCount++;

                if (population == 0)
                {
                    Console.WriteLine("");
                    Rabbit rabbit = new Rabbit();
                    rabbit.Name = $"Rabbit{population+1}";
                    rabbit.Age = 0;
                    rabbits.Add(rabbit);
                    Console.WriteLine($"Name: {rabbit.Name}, Age: {rabbit.Age}");
                    population++;
                    Console.WriteLine("There are " + population + " rabbits as of iteration number " 
                        + iterationCount);
                    

                    File.AppendAllText("myLogFile.log", $"{rabbit.Name} created at time {DateTime.Now}\n");

                    Thread.Sleep(50);
                }
                else
                {
                    foreach (Rabbit r in rabbits)
                    {
                        r.Age++;
                        if (r.Age >= 2) { newRabbitPopulation++; }
                    }
                    while (rabbits.Count < newRabbitPopulation)
                    {
                        for (int i = 0; i < rabbits.Count; i++)
                        {
                            if (rabbits[i].Age >= 2)
                            {
                                addRabbit(population, populationLimit);
                                population++;
                            }
                        }
                        
                    }
                    foreach (Rabbit r in rabbits)
                    {
                        Console.WriteLine($"Name: {r.Name}, Age: {r.Age}");
                    }
                    
                    Console.WriteLine("There are " + population + " rabbits as of iteration number " + iterationCount);
                    
                    Thread.Sleep(50);
                }
            }
            return (iterationCount, population);
        }
    }

    class Rabbit
    {
        public string Name { get; set; }
        public int Age { get; set; }


        public Rabbit() { }

        public Rabbit(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
