namespace _04_KNN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            KNN knn = new KNN("fruit.csv");
            Console.WriteLine(knn.Classify(
                    new double[] {100.3443246717246,2.991233059103209,80.01085729450219,8.849394133538194 }));
        }
    }
}
