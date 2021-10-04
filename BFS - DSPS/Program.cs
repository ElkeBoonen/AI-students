using System;
using System.IO;

namespace BFS___DSPS
{
    class Program
    {
        static void Main(string[] args)
        {
            BFF bff = new BFF();
            string[] lines = File.ReadAllLines("input1.txt");
            foreach (string line in lines)
            {
                bff.AddConnection(line.Split(' ')[0], line.Split(' ')[1]);
            }
            Console.WriteLine(bff);
        }
    }
}
