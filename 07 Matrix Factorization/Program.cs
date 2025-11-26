namespace _07_Matrix_Factorization
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

            Console.WriteLine();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(Math.Round(fact.Prediction(i, j), 3) + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine(fact.Prediction(0, 0));
            Console.WriteLine(fact.Prediction(0, 1));

        }
    }
}
