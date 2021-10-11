using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranking___IMS
{
    class Regression
    {
        public void SimpleLinear(double[] x, double[] y, out double b, out double m, out double r2)
        {
            b = 0;
            m = 0;
            r2 = 0;
            if (x.Length != y.Length) return;

            //som x, som y, som xy, som x^2
            double sumX = 0, sumY = 0, sumXY = 0, sumX2 = 0, sumY2=0;
            for (int i = 0; i < x.Length; i++)
            {
                sumX += x[i];
                sumY += y[i];
                sumXY += x[i] * y[i];
                sumX2 += x[i] * x[i]; //Math.Pow(x[i],2) 
                sumY2 += Math.Pow(y[i], 2);
            }

            int n = x.Length;
            m = ((n * sumXY) - (sumX * sumY)) / ((n * sumX2) - Math.Pow(sumX, 2));
            b = (sumY - m * sumX) / n;

            double teller = (n * sumXY) - (sumX * sumY);
            double noemer = Math.Sqrt(n * sumX2 - Math.Pow(sumX, 2)) * Math.Sqrt(n * sumY2 - Math.Pow(sumY, 2));
            r2 = Math.Pow(teller / noemer, 2);

        }
    }
}
