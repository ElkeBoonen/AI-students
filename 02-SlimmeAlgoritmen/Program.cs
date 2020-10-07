using System;
using TM.ProgrammingAdvanced;

namespace _02_SlimmeAlgoritmen
{
    class Program
    {
        static int guesses;
        public static int Simple(int[] numbers, int number)
        {
            int position = 0;
            while (position < numbers.Length)
            {
                if (numbers[position] == number) return position;
                position++;
            }
            guesses = position;
            return -1;
        }

        public static int Binary(int[] numbers, int number)
        {
            guesses = 0;

            int min = 0;
            int max = numbers.Length - 1;

            int position = (min + max) / 2;

            while (min <= max)
            {
                guesses++;
                if (number == numbers[position]) return position;
                else if (number < numbers[position])
                {
                    max = position - 1;
                }
                else
                {
                    min = position + 1;
                }
                position = (min + max) / 2;
            }
            return -1;
        }

        static void Main(string[] args)
        {
            int[] nrs = TM.ProgrammingAdvanced.Data.Numbers;
            Console.WriteLine("Position of -564: " + Simple(nrs, -564) + " in " +guesses);
            Console.WriteLine("Position of 123: " + Simple(nrs, 123) + " in " + guesses);
            Console.WriteLine("Position of -564: " + Binary(nrs, -564) + " in " + guesses);
            Console.WriteLine("Position of 123: " + Binary(nrs, 123) + " in " + guesses);
        }
    }
}
