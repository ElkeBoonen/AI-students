namespace IMS_ANN
{
    internal class ANN
    {
        private double[,] training_input;
        private double[,] training_output;

        private const int epochs = 10000;
        public double[,] Weights { get; internal set; }

        private void FillWeights()
        {
            Random rd = new Random();
            Weights = new double[training_input.GetLength(1), 1];
            for (int i = 0; i < Weights.GetLength(0); i++)
            {
                Weights[i, 0] = rd.NextDouble()*2-1;
            }
        }

        public ANN(double[,] training_input, double[,] training_output)
        {
            this.training_input = training_input;
            this.training_output = training_output;
            FillWeights();
        }

        internal void Train()
        {
            for (int count = 0; count < epochs; count++)
            {
                //step 1 & step 2
                double[,] predictions = Predict(training_input);

                //step 3
                double[,] errors = Matrix.Substract(training_output, predictions);

                //step 4
                double[,] sigmoid_derivative = new double[training_input.GetLength(0), 1];
                for (int i = 0; i < sigmoid_derivative.GetLength(0); i++)
                {
                    sigmoid_derivative[i, 0] = predictions[i, 0] * (1 - predictions[i, 0]);
                }

                //step 5
                double[,] multiply = Matrix.Multiplication(errors, sigmoid_derivative);

                //step 6
                double[,] adjustments = Matrix.DotProduct(Matrix.Transpose(training_input), multiply);

                //step 7
                Weights = Matrix.Sum(adjustments, Weights);

            }
        }

        private double Sigmoid(double value)
        {
            return 1 / (1 + Math.Pow(Math.E, -value)); //Math.Exp(-value);

        }

        internal double[,] Predict(double[,] doubles)
        {
            double[,] dotproduct = Matrix.DotProduct(doubles, Weights);
            for (int i = 0; i < dotproduct.GetLength(0); i++)
            {
                dotproduct[i, 0] = Sigmoid(dotproduct[i, 0]);
            }
            return dotproduct;
        }

        
    }
}