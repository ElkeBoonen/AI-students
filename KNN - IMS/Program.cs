using System;
using System.IO;

namespace KNN___IMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            KNN iris = new KNN(File.ReadAllLines("iris.dat"));

            /*
                5.7,3.8,1.7,0.3,setosa
                5.1,3.8,1.5,0.3,setosa
                5.4,3.4,1.7,0.2,setosa
                6.1,2.8,4.7,1.2,versicolor
                6.4,2.9,4.3,1.3,versicolor
                6.3,2.8,5.1,1.5,virginica
                6.1,2.6,5.6,1.4,virginica
             */

            Console.WriteLine(iris.FindCLosest(new double[] { 5.7, 3.8, 1.7, 0.3 }));
            Console.WriteLine(iris.FindCLosest(new double[] { 6.1, 2.8, 4.7, 1.2 }));
            Console.WriteLine(iris.FindCLosest(new double[] { 6.3, 2.8, 5.1, 1.5 }));

            Console.WriteLine(iris.FindCLosest(new double[] { 6.3, 2.8, 5.1, 1.5 },5));

            /*
                2,50,12500,98,1
                0,13,3250,28,1
                1,16,4000,35,1
                2,20,5000,45,1
                1,24,6000,77,0
                4,4,1000,4,0
                2,7,1750,14,1
                1,12,3000,35,0
                2,9,2250,22,1
             */

            KNN blood = new KNN(File.ReadAllLines("transfusion.csv"));
            Console.WriteLine(blood.FindCLosest(new double[] { 0, 13, 3250, 28 }));
            Console.WriteLine(blood.FindCLosest(new double[] { 1, 24, 6000, 77 }));
        }
    }
}
