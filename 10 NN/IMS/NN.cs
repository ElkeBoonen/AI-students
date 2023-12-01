namespace IMS
{
    internal class NN
    {
        private double[,] training_input;
        private double[,] training_output;
        public double[,] Weights { get; internal set; }

        public NN(double[,] training_input, double[,] training_output)
        {
            this.training_input = training_input;
            this.training_output = training_output;

            Weights = new double[training_input.GetLength(1), 1];
            Random random = new Random();
            for (int i = 0; i < Weights.GetLength(0); i++)
            {
                Weights[i, 0] = 2*random.NextDouble()-1;
            }
        }

        private double Sigmoid(double z)
        {
            return 1 / (1 + Math.Exp(-z));
        }

        internal void Train()
        {
            for (int j = 0; j < 10000; j++)
            {
                //STEP 1: matrix multiplication of input and weights, ​dot product of input training & weight
                double[,] step1 = Matrix.DotProduct(training_input, Weights);

                //STEP 2: sigmoid function
                double[,] step2 = new double[step1.GetLength(0), step1.GetLength(1)];
                for (int i = 0; i < step2.GetLength(0); i++)
                {
                    step2[i, 0] = Sigmoid(step1[i, 0]);
                }

                //STEP 3: calculate error: expected output -sigmoid output ​subtract 2 matrices
                double[,] error = Matrix.Substract(step2, training_output);

                //STEP 4: sigmoid derivative = output * (1-output)​
                double[,] step4 = step2;
                for (int i = 0; i < step2.GetLength(0); i++)
                {
                    step4[i, 0] *= 1 - step4[i, 0];
                }

                //STEP 5: multiply error and sigmoid derivative
                double[,] step5 = Matrix.Multiplication(error, step4);

                //STEP 6: calculate adjustments, ​dot product of training input and matrix from step 5
                double[,] step6 = Matrix.DotProduct(Matrix.Transpose(training_input), step5);

                //STEP 7: adjust weights, ​add adjustment-matrix to weights-matrix
                Weights = Matrix.Sum(Weights, step6);
            }

        }

        public double Predict(double[,] doubles)
        {
            return Sigmoid(Matrix.DotProduct(doubles, Weights)[0,0]);
        }
    }
}