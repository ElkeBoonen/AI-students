using System;
using System.IO;
using System.Runtime.InteropServices;

namespace LR
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<double> xValues = new List<double>();
            List<double> yValues = new List<double>();

            foreach (string line in File.ReadAllLines("california_housing_dataset.csv").Skip(1))
            {
                string[] parts = line.Split(",");
                xValues.Add(Convert.ToDouble(parts[3]));
                yValues.Add(Convert.ToDouble(parts[parts.Length-1]));

                //Console.WriteLine(Convert.ToDouble(parts[1]));
            }

            //double[] xValues = new double[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            //double[] yValues = new double[] { 30, 45, 51, 57, 60, 65, 70, 71 };

            LinearRegression lr = new LinearRegression(xValues.ToArray(), yValues.ToArray());

            Console.WriteLine($"Intercept = {lr.Intercept}");
            Console.WriteLine($"Slope = {lr.Slope}");

            double predictedValue = (lr.Slope * 4) + lr.Intercept;
            Console.WriteLine($"Prediction for 4 chimpanzees: {predictedValue}");

            Console.WriteLine($"RSquared = " + lr.RSquared);
        }
    }
}
