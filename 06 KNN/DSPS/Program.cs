namespace DSPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KNN knn = new KNN("iris.dat");

            Console.WriteLine(knn.Classify(
                    new double[] { 6.1, 2.6, 5.6, 1.4 }));
        }
    }
}