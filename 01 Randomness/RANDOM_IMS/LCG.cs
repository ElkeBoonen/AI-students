using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RANDOM_IMS
{
    public class LCG
    {
        //r_n+1 = (a∗r_n + c) mod m
        //a = 214013
        //c = 2531011
        //m = 2^31

        private int r;

        const int a = 214013;
        const int c = 2531011;
        const long m = 2147483648; //Int32.MaxValue;

        public LCG()
        {
            r = (int)DateTime.Now.Ticks;
        }

        public int Next()
        {
            //r_n+1 = (a∗r_n + c) mod m
            r = (int)((a * r + c) % m);
            return r;
        }

        public int Next(int max) // tussen 0 end max-waarde
        {
            return Math.Abs((Next() % max));
        }

    }
}
