using System;
using System.Collections.Generic;
using System.Text;

namespace Pseudo_Random___IMS
{
    public class LGC
    {
        public long r { get; private set; }

        const int a = 214013;
        const int c = 2531011;
        const int m = Int32.MaxValue; //2147483648;

        public LGC()
        {
            r = DateTime.Now.Ticks;
        }

        public int Next()
        {
            //r_(n + 1) = (a∗r_n +c) mod m
            r = ((a * r) + c) % m;
            return (int)Math.Abs(r);
        }

        public int Next(int max)
        {
            //r_(n + 1) = (a∗r_n +c) mod m
            r = ((a * r) + c) % m;
            return (int)Math.Abs(r)%max;
        }



    }
}
