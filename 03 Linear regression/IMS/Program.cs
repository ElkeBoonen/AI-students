namespace IMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LR chimps = new LR(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 },
                               new int[] { 30, 45, 51, 57, 60, 65, 70, 71 });
            Console.WriteLine("Slope: " + chimps.Slope);
            Console.WriteLine("Intercept: "+ chimps.Intercept);
            Console.WriteLine("Predict 4 = " + chimps.Predict(4));
            Console.WriteLine("R² " + chimps.RSquared());

        }
    }
}