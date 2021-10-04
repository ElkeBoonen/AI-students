using System;
using System.Collections.Generic;
using System.IO;

namespace Finding_friends
{
    class Program
    {
        static void Main(string[] args)
        {

            Graph graph = new Graph();

            StreamReader reader = new StreamReader("TestFiles/input1.txt");

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                graph.AddFriend(line.Split(' ')[0], line.Split(' ')[1]);
            }
            reader.Close();
            Console.WriteLine(graph);

            List<string> nodes = graph.BFS("Anna");
            foreach (var item in nodes)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            List<string> mutual = graph.MutualFriends("Anna", "Gene");
            foreach (var item in mutual)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
