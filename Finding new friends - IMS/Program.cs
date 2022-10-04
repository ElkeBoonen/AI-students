using System;
using System.IO;

namespace Finding_new_friends___IMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            foreach (var item in File.ReadLines(@"data/input1.txt"))
            {
                string[] items = item.Split(' ');
                graph.VriendjesMaken(items[0], items[1]);
            }
            Console.WriteLine(graph);

            Console.WriteLine(graph.BFS("Anna"));
            Console.WriteLine("\nMET PRIORITEIT " + graph.BFS_PRIORITY("Anna"));

            Console.WriteLine(graph.BFS("Diane"));
            Console.WriteLine("\nMET PRIORITEIT " + graph.BFS_PRIORITY("Diane"));

            Console.WriteLine(graph.BFS("Fred"));
            Console.WriteLine("\nMET PRIORITEIT " + graph.BFS_PRIORITY("Fred"));


        }
    }
}
