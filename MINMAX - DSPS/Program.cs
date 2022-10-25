using System;

namespace MINMAX___DSPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MinMax minmax = new MinMax(new int[] { -1, 4, 2, 6, -3, -5, 0, 7 });
            Console.WriteLine(minmax.Solve(true));
        }
    }
}
