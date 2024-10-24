namespace MATRIX_DSPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,]
              {
                {5, 0, 4, 0, 0},
                {0, 3, 0, 0, 5},
                {4, 0, 0, 4, 4},
                {0, 0, 5, 0, 0}
              };
            MatrixFactorization fact = new MatrixFactorization(matrix, 2);
            Console.WriteLine(fact.Prediction(0, 2) + "\n\n");

            double[,] predictionmatrix = fact.Prediction();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(predictionmatrix[i, j].ToString("#.##") + "\t");
                }
                Console.WriteLine();
            }

        }
    }
}
