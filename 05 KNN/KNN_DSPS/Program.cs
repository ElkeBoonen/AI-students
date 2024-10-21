namespace KNN_DSPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            /*
                5.7,3.8,1.7,0.3,setosa
                5.1,3.8,1.5,0.3,setosa
                5.4,3.4,1.7,0.2,setosa
                6.1,2.8,4.7,1.2,versicolor
                6.4,2.9,4.3,1.3,versicolor
                6.3,2.8,5.1,1.5,virginica
                6.1,2.6,5.6,1.4,virginica

             */

            KNN knn = new KNN("iris.dat");
            Console.WriteLine(knn.Classify(new double[] { 5.4, 3.4, 1.7, 0.2 },5));
        }
    }
}
