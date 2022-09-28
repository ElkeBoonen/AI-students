using RandomOrg.CoreApi;
using System;
using System.Security.Cryptography;

namespace Pseudo_Random___IMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LGC lgc = new LGC();
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(lgc.Next(100) + " ");
            }

            Console.WriteLine("\n\n");

            //haal je key bij https://api.random.org/create
            RandomOrgClient roc = RandomOrgClient.GetRandomOrgClient("API-KEY");
            try
            {
                int[] responses = roc.GenerateIntegers(1000, 0, 99);
                Console.WriteLine(string.Join(" ", responses));
            }
            catch
            {
                Console.WriteLine("Oeps");
            }
        }
    }
}
