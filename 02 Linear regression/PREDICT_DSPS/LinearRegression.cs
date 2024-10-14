using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREDICT_DSPS
{
    class LinearRegression
    {
        public double b { get; set; }
        public double m { get; set; }

        public double Rsqrd { get; set; } 

        public void Fit(double[] x, double[] y)
        {
            if (x.Length != y.Length) throw new Exception("x and y should have the same length!");

            double xsum =  x.Sum();
            double ysum = y.Sum();

            double sumxy = 0, sumxx = 0, sumyy=0;

            for (int i = 0; i < x.Length; i++)
            {
                sumxy += x[i] * y[i];
                sumxx += x[i] * x[i];
                sumyy += Math.Pow(y[i],2);
            }

            m = (x.Length * sumxy - xsum * ysum) / (x.Length * sumxx - xsum * xsum);
            b = (ysum - m * xsum) / x.Length;

            Rsqrd = (x.Length * sumxy - xsum * ysum) / (Math.Sqrt(x.Length * sumxx - Math.Pow(xsum, 2)) * Math.Sqrt(x.Length * sumyy - Math.Pow(ysum, 2)));
        }

        public double Predict(double x)
        {
            return m * x + b;
        }

    }
}
