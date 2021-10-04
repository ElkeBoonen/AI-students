using System;
using System.IO;

namespace BFS___DSPS
{
    class Program
    {

        static void PrintArray(string[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            BFF bff = new BFF();
            string[] lines = File.ReadAllLines("input1.txt");
            foreach (string line in lines)
            {
                bff.AddConnection(line.Split(' ')[0], line.Split(' ')[1]);
            }
            Console.WriteLine(bff);

            string[] friends = bff.Connections("Anna");
            PrintArray(friends);

            friends = bff.Connections("Eva");
            PrintArray(friends);

            friends = bff.Connections("Diane");
            PrintArray(friends);

        }
    }
}
