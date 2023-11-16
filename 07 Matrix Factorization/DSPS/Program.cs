namespace DSPS
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
            MatrixFactorization fact = new MatrixFactorization(matrix, 10);
            Console.WriteLine(fact.Prediction(0, 2));

            for (int i = 0; i < fact.userFactors.GetLength(0); i++)
            {
                for (int j = 0; j < fact.userFactors.GetLength(1); j++)
                {
                    Console.Write(fact.userFactors[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}