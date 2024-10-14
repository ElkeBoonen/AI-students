namespace RANDOM_DSPS
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

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(lcg.Next(10));
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(lcg.Next(100));
            }
        }
    }
}
