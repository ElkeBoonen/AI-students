using System;
using System.Collections.Generic;
using System.IO;

namespace LR___DSPS
{
    class Program
    {
        static void Main(string[] args)
        {
            //CHIMPS EXAMPLE
            double[] x = { 1, 2, 3, 4, 5, 6, 7, 8 };
            double[] y = { 30,45,51,57, 60, 65, 70, 71 };

            LR lr = new LR();
            LRResult lrResult =  lr.CalculateLR(x, y);
            Console.WriteLine(lrResult);

            Console.WriteLine("4 chimps have a hunting success rate of " + (lrResult.Slope * 4 + lrResult.Intercept));

            //INCOME HAPPINESS EXAMPLE
            StreamReader reader = new StreamReader("data.csv");
            List<double> listX = new List<double>();
            List<double> listY = new List<double>();

            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split(',');
                listX.Add(Convert.ToDouble(line[0]));
                listY.Add(Convert.ToDouble(line[1]));
            }
            lrResult = lr.CalculateLR(listX.ToArray(), listY.ToArray());
            Console.WriteLine(lrResult);


        }
    }
}
