using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN___DSPS
{
    class ANN
    {
        private double[,] _trainingInput { get; set; }
        private double[,] _trainingOutput { get; set; }
        public double[,] Weights { get; set; }

        public ANN(double[,] trainingInput, double[,] trainingOutput)
        {
            _trainingInput = trainingInput;
            _trainingOutput = trainingOutput;

            Weights = new double[trainingInput.GetLength(1), 1];
            Random rd = new Random();
            for (int i = 0; i < Weights.GetLength(0); i++)
            {
                Weights[i, 0] = (rd.NextDouble() * 2) - 1;
            }
        }

        private void Sigmoid(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, 0] = 1 / (1 + Math.Pow(Math.E, -matrix[i, 0]));
            }
        }

        private void SigmoidDerivative(double[,] matrix)
        {
            //output * (1-output)​
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, 0] = matrix[i, 0] * (1 - matrix[i, 0]);
            }
        }

        public void Train()
        {
            for (int i = 0; i < 10000; i++)
            {
                //STEP 1: matrix multiplication of input and weights
                double[,] matrix = Matrix.DotProduct(_trainingInput, Weights);
                //STEP 2: sigmoid function
                Sigmoid(matrix);
                //STEP 3: calculate error: expected output (training ouput) - sigmoid output
                double[,] error = Matrix.Substract(_trainingOutput, matrix);
                //STEP 4: sigmoid derivative 
                SigmoidDerivative(matrix);
                //STEP 5: multiply error and sigmoid derivative
                matrix = Matrix.Multiplication(error, matrix);
                //STEP 6: calculate adjustments - dot product of training input and matrix from step 5
                matrix = Matrix.DotProduct(Matrix.Transpose(_trainingInput), matrix);
                //STEP 7: adjust weights - ​add adjustment-matrix to weights-matrix
                Weights = Matrix.Sum(Weights, matrix);
            }
        }

        public double[,] Predict(double[,] input)
        { 
            double[,] output = Matrix.DotProduct(input, Weights);
            Sigmoid(output);
            return output;
        }
    }
}
