using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace lab_31_tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // anonymous (lambda) delegate
            var task01 = new Task(() => 
            {
                Console.WriteLine("Running task01");
            });
            task01.Start();

            // named delegate in here, simplist delegate called action (action is no parameters in, void output)
            var taskOld = new Task(DoThis);
            taskOld.Start();

            var task02 = Task.Run(() =>
            {
                Console.WriteLine("Running task02");
            });

            var taskArray = new Task[10];
            taskArray[0] = Task.Run(() => { Console.WriteLine("TaskArray 01"); });
            taskArray[1] = Task.Run(() => { Console.WriteLine("TaskArray 02"); });
            taskArray[2] = Task.Run(() => { Console.WriteLine("TaskArray 03"); });

            var counter = 3;
            for (int i = 3; i < 10; i++)
            {
                taskArray[counter] = Task.Run(() => { Console.WriteLine($"Task Array  {counter + 1}"); });
                System.Threading.Thread.Sleep(10);
                counter++;
            }

            Task.WaitAll(taskArray);

            //Console.ReadLine();

            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();

            //Parallel ForEach
            var myList = new List<string> { "a", "b", "c", "d", "e", "f" };
            //this takes 150ms (3 loops in serial)
            sw.Start();
            myList.ForEach((s) =>
            {
                Console.WriteLine($"item is {s}");
                System.Threading.Thread.Sleep(50);
            });
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw2.Start();
            //executing in parallel
            Parallel.ForEach(myList, (s) => 
            {
                Console.WriteLine($"Parallel Item is {s}");
                System.Threading.Thread.Sleep(50);
            });
            sw2.Stop();
            Console.WriteLine(sw2.ElapsedMilliseconds);

            //PLINQ - Parallel LINQ 
            var output = (from item in myList select item).ToList();
            var outputAsParallel = (from item in myList select item).AsParallel().ToList();

            //Getting data back from a task 
            //var t = Task.Run( () => {} );
            //var t = Task<T>.Run( () => {} ); <- return data of type T
            //access data with -> t.Result
            var taskWithResult = Task<int>.Run(() =>
            {
                return 100;
            });
            taskWithResult.Wait();
            Console.WriteLine($"Result of our task is {taskWithResult.Result}");
            Console.ReadLine();
        }

        static void DoThis() { Console.WriteLine("DoThis() method called"); }
    }
}
