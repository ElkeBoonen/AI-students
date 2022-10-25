using System;

namespace N_QUEENS___DSPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NQueens nqueens = new NQueens(8);
            nqueens.Solve();
            Console.WriteLine(nqueens);
        }
    }
}
