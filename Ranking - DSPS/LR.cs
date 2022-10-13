using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ranking___DSPS
{
    class LR
    {
        //public double[] xValues { get; private set; }
        //public double[] yValues { get; private set; }

        private double _m;
        private double _b;
        private double _r2;

        public double m {
            get { return Math.Round(_m, 4); }
            private set { _m = value; }
        }
        public double b {
            get { return Math.Round(_b, 4); }  
            private set { _b = value; } 
        }

        public double R2 {
            get { return Math.Pow(_r2, 4); }
            set { _r2 = value; } 
        }

        public void Train(double[] x, double[] y)
        {
            double sigma_x = x.Sum();
            double sigma_y = y.Sum();

            double sigma_xy = 0;
            double sigma_x2 = 0;
            double sigma_y2 = 0;

            for (int i = 0; i < x.Length; i++)
            {
                sigma_xy += x[i] * y[i];
                sigma_x2 += Math.Pow(x[i], 2);
                sigma_y2 += Math.Pow(y[i], 2);
            }

            _m = (x.Length*sigma_xy-(sigma_x*sigma_y))/(x.Length*sigma_x2-(sigma_x*sigma_x));
            _b = (sigma_y - _m * sigma_x) / x.Length;

            //check code - different output
            _r2 = Math.Pow(((x.Length * sigma_xy) - (sigma_x * sigma_y)) / (Math.Sqrt(x.Length * sigma_x2 - Math.Pow(sigma_x, 2)) * Math.Sqrt(x.Length * sigma_y2 - Math.Pow(sigma_y, 2))), 2);
        }

        public double Predict(double x)
        {
            return _m * x + _b;
        }
    }
}
