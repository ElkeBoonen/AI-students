namespace IMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            KNN knn = new KNN("iris.dat");
            Console.WriteLine(knn.Classify(new double[] { 6.1, 2.6, 5.6, 1.4 }));
            Console.WriteLine(knn.Classify(new double[] { 5.4, 3.4, 1.7, 0.2 }));
            Console.WriteLine(knn.Classify(new double[] { 6.1, 2.8, 4.7, 1.2 }));

        }
    }
}