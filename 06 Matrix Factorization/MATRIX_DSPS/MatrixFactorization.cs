
namespace MATRIX_DSPS
{
    internal class MatrixFactorization
    {
        int[,] userItemMatrix;
        int nUsers;
        int nItems;
        int nFactors = 2;
        const double learningRate = 0.01;
        const int maxIterations = 1000;

        public double[,] userFactors { get; private set; }
        public double[,] itemFactors { get; private set; }

        public MatrixFactorization(int[,] matrix, int factors)
        {
            userItemMatrix = matrix;
            nFactors = factors;
            nUsers = userItemMatrix.GetLength(0);
            nItems = userItemMatrix.GetLength(1);
            Create();
        }

        private void Initialize()
        {
            userFactors = new double[nUsers, nFactors];
            itemFactors = new double[nFactors, nItems];

            Random rand = new Random();
            for (int i = 0; i < nUsers; i++)
            {
                for (int j = 0; j < nFactors; j++)
                {
                    userFactors[i,j] = rand.NextDouble();
                }
            }

            for (int i = 0; i < nFactors; i++)
            {
                for (int j = 0; j < nItems; j++)
                {
                    itemFactors[i, j] = rand.NextDouble();
                }
            }
        }


        private void Create()
        {
            Initialize();
            for (int iterations = 0; iterations < maxIterations; iterations++)
            {
                for (int i = 0; i < nUsers; i++)
                {
                    for (int j = 0; j < nItems; j++)
                    {
                        if (userItemMatrix[i, j] > 0)
                        {
                            double prediction = 0;
                            for (int k = 0; k < nFactors; k++)
                            {
                                prediction += userFactors[i, k] * itemFactors[k, j];
                            }

                            double error = userItemMatrix[i, j] - prediction;

                            for (int k = 0; k < nFactors; k++)
                            {
                                userFactors[i, k] += learningRate * (2 * error * itemFactors[k, j]);
                                itemFactors[k, j] += learningRate * (2 * error * userFactors[i, k]);
                            }
                        
                        }
                    }
                }
            }
        }


        public double[,] Prediction()
        {
            double[,] prediction = new double[nUsers, nItems];
            for (int i = 0; i < nUsers; i++)
            {
                for (int j = 0; j < nItems; j++)
                {
                    for (int k = 0; k < nFactors; k++)
                    {
                        prediction[i, j] += userFactors[i, k] * itemFactors[k, j];      
                    }
                }
            }
            return prediction;
        }

        public double Prediction(int user, int item)
        {
            double predict = 0;
            for (int k = 0; k < nFactors; k++)
            {
                predict += userFactors[user, k] * itemFactors[k, item];
            }
            return predict;
        }
    }
    
}