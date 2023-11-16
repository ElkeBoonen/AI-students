﻿namespace DSPS
{
    class MatrixFactorization
    {
        int[,] userItemMatrix;
        int nUsers;
        int nItems;
        int nFactors;
        const double learningRate = 0.01;
        const int maxIterations = 10000;

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

        private void Create()
        {
            userFactors = new double[nUsers, nFactors];
            itemFactors = new double[nFactors, nItems];

            Random random = new Random();
            for (int i = 0; i < nUsers; i++)
            {
                for (int j = 0; j < nFactors; j++)
                {
                    userFactors[i, j] = random.NextDouble();
                }
            }

            for (int i = 0; i < nFactors; i++)
            {
                for (int j = 0; j < nItems; j++)
                {
                    itemFactors[i, j] = random.NextDouble();
                }
            }

            for (int m = 0; m < maxIterations; m++)
            {
                //looping over ratings
                for (int i = 0; i < nUsers; i++)
                {
                    for (int j = 0; j < nItems; j++)
                    {
                        //check if there is a rating
                        if (userItemMatrix[i, j] > 0)
                        {
                            //make a prediction!
                            double prediction = 0;
                            for (int k = 0; k < nFactors; k++)
                            { 
                                prediction += userFactors[i,k] * itemFactors[k,j];
                            }

                            double error = userItemMatrix[i, j] - prediction;

                            //update values
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
    }
}