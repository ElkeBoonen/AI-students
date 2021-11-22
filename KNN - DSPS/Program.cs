using System;

namespace KNN___DSPS
{
    class Program
    {
        static void Main(string[] args)
        {
            KNN knn = new KNN();
            knn.ReadFile("iris.dat");

            /*
                5.7,3.8,1.7,0.3,setosa
                5.1,3.8,1.5,0.3,setosa
                5.4,3.4,1.7,0.2,setosa
                6.1,2.8,4.7,1.2,versicolor
                6.4,2.9,4.3,1.3,versicolor
                6.3,2.8,5.1,1.5,virginica
                6.1,2.6,5.6,1.4,virginica
             */

            Console.WriteLine(knn.Classify(new double[] { 6.4, 2.9, 4.3, 1.3 }));

            knn = new KNN();
            knn.ReadFile("puppy.csv");
            /*
                0,1,1,1,0,0,0,0,1,1,0,0,20
                0,1,1,1,0,0,0,0,1,0,0,0,20
                0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 30
             */


            Console.WriteLine(knn.Classify(new double[] { 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0 }));
        }
    }
}
