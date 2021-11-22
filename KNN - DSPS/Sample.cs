using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN___DSPS
{
    class Sample
    {
        public string Classname { get; set; }
        public List<double> Features { get; set; }

        public Sample(string classname)
        {
            Classname = classname;
            Features = new List<double>();
        }
    }
}
