namespace PREDICT_DSPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] x = { 1, 2, 3, 4, 5, 6, 7, 8 };
            double[] y = { 30, 45, 51, 57, 60, 65, 70, 71 };

            LinearRegression linearRegression = new LinearRegression();
            linearRegression.Fit(x, y);
            Console.WriteLine(linearRegression.m);
            Console.WriteLine(linearRegression.b);
            Console.WriteLine(linearRegression.Predict(4));
            Console.WriteLine(linearRegression.Rsqrd);

            Console.WriteLine();

            string[] lines = File.ReadAllLines("data.csv");
            x = new double[lines.Length-1];
            y = new double[lines.Length-1];

            for (int i = 1; i < lines.Length; i++)
            {
                double[] doubles = Array.ConvertAll(lines[i].Split(","), Convert.ToDouble);
                x[i - 1] = doubles[1];
                y[i - 1] = doubles[doubles.Length - 1];
            }

            linearRegression.Fit(x, y);
            Console.WriteLine(linearRegression.m);
            Console.WriteLine(linearRegression.b);
            Console.WriteLine(linearRegression.Predict(41));
            Console.WriteLine(linearRegression.Rsqrd);



        }
    }
}
