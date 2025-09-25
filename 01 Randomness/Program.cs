namespace Randomness
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LCG lcg = new LCG();

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(lcg.Next(20));
            }
            lcg.NextAPI();

        }
    }
}
