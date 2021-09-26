using System;

namespace Random_numbers
{
    class Program
    {
  
        static void Main(string[] args)
        {
            LCG lcg = new LCG();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(lcg.Next());
            }
        }
    }
}
