namespace RANDOM_IMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LCG lcg = new LCG();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(lcg.Next());
            }

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(lcg.Next(2));
            }
        }
    }
}
