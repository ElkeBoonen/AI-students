
namespace _08_ANN
{
    internal class NN
    {
        private double[,] training_input;
        private double[,] training_output;
        public double[,] Weights { get; internal set; }


        public NN(double[,] input, double[,] output)
        {
            this.training_input = input;
            this.training_output = output;

            Weights = new double[input.GetLength(1), 1];
            Random rd = new Random();
            for (int i = 0; i < Weights.GetLength(0); i++)
            {
                Weights[i, 0] = rd.NextDouble()*2-1;
            }
        }


        internal double[,] Predict(double[,] doubles)
        {
            double[,] step1 = Matrix.DotProduct(training_input, Weights);

            //STEP 2
            double[,] sigmoid = new double[step1.GetLength(0), 1];
            for (int i = 0; i < sigmoid.GetLength(0); i++)
            {
                sigmoid[i, 0] = 1 / (1 + Math.Exp(step1[i, 0] * -1));
            }
            return sigmoid;
        }

        internal void Train()
        {
            for (int k = 0; k < 10000; k++)
            {

                //STEP 1
                double[,] step1 = Matrix.DotProduct(training_input, Weights);

                //STEP 2
                double[,] sigmoid = new double[step1.GetLength(0), 1];
                for (int i = 0; i < sigmoid.GetLength(0); i++)
                {
                    sigmoid[i, 0] = 1 / (1 + Math.Exp(step1[i, 0] * -1));
                }

                //STEP 3
                double[,] error = Matrix.Substract(training_output, sigmoid);

                //STEP 4
                double[,] sigmoid_derivative = new double[step1.GetLength(0), 1];
                for (int i = 0; i < sigmoid_derivative.GetLength(0); i++)
                {
                    sigmoid_derivative[i, 0] = sigmoid[i, 0] * (1 - sigmoid[i, 0]);
                }

                //STEP 5
                double[,] step5 = Matrix.Multiplication(error, sigmoid_derivative);

                //STEP 6
                double[,] adjustments = Matrix.DotProduct(Matrix.Transpose(training_input), step5);

                Weights = Matrix.Sum(Weights, adjustments);
            }
        }
    }
}