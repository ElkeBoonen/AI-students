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

        public LR(int[] xvalues, int[] yvalues)
        {
            XValues = xvalues;
            YValues = yvalues;
            Slope = CalculateSlope();
            Intercept = CalculateIntercept();
        }

        private double CalculateSlope()
        { }

        private double CalculateIntercept()
        { }

        public double Predict(int x)
        { 
            return Slope * x + Intercept;
        }
    }
}
