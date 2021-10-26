using System;

namespace ARRAYS___GROEP_B
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 11;

            int[] numbers = new int[4]; //lengte van 4, start op index 0 --> 3
            double[] doubles = { 8.3, 8.0, 1.2, 5, 7.6 }; //lengte van 5, start op 0 --> 4
            string[] namen = { "tuur", "jan", "mies", "bob" };

            number = 5;
            numbers[1] = 7; // 0 7 0 0
            doubles[4] = 8.9; // 8.3, 8.0, 1.2, 5, 8.9

            Console.WriteLine($"{numbers[0]} {numbers[1]} {numbers[2]} {numbers[3]}");
            Console.WriteLine($"{doubles[0]} {doubles[1]} {doubles[2]} {doubles[3]} {doubles[4]}");
            Console.WriteLine($"{numbers}"); //System.Int32[]

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            foreach (double item in doubles)
            {
                Console.WriteLine(item);
            }

            int index = 0;
            while (index < numbers.Length)
            {
                Console.Write(namen[index] + " ");
                index++;
            }

            Console.WriteLine("\nHoeveel punten wil je ingeven?");
            int aantal = Convert.ToInt32(Console.ReadLine());
            double[] punten = new double[aantal];

            for (int i = 0; i < aantal; i++)
            {
                Console.Write($"Geef punten in voor student {i}: ");
                string punt = Console.ReadLine();
                punten[i] = Convert.ToDouble(punt);
            }

            foreach (double item in punten)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("Geef fruit in, gescheiden door een hoog streepje");
            string[] fruit = Console.ReadLine().Split('-');
            foreach (string item in fruit)
            {
                Console.WriteLine(item + " ");
            }

            Console.WriteLine("Geef punten in, gescheiden door een spatie");
            string[] strPunten = Console.ReadLine().Split(' ');

            //eerste manier om string-array om te zetten naar double-array
            double[] punten1 = new double[strPunten.Length];
            for (int i = 0; i < strPunten.Length; i++)
            {
                punten1[i] = Convert.ToDouble(strPunten[i]);
            }

            //tweede manier om string-array om te zetten naar double-array
            double[] punten2 = Array.ConvertAll(strPunten, Convert.ToDouble);

        }
    }
}
