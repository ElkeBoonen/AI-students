namespace IMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //in main
            GeneticAlgorithm ga = new GeneticAlgorithm(200, 8, 6);
            ga.Run();
        }
    }
}