using RandomOrg.CoreApi;

namespace Psuedo_Random___DSPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PseudoRandom pseudo = new PseudoRandom();
            for (int i = 0; i < 100; i++)
            {
                Console.Write(pseudo.Next() + " ");
            }

            Console.WriteLine("\n");

            for (int i = 0; i < 100; i++)
            {
                Console.Write(pseudo.Next(100) + " ");
            }

            Console.WriteLine("\n");

            RandomOrgClient roc = RandomOrgClient.GetRandomOrgClient("API-key");
            int[] randomnumbers = roc.GenerateIntegers(100, 1, 99);

            Console.WriteLine(String.Join(' ', randomnumbers));


        }
    }
}