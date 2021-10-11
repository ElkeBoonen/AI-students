using System;
using System.Collections.Generic;
using System.IO;

namespace Ranking___IMS
{
    class Program
    {
        static void Main(string[] args)
        {
            /*double[] x = new double[] { 1,2,3,4,5,6,7,8};
            double[] y = new double[] { 30, 45, 51, 57, 60, 65, 70, 71};
            */

            StreamReader reader = new StreamReader("data.csv");

            List<double> x = new List<double>();
            List<double> y = new List<double>();


            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split(',');
                x.Add(Convert.ToDouble(line[0]));
                y.Add(Convert.ToDouble(line[1]));

            }
           
            double m, b, r2;
            Regression r = new Regression();
            r.SimpleLinear(x.ToArray(), y.ToArray(), out b, out m, out r2);
            Console.WriteLine($"y = {m}*x + {b}");
            Console.WriteLine($"r^2 = {r2}");

            //Console.Write($"Succesvolle jacht % bij 7 chimps {m * 7 + b}");

        }
    }
}
