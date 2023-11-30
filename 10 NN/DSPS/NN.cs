namespace DSPS
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
            Random rd = new Random();
            Weights = new double[training_input.GetLength(1), 1];
            for (int i = 0; i < Weights.GetLength(0); i++)
            {
                Weights[i,0] = rd.NextDouble();
            }
        }


        internal double Predict(double[,] doubles)
        {
            return Sigmoid(Matrix.DotProduct(doubles, Weights)[0, 0]);
        }

        private double Sigmoid(double z)
        {
            return 1 / (1 + Math.Pow(Math.E, -z));
        }

        internal void Train()
        {

            for (int j = 0; j < 10000; j++)
            {

                //step 1 matrix multiplication of input and weights
                double[,] step1 = Matrix.DotProduct(training_input, Weights);

                for (int i = 0; i < step1.GetLength(0); i++)
                {
                    //Console.WriteLine("STEP 1" + step1[i, 0]);
                    step1[i, 0] = Sigmoid(step1[i, 0]);
                    //Console.WriteLine("SIGMOID" + step1[i, 0]);
                }

                double[,] error = Matrix.Substract(training_output, step1);
                //Matrix.Print(error);

                //sigmoid derivative = output * (1-output)​
                double[,] step4 = step1;
                //Matrix.Print(step4);

                for (int i = 0; i < step4.GetLength(0); i++)
                {
                    step4[i, 0] *= (1 - step4[i, 0]);
                }

                //Matrix.Print(step4);

                //step5
                double[,] step5 = Matrix.Multiplication(step4, error);
                //Matrix.Print(step5);

                //Matrix.Print(step5);

                //step 6 ​dot product of training input and matrix from step 5
                double[,] step6 = Matrix.DotProduct(Matrix.Transpose(training_input),step5);
                //Matrix.Print(step6);

                //STEP 7: adjust weights ​add adjustment-matrix to weights-matrix
                for (int i = 0; i < Weights.GetLength(0); i++)
                {
                    Weights[i, 0] += step6[i, 0];
                }
            }
        }
    }
}