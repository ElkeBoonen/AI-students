using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS
{
    class LR
    {
        public int[] XValues { get; private set; }
        public int[] YValues { get; private set; }
        public double Slope { get; private set; }
        public double Intercept { get; private set; }

        private int n = 0;

        public LR(int[] xvalues, int[] yvalues)
        {
            XValues = xvalues;
            YValues = yvalues;
            n = XValues.Length;

            Slope = Math.Round(CalculateSlope(),4);
            Intercept = Math.Round(CalculateIntercept(),4);
        }

        private double CalculateSlope()
        {
            double sum_xy = 0 , sum_x = 0, sum_y = 0, sum_x2 = 0;
            for (int i = 0; i < XValues.Length; i++)
            {
                sum_xy += XValues[i] * YValues[i];
                sum_x += XValues[i];
                sum_y += YValues[i];
                sum_x2 += Math.Pow(XValues[i], 2);
            }
            return (n * sum_xy - sum_x * sum_y) / (n * sum_x2 - Math.Pow(sum_x, 2));
        }

        private double CalculateIntercept()
        {
            double sum_x = XValues.Sum();
            double sum_y = YValues.Sum();
            return (sum_y - Slope * sum_x) / n;
        }

        public double Predict(int x)
        { 
            return Slope * x + Intercept;
        }

        public double RSquared()
        {
            double sum_xy = 0, sum_x = 0, sum_y = 0, sum_x2 = 0, sum_y2=0;
            for (int i = 0; i < XValues.Length; i++)
            {
                sum_xy += XValues[i] * YValues[i];
                sum_x += XValues[i];
                sum_y += YValues[i];
                sum_x2 += Math.Pow(XValues[i], 2);
                sum_y2 += Math.Pow(YValues[i], 2);
            }
            double num = n * sum_xy - sum_x * sum_y;
            double den = Math.Sqrt(n * sum_x2 - sum_x * sum_x) * Math.Sqrt(n * sum_y2 - sum_y * sum_y);

            return Math.Pow(num/den,2);

        }
    }
}
