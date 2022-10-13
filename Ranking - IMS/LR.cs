using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ranking___IMS
{
    class LR
    {
        public double m { get; private set; }
        public double b { get; private set; }
        public double R2 { get; private set; }

        public LR(double[] x, double[] y)
        {
            this.Calculate(x,y);
        }
        private void Calculate(double[] x, double[] y)
        { 
            int n = x.Length;

            double sum_x = x.Sum();
            double sum_y = y.Sum();

            double sum_xy = 0;
            double sum_x2 = 0;
            double sum_y2 = 0;
            for (int i = 0; i < n; i++)
            {
                sum_xy += x[i] * y[i];
                sum_x2 += x[i] * x[i]; //Math.Pow()
                sum_y2 += y[i] * y[i]; //Math.Pow()

            }

            m = ((n * sum_xy) - (sum_x * sum_y)) / (n * sum_x2 - Math.Pow(sum_x, 2));
            m = Math.Round(m, 4);
            b = (sum_y-(m* sum_x))/n;
            b = Math.Round(b, 4);

            R2 = Math.Pow(((n * sum_xy) - (sum_x * sum_y)) / (Math.Sqrt(n * sum_x2 - Math.Pow(sum_x, 2)) * Math.Sqrt(n * sum_y2 - Math.Pow(sum_y, 2))), 2);

        }

        public double Predict(double x)
        {
            return m * x + b;
        }
    }
}
