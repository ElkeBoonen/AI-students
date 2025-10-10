namespace LR
{
    internal class LinearRegression
    {
        private double[] xValues;
        private double[] yValues;

        private double n;

        public double Intercept { get; private set; }
        public double Slope { get; private set; }
        public double RSquared { get; private set; }


        public LinearRegression(double[] xValues, double[] yValues)
        {
            this.xValues = xValues;
            this.yValues = yValues;
            this.n = xValues.Length;
            Calculate();
        }

        private void Calculate()
        {
            double xsum = 0, ysum = 0, xysum = 0, xsum2 = 0, ysum2 = 0;
            for (int i = 0; i < n; i++)
            {
                xsum += xValues[i];
                ysum += yValues[i];
                xysum += xValues[i] * yValues[i];
                xsum2 += xValues[i] * xValues[i];
                ysum2 += yValues[i] * yValues[i];
            }

            Slope = (n * xysum - xsum * ysum) / (n * xsum2 - xsum * xsum);
            Intercept = (ysum - (Slope * xsum)) / n;

            RSquared = Math.Pow((n * xysum - xsum * ysum) / (Math.Sqrt(n * xsum2 - xsum * xsum) * Math.Sqrt(n * ysum2 - ysum * ysum)), 2);
        }

    }
}