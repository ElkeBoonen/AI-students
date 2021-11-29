using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN___IMS
{
    class NN
    {
        double[,] input;
        double[,] output;
        public double[,] Weights { get; set; }

        public NN(double[,] trin, double[,] trou)
        {
            input = trin;
            output = trou;
            Weights = new double[input.GetLength(1), 1];
            Random rd = new Random();
            for (int i = 0; i < Weights.GetLength(0); i++)
            {
                Weights[i, 0] = (double)rd.Next(-100, 100) / 100;
            }
        }

        private void Sigmoid(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, 0] = 1 / (1 + Math.Pow(Math.E, matrix[i, 0] * -1));
            }
        }

        private double[,] SigmoidDerivative(double[,] matrix)
        {
            double[,] derivative = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                derivative[i, 0] = matrix[i, 0] * (1 - matrix[i, 0]);
            }
            return derivative;
        }

        public void Train()
        {
            for (int i = 0; i < 20000; i++)
            {
                //step 1: matrix multiplication of input and weights
                double[,] matrix = Matrix.DotProduct(input, Weights);
                //step 2: sigmoid function
                Sigmoid(matrix);
                //step 3: calculate error: expected output - sigmoid output
                double[,] error = Matrix.Subtract(output, matrix);
                //step 4: sigmoid derivative = output * (1 - output)​
                double[,] derivative = SigmoidDerivative(matrix);
                //STEP 5: multiply error and sigmoid derivative
                double[,] multiplication = Matrix.Multiplication(error, derivative);
                //STEP 6: calculate adjustments
                double[,] adjustments = Matrix.DotProduct(Matrix.Transpose(input), multiplication);
                //STEP 7: adjust weights
                Weights = Matrix.Add(Weights, adjustments);
            }
        }

        public double[,] Predict(double[,] matrix)
        {
            //step 1: matrix multiplication of input and weights
            double[,] predict = Matrix.DotProduct(matrix, Weights);
            //step 2: sigmoid function
            Sigmoid(predict);

            return predict;

        }

    }
}
