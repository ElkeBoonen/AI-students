using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN___IMS
{
    class Matrix
    {
        public static string ToString(double[,] matrix)
        {
            string s = "";
            int rowlength = matrix.GetLength(0);
            int collength = matrix.GetLength(1);

            for (int row = 0; row < rowlength; row++)
            {
                for (int col = 0; col < collength; col++)
                {
                    s = s + matrix[row, col] + "\t";
                }
                s = s + "\n";
            }
            return s;
        }

        public static double[,] Add(double[,] matrixA, double[,] matrixB)
        {
            if (matrixA.GetLength(0) != matrixB.GetLength(0) ||
                matrixA.GetLength(1) != matrixB.GetLength(1))
                throw new Exception("Lengths are not equal!");

            double[,] matrix = new double[matrixA.GetLength(0), matrixA.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    matrix[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }
            return matrix;
        }

        public static double[,] Subtract(double[,] matrixA, double[,] matrixB)
        {
            if (matrixA.GetLength(0) != matrixB.GetLength(0) ||
                matrixA.GetLength(1) != matrixB.GetLength(1))
                throw new Exception("Lengths are not equal!");

            double[,] matrix = new double[matrixA.GetLength(0), matrixA.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    matrix[i, j] = matrixA[i, j] - matrixB[i, j];
                }
            }
            return matrix;
        }

        public static double[,] Multiplication(double[,] matrixA, double[,] matrixB)
        {
            if (matrixA.GetLength(0) != matrixB.GetLength(0) ||
                matrixA.GetLength(1) != matrixB.GetLength(1))
                throw new Exception("Lengths are not equal!");

            double[,] matrix = new double[matrixA.GetLength(0), matrixA.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    matrix[i, j] = matrixA[i, j] * matrixB[i, j];
                }
            }
            return matrix;
        }

        public static double[,] Transpose(double[,] matrix)
        {
            double[,] transposed = new double[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    transposed[i, j] = matrix[j, i];
                }
            }
            return transposed;
        }

        public static double[,] DotProduct(double[,] m1, double[,] m2)
        { 
            if (m1.GetLength(1)!=m2.GetLength(0))
                throw new Exception("Lengths are not equal!");

            double[,] matrix = new double[m1.GetLength(0), m2.GetLength(1)];

            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m2.GetLength(1); j++)
                {
                    double getal = 0;
                    for (int p = 0; p < m1.GetLength(1); p++)
                    {
                        getal = getal + m1[i, p] * m2[p, j];
                    }
                    matrix[i, j] = getal;
                }
            }
            return matrix;
        }
    }
}
