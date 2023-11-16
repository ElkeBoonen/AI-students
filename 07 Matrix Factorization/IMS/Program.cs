namespace IMS
{
    class Program
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
            MatrixFactorization fact = new MatrixFactorization(matrix, 3);
            Console.WriteLine(fact.Prediction(0, 2));
            Console.WriteLine(fact.Prediction(2, 2));
        }
    }
}