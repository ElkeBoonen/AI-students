using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _08_KNN
{
    class Program
    {
        static Dictionary<double[], string> trainingset = new Dictionary<double[], string>();
        static void ReadData(string path)
        {
            StreamReader file = new StreamReader(path);
            while (!file.EndOfStream)
            {
                //sample data: 6.7,2.5,5.8,1.8,virginica
                String[] split = file.ReadLine().Split(',');

                double[] data = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    data[i] = Convert.ToDouble(split[i]);
                }
                //add range of trainingdata to data
                trainingset.Add(data, split[4]);
            }
            file.Close();
        }

        static string Classify(double[] test)
        {
            //create array of all distances
            double[] distances = new double[trainingset.Count];

            //i corresponds to the index, so we calculate the distance to every trainingset!
            for (int i = 0; i < trainingset.Count; i++)
            {
                distances[i] = EuclideanDistance(test, trainingset.ElementAt(i).Key);
            }
            //get the lowest distance from array - don't sort, because we lose the order!
            double min = distances.Min();
            //get index from trainingset
            int index = Array.IndexOf(distances, min);
            //index gives 
            return trainingset.ElementAt(index).Value;
        }
        static double EuclideanDistance(double[] sampleOne, double[] sampleTwo)
        {
            double d = 0.0;
            for (int i = 0; i < sampleOne.Length; i++)
            {
                d+= Math.Pow(sampleOne[i] - sampleTwo[i],2);
            }
            return Math.Sqrt(d);
        }
        static void Main(string[] args)
        {
            ReadData("iris.dat");

            /*
             * test data
             *  5.7,3.8,1.7,0.3,setosa
                5.1,3.8,1.5,0.3,setosa
                5.4,3.4,1.7,0.2,setosa
                6.1,2.8,4.7,1.2,versicolor
                6.4,2.9,4.3,1.3,versicolor
                6.3,2.8,5.1,1.5,virginica
                6.1,2.6,5.6,1.4,virginica
             */
            Console.WriteLine(Classify(new double[] { 6.1, 2.6, 5.6, 1.4 }));
        }
    }
}
