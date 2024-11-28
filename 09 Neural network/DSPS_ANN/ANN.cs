
namespace DSPS_ANN
{
    internal class ANN
    {
        private double[,] training_input;
        private double[,] training_output;
        internal double[,] Weights { get; private set; }
        public NN(double[,] training_input, double[,] training_output)
        {
            this.training_input = training_input;
            this.training_output = training_output;
            InitializeWeights();
        }

        internal void InitializeWeights()
        {
            double[,] doubles = new double[training_input.GetLength(1),1];
            for (int i = 0; i < doubles.Length; i++)
            {
                doubles[i,0] = new Random().NextDouble() * 2 - 1;
            }

            Weights = doubles;
        }

        internal double[,] Predict(double[,] doubles)
        {
            double[,] dotproducts = Matrix.DotProduct(doubles, Weights);
            return Sigmoid(dotproducts); // Created new function to be able to use this function on Matrices
        }

        internal void Train()
        {
            for(int epochs = 0; epochs <= 1000; epochs++)
            {
                double[,] dotproducts = Matrix.DotProduct(training_input, Weights);
                double[,] multiplications = new double[dotproducts.GetLength(0), 1]; 
                for (int i = 0; i < dotproducts.GetLength(0); i++)
                {

                    double sigmoid = Sigmoid(dotproducts[i, 0]);
                    double error = training_output[i, 0] - sigmoid;
                    double sigmoidDerivative = error * (1 - error);
                    multiplications[i, 0] = error * sigmoid;
                }

                dotproducts = Matrix.DotProduct(Matrix.Transpose(training_input), multiplications);
                Weights = Matrix.Sum(Weights, dotproducts); // There was a mistake here => Matrix.Subtract() was used instead of Matrix.Sum()
            }

        }

        internal double Sigmoid(double value)
        {
            return 1.0 / (1.0 + Math.Pow(Math.E, -value));
        }

        //New function created to be able to use the Sigmoid function with a matrix(2D array) as input;
        internal double[,] Sigmoid(double[,] matrix)
        {
            double[,] sigmoidMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    sigmoidMatrix[i,j] = Sigmoid(matrix[i,j]);
                }
            }

            return sigmoidMatrix;
        }

       
    }
}