
using System.Transactions;

namespace MATRIX_IMS
{
    class MatrixFactorization
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
            Init();
            Create();
        }

        private void Init() 
        {
            userFactors = new double[nUsers, nFactors];
            itemFactors = new double[nFactors, nItems];

            Random random = new Random();

            for (int i = 0; i < nUsers; i++)
            {
                for (int j = 0; j < nFactors; j++)
                {
                    userFactors[i,j] = random.NextDouble();
                }
            }


            for (int i = 0; i < nFactors; i++)
            {
                for (int j = 0; j < nItems; j++)
                {
                    itemFactors[i, j] = random.NextDouble();
                }
            }
        }

        private void Create()
        {
            for (int x = 0; x < maxIterations; x++)
            {
                for (int i = 0; i < nUsers; i++)
                {
                    for (int j = 0; j < nItems; j++)
                    {
                        if (userItemMatrix[i, j] != 0)
                        {
                            double prediction = Prediction(i, j);
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

        public double Prediction(int user, int item)
        {
            double predict = 0;
            for (int k = 0; k < nFactors; k++)
            {
                predict += userFactors[user, k] * itemFactors[k, item];
            }
            return predict;
        }

        internal double[,] Prediction()
        {
            double[,] prediction = new double[nUsers, nItems];
            for (int i = 0; i < nUsers; i++)
            {
                for (int j = 0; j < nItems; j++)
                {
                    prediction[i, j] = Prediction(i, j);
                }
            }
            return prediction;
        }
    }
}