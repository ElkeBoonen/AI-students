using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMax___DSPS
{
    class MinMax
    {
        int[] _values;
        int _height;

        public MinMax(int[] values)
        {
            _values = values;
            _height = (int)Math.Log(values.Length, 2);
        }

        // start with minmax.Solve(0, 0, true)
        public int Solve(int depth, int index, bool isMax)
        {
            if (depth == _height) return _values[index];

            if (isMax)
            {
                return Math.Max(Solve(depth+1, index*2,false), Solve(depth+1,index*2+1 ,false));
            }
            else
            {
                return Math.Min(Solve(depth + 1, index * 2, true), Solve(depth + 1, index * 2 + 1, true));

            }
        }
    }
}
