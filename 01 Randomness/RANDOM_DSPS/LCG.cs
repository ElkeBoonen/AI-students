using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RANDOM_DSPS
{
    internal class LCG
    {
        // r_n+1 =(a∗r_n +c) mod m
        // In rand()-function from the Microsoft C runtime a = 214013, c = 2531011, m = 2^31
        const int a = 214013;
        const int c = 2531011;
        const double m = 2147483648;

        private int r = 0;

        public LCG()
        {
            r = (int)DateTime.Now.Ticks;
        }

        public int Next()
        {
            r = (int)((a * r + c ) % m);
            return r;
        }

        public int Next(int max) // from 0 to max
        {
            r = (int)((a * r + c) % m);
            return Math.Abs(r % max);
        }
    }
}
