using System;

namespace PUNTEN___GROEP_B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef een reeks punten in, gescheiden met een spatie");
            double[] punten = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToDouble);

            double min = punten[0];
            for (int i = 0; i < punten.Length; i++)
            {
                if (punten[i] < min)
                {
                    min = punten[i];
                }
            }
            Console.WriteLine($"Het minimum: {min}");

            for (int i = 0; i < punten.Length; i++)
            {
                for (int j = 0; j < punten.Length -1; j++)
                {
                    if (punten[j] > punten[j + 1])
                    {
                        double temp = punten[j];
                        punten[j] = punten[j + 1];
                        punten[j + 1] = temp;
                    }
                }
            }

            Console.Write("Gesorteerd: ");
            foreach (var item in punten)
            {
                Console.Write(item + " ");
            }

            double som = 0 ;
            foreach (double item in punten)
            {
                som += item;
            }
            Console.WriteLine($"\nDe som: {som}");
            Console.WriteLine($"Het gemiddelde: {som/punten.Length}");
        }
    }
}
