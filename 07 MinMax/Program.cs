using System;
using System.Collections.Generic;

namespace _07_MinMax
{
    class Program
    {
        static int height;
        static int[] scores;

        static int minimax(int depth, int index, bool isMax)
        {
            //als we op leaf-node zitten!
            if (depth == height) return scores[index]; //base case
            
            //RECURSIVE CASE
            //maximaliseren!
            if (isMax)
                return Math.Max(minimax(depth + 1, index * 2, false), minimax(depth + 1, index * 2 + 1, false));
            //minimaliseren
            else
                return Math.Min(minimax(depth + 1, index * 2, true), minimax(depth + 1, index * 2 + 1, true));
        }

        static public void Main()
        {
            //aantal noden: macht van 2!
            Console.WriteLine("Geef nodewaarden (onderste laag in)");
            scores = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);

            height = (int)Math.Log(scores.Length, 2); //hoogte boom

            int resultaat = minimax(0, 0, true);
            Console.WriteLine("Resultaat: " + resultaat);

        }
    }
}

