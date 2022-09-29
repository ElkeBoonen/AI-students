using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psuedo_Random___DSPS
{
    class PseudoRandom
    {
        const int a = 214013;
        const int c = 2531011;
        const long m = Int64.MaxValue;

        private long r;

        public PseudoRandom()
        {
            r = DateTime.Now.Millisecond;
           //Console.WriteLine(DateTime.Now.Millisecond + " " + DateTime.Now.Ticks);
        }

        public long Next()
        {
            //r_n+1 = (a∗r_n +c) mod m
            r = (a * r + c) % m;
            return Math.Abs(r);
        }

        public long Next(int max)
        {
            //r_n+1 = (a∗r_n +c) mod m
            r = (a * r + c) % m;
            return Math.Abs(r % max);
        }
    }
}
