using System;
using System.Collections.Generic;
using System.Text;

namespace MINMAX___DSPS
{
    class MinMax
    {
        private int[] _array;

        public MinMax(int[] array)
        {
            _array = array;
        }

        public int Solve(bool isMax, int index=0, int depth=0)
        {
            if (depth == (int) Math.Log(_array.Length, 2)) return _array[index];

            if (isMax)
            {
                return Math.Max(Solve(false, index * 2, depth + 1), Solve(false, index * 2 + 1, depth + 1));
            }
            return Math.Min(Solve(true, index * 2, depth + 1), Solve(true, index * 2 + 1, depth + 1));
        }
    }
}
