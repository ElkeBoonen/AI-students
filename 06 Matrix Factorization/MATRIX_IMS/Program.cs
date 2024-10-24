namespace MATRIX_IMS
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
            Console.WriteLine(fact.Prediction(0, 2));

            double[,] prediction = fact.Prediction();
            for (int i = 0; i < prediction.GetLength(0); i++)
            {
                for (int j = 0; j < prediction.GetLength(1); j++)
                {
                    Console.Write($"{prediction[i, j]:F2} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n\n");


            /*  Movie 0: "The Matrix"
                Movie 1: "Inception"
                Movie 2: "Interstellar"
                Movie 3: "The Godfather"
                Movie 4: "Pulp Fiction"
                Movie 5: "The Dark Knight"*/

            int[,] preferenceMatrix = new int[,] 
            { 
                { 5, 0, 4, 0, 0, 5 }, // User 0: Sci-fi fan (Rated "The Matrix", "Interstellar", "The Dark Knight")
                { 0, 5, 0, 0, 4, 5 }, // User 1: Loves complex plots (Rated "Inception", "Pulp Fiction", "The Dark Knight")
                { 4, 0, 4, 5, 5, 0 }, // User 2: Fan of classics and action (Rated "The Matrix", "Interstellar", "The Godfather", "Pulp Fiction")
                { 0, 0, 5, 0, 4, 0 }, // User 3: Sci-fi fan (Rated "Interstellar", "Pulp Fiction")
                { 5, 4, 0, 5, 0, 0 }, // User 4: Thrillers and action (Rated "The Matrix", "Inception", "The Godfather")
                { 4, 5, 5, 0, 0, 5 }, // User 5: Mix of genres (Rated "The Matrix", "Inception", "Interstellar", "The Dark Knight")
                { 0, 0, 4, 5, 0, 4 }, // User 6: Classics fan (Rated "Interstellar", "The Godfather", "The Dark Knight")
                { 5, 5, 0, 0, 0, 5 } // User 7: Modern action fan (Rated "The Matrix", "Inception", "The Dark Knight")
             };

            fact = new MatrixFactorization(preferenceMatrix, 2);
            prediction = fact.Prediction();
            for (int i = 0; i < prediction.GetLength(0); i++)
            {
                for (int j = 0; j < prediction.GetLength(1); j++)
                {
                    Console.Write($"{prediction[i, j]:F2} ");
                }
                Console.WriteLine();
            }





        }
    }
}
