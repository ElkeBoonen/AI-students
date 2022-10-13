using System;

namespace Ranking___DSPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LR lr = new LR();
            lr.Train(new double[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 
                     new double[] { 30, 45, 51, 57, 60, 65, 70, 71 });

            Console.WriteLine($"m: {lr.m} - b {lr.b}");
            Console.WriteLine(lr.Predict(4));
            Console.WriteLine($"R²: {lr.R2}");
            //lr.Predict()



        }
    }
}
