using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPS
{
    class LR
    {

        //y=mx+b --> m = slope, b = intercept
        private int[] x { get; set; }
        private int[] y { get; set; }
        public LR(int[] xvalues, int[] yvalues)
        {
            x = xvalues;
            y = yvalues;
        }

        public double Slope() //n∑xy−∑x∑y / n∑x^2-(∑x)^2 ​
        {
            int xtotals = x.Sum();
            int ytotals = y.Sum();
            int n = x.Length;

            int xytotals = 0;
            int x2totals = 0;
            for (int i = 0; i < n; i++)
            {
                xytotals += x[i] * y[i];
                x2totals += x[i] * x[i];
            }

            double up = n * xytotals - xtotals * ytotals;
            double down = n * x2totals - xtotals*xtotals;
            return Math.Round(up / down,4);
            
        }

        public double Intercept() //∑y−m∑x / n
        {
            return Math.Round((y.Sum() - Slope() * x.Sum()) / x.Length,4);
        }

        public double Predict(int x)
        { 
            return Math.Round(Slope()*x + Intercept(),4);
        }
    }
}
