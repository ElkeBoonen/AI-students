using System;

namespace MinMax___IMS
{
    class Program
    {
        static void Main(string[] args)
        {
            Queens queens = new Queens(4);
            queens.Solve(0);

            MinMax minmax = new MinMax(new int[] { -1, 4, 2, 6, -3, -5, 0, 7 });
            Console.WriteLine(minmax.Solve(0, 0, true));
        }
    }
}
