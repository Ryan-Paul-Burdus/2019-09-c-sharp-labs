using System;
using System.Collections.Generic;
using System.Collections;

namespace lab_21_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //dictionary
            //pairs => 0, "hi"
            Console.WriteLine("=== DICTIONARY ===");
            var dictionary = new Dictionary<int, string>();
            dictionary.Add(0, "Hi");
            dictionary.Add(1, "Hi");
            //dictionary.Add(0, "Hi");//generates exception because a key can't have duplicate values
            dictionary.TryAdd(0, "Hi");//silently fails
            dictionary.TryAdd(2, "There");

            foreach (var item in dictionary)
            {
                Console.WriteLine(item);
            }

            //Queue
            Console.WriteLine("\n=== QUEUE ===");
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }
            Console.WriteLine(queue.Peek());
            queue.Dequeue();
            Console.WriteLine(queue.Peek());
            Console.WriteLine("Contains 2? " + queue.Contains(2));
            foreach (var item in queue)
            {
                Console.Write(item + ", ");
            }

            //Stack
            Console.WriteLine("\n\n=== STACK ===");
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < 5; i++)
            {
                stack.Push($"string{i}");
            }
            Console.WriteLine(stack.Peek());
            Console.WriteLine("Contains 'string4'? " + stack.Contains("string4"));
            stack.Pop();
            Console.WriteLine("Contains 'string4'? " + stack.Contains("string4"));

            //List
            Console.WriteLine("\n=== LIST ===");
            List<int> list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
            Console.Write("Original List: ");
            foreach (var item in list)
            {
                Console.Write(item + ", ");
            }
            list.Insert(5, 1234567890);
            list.RemoveAt(8);
            Console.Write("\nNew List: ");
            foreach (var item in list)
            {
                Console.Write(item + ", ");
            }

            //ArrayList
            Console.WriteLine("\n\n=== ARRAY LIST ===");
            ArrayList arrayList = new ArrayList();
            arrayList.Add(7.01);
            arrayList.Add("Hello");
            arrayList.Add("World!");
            arrayList.Add(2);
            Console.Write("Array list: ");
            foreach (var item in arrayList)
            {
                Console.Write(item + ", ");
            }

            //LinkedList
            Console.WriteLine("\n\n=== LINKED LIST ===");
            LinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddLast("Hello");
            linkedList.AddLast("World");
            linkedList.AddLast("again");
            Console.Write("Original list: ");
            foreach (var item in linkedList)
            {
                Console.Write(item + ", ");
            }
            linkedList.RemoveLast();
            Console.WriteLine("\n'removed last item'");
            Console.Write("New list: ");
            foreach (var item in linkedList)
            {
                Console.Write(item + ", ");
            }

            //Hashset
            Console.WriteLine("\n\n=== HASHSET ===");
            HashSet<int> hashset = new HashSet<int>();
            for (int i = 0; i < 10; i++)
            {
                hashset.Add(i);
            }
            Console.Write("Original list: ");
            foreach (var item in hashset)
            {
                Console.Write(item + ", ");
            }
            hashset.Remove(5);
            hashset.Remove(6);
            HashSet<int> newHashset = new HashSet<int>();
            newHashset.UnionWith(hashset);
            Console.Write("\nNew list: ");
            foreach (var item in newHashset)
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine("");
        }
    }
}
