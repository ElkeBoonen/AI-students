using System;

namespace MinMax___DSPS
{
    class Program
    {
        static void Main(string[] args)
        {
            NQueens nqueens = new NQueens(6);
            nqueens.Solve(0);

            MinMax minmax = new MinMax(new int[] { -1, 4, 2, 6, -3, -5, 0, 7 });
            Console.WriteLine(minmax.Solve(0, 0, true));
        }
    }
}
