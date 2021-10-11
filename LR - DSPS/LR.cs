using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR___DSPS
{
    class LRResult
    {
        public double Slope { get; set; }
        public double Intercept { get; set; }

        public double RSquared { get; set; }

        public override string ToString()
        {
            return $"Slope = {Slope}\nIntercept = {Intercept}\nR-Squared = {RSquared}";
        }
    }

    class LR
    {
        public LRResult CalculateLR(double[] x, double[] y)
        {
            if (x.Length != y.Length) throw new Exception("x and y-lengths must be equal!");

            double sumX = 0, sumY = 0, sumXY = 0, sumX2 = 0, sumY2=0;

            for (int i = 0; i < x.Length; i++)
            {
                sumX += x[i];
                sumY += y[i];
                sumXY += x[i] * y[i];
                sumX2 += Math.Pow(x[i], 2);
                sumY2 += Math.Pow(y[i], 2);
            }

            int n = x.Length;

            double m = ((n * sumXY) - (sumX * sumY)) / ((n * sumX2) - Math.Pow(sumX, 2));
            double b = (sumY - (m * sumX)) / n;

            double r2 = Math.Pow(((n * sumXY) - (sumX * sumY)) / 
                (Math.Sqrt(n * sumX2 - Math.Pow(sumX, 2)) * Math.Sqrt(n * sumY2 - Math.Pow(sumY, 2))), 2);

            return new LRResult { Slope = m, Intercept = b, RSquared = r2};
        }
    }
}
