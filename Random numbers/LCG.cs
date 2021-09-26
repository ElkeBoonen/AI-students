using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_numbers
{
    class LCG
    {
        private int seed { get; set; }

        private const int a = 214013;
        private const int c = 2531011;
        private const int m = Int32.MaxValue; //2147483647
        public LCG()
        {
            seed = (int)DateTime.Now.Ticks;
        }

        public int Next()
        {
            seed = (int)((a*seed + c) % m);
            return seed;
        }

        /*public int Next(int m)
        {
            seed = (int)((a * seed + c) % m);
            return seed;
        }

        public int Next(int m)
        {
            int i = Math.Abs(Next());
            while (i >= m) i /= 10;
            return i;
        }
        */

    }
}
