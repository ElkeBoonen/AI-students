using System;

namespace NN___DSPS
{
    class Program
    {
        static void Main(string[] args)
        {
            /*double[,] a = new double[,] { {2,3}, {1,4},{9,6}};
            double[,] b = Matrix.Transpose(a);

            Console.WriteLine(Matrix.ToString(a));
            Console.WriteLine(Matrix.ToString(b));

            Console.WriteLine(Matrix.ToString(Matrix.DotProduct(a,b)));
            Console.WriteLine(Matrix.ToString(Matrix.Sum(a, a)));*/

            double[,] training_input = new double[,] { { 0, 0, 1 }, { 1, 1, 1 }, { 1, 0, 1 }, { 0, 1, 1 } };
            double[,] training_output = Matrix.Transpose(new double[,] { { 0, 1, 1, 0 } });

            var nn = new ANN(training_input, training_output);

            Console.WriteLine("Weights before training:");
            Console.WriteLine(Matrix.ToString(nn.Weights));

            nn.Train();

            Console.WriteLine("Weights after training:");
            Console.WriteLine(Matrix.ToString(nn.Weights));
            
            double[,] output = nn.Predict(new double[,] { { 1, 0, 0 } });
            Console.WriteLine("Predict [1, 0, 0] => " + output[0, 0]);
            
        }
    }
}
