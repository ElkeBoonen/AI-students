namespace DSPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LR chimps = new LR(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }
                             , new int[] { 30, 45, 51, 57, 60, 65, 70, 71});
            Console.WriteLine(chimps.Slope());
            Console.WriteLine(chimps.Intercept());
            Console.WriteLine(chimps.Predict(4));
        }
    }
}