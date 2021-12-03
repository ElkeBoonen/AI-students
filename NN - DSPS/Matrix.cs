using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN___DSPS
{
    class Matrix
    {
        public static string ToString(double[,] matrix)
        {
            string s = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    s += matrix[i, j] + "\t";
                }
                s += Environment.NewLine;
            }
            return s;
        }

        public static double[,] Sum(double[,] a, double[,] b)
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
                throw new Exception("Not same matrix dimensions!");

            double[,] c = new double[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    c[i, j] = a[i, j] + b[i, j];
                }
            }
            return c;
        }

        public static double[,] Substract(double[,] a, double[,] b)
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
                throw new Exception("Not same matrix dimensions!");

            double[,] c = new double[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    c[i, j] = a[i, j] - b[i, j];
                }
            }
            return c;
        }

        public static double[,] Multiplication(double[,] a, double[,] b)
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
                throw new Exception("Not same matrix dimensions!");

            double[,] c = new double[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    c[i, j] = a[i, j] * b[i, j];
                }
            }
            return c;
        }

        public static double[,] Transpose(double[,] matrix)
        { 
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);

            double[,] newmatrix = new double[height, width];
            for (int i = 0; i < width; i++)
			{
                for (int j = 0; j < height; j++)
			    {
                    newmatrix[j,i] = matrix[i,j];
			    }
			}
            return newmatrix;
        }

        public static double[,] DotProduct(double[,] a, double[,] b)
        { 
            if (a.GetLength(1) != b.GetLength(0))
                throw new Exception("Not same matrix dimensions!");

            double[,] result = new double[a.GetLength(0), b.GetLength(1)];

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    for (int k = 0; k < a.GetLength(1); k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }
    }
}
