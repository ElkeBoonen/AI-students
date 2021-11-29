using System;

namespace ANN___IMS
{
    class Program
    {
        static void Main(string[] args)
        {
            /*double[,] matrixA = new double[,] { { 1,2},{ 3,4 } };
            double[,] matrixB = new double[,] { { 1 },{ 1 } };

            Console.WriteLine(Matrix.ToString(matrixA));
            Console.WriteLine(Matrix.ToString(matrixB));

            Console.WriteLine(Matrix.ToString(Matrix.Add(matrixA, matrixA)));
            Console.WriteLine(Matrix.ToString(Matrix.Subtract(matrixA, matrixA)));
            Console.WriteLine(Matrix.ToString(Matrix.Multiplication(matrixA, matrixA)));

            Console.WriteLine(Matrix.ToString(Matrix.Transpose(matrixA)));
            Console.WriteLine(Matrix.ToString(Matrix.DotProduct(matrixA, matrixB)));
            */

            double[,] training_input = new double[,] { { 0, 0, 1 }, { 1, 1, 1 }, { 1, 0, 1 }, { 0, 1, 1 } };
            double[,] training_output = Matrix.Transpose(new double[,] { { 0, 1, 1, 0 } });

            var nn = new NN(training_input, training_output);

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
