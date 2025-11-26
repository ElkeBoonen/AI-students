

namespace _07_Matrix_Factorization
{
    class MatrixFactorization
    {
        int[,] userItemMatrix;
        int nUsers;
        int nItems;
        int nFactors = 4;
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
            Initialize();
            Create();
        }

        private void Initialize()
        {
            userFactors = new double[nUsers,nFactors];
            itemFactors = new double[nFactors, nItems];

            Random random = new Random();

            for (int i = 0; i < nUsers; i++)
            {
                for (int j = 0; j < nFactors; j++)
                {
                    userFactors[i,j] = random.NextDouble();
                }
            }

            Print(userFactors);

            for (int i = 0; i < nFactors; i++)
            {
                for (int j = 0; j < nItems; j++)
                {
                    itemFactors[i, j] = random.NextDouble();
                }
            }

            Print(itemFactors);



        }

        private void Create()
        {
            for (int m = 0; m < maxIterations; m++)
            {
                for (int i = 0; i < nUsers; i++)
                {
                    for (int j = 0; j < nItems; j++)
                    {

                        if (userItemMatrix[i, j] > 0)
                        {
                            double predict = Prediction(i, j);
                            double error = userItemMatrix[i,j] - predict;

                            for (int k = 0; k < nFactors; k++)
                            {
                                userFactors[i, k] += learningRate * (2 * error * itemFactors[k, j]);
                                itemFactors[k, j] += learningRate * (2 * error * userFactors[i, k]);
                            }
                        }

                    }

                }
            }

            Print(userFactors);
            Print(itemFactors);

        }

        public void Print(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(Math.Round(matrix[i, j],3) + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

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