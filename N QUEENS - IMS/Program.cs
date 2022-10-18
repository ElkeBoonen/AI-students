using System;

namespace N_QUEENS___IMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NQueens queens = new NQueens(10);
            queens.Solve();

        }
    }
}
