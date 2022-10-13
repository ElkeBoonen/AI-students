using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Ranking___IMS
{
    class Program
    {
        static void Main(string[] args)
        {
       
            LR chimp = new LR(new double[] {1,2,3,4,5,6,7,8 }, new double[] {30,45,51,57,60,65,70,71 });
            Console.WriteLine(chimp.m + " " + chimp.b);
            Console.WriteLine(chimp.Predict(4));
            Console.WriteLine(chimp.R2);

            List<double> x = new List<double>();
            List<double> y = new List<double>();


            foreach (var item in File.ReadAllLines("wine.csv"))
            {
                string[] items = item.Split(',');
                try
                {
                    x.Add(Convert.ToDouble(items[10]));
                    y.Add(Convert.ToDouble(items[11]));
                }
                catch { }

            }

            LR wine = new LR(x.ToArray(), y.ToArray());
            Console.WriteLine(wine.m + " " + chimp.b);
            Console.WriteLine(wine.Predict(12));
            Console.WriteLine(wine.R2);
        }
    }
}
