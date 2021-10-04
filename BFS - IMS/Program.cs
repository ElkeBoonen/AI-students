using System;
using System.IO;

namespace BFS___IMS
{
    class Program
    {
        static FB ReadTextFile(string filename)
        {
            FB fb = new FB();

            StreamReader reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                fb.AddPerson(line.Split(' ')[0], line.Split(' ')[1]);
            }
            reader.Close();
            return fb;
        }

        static void Main(string[] args)
        {
            FB fb = ReadTextFile("input1.txt");
            Console.WriteLine(fb);

            string[] friends = fb.FindFriends("Eva");
            foreach (var item in friends)
            {
                Console.Write(item + " ");
            }

         }
    }
}
