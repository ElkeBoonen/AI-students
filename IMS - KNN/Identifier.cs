using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS___KNN
{
    class Identifier
    {
        public string Class { get; set; }
        public List<double> Features { get; set; }

        public Identifier(string className)
        {
            Class = className;
            Features = new List<double>();
        }

        public override string ToString()
        {
            string s = "";
            s += Class;
            foreach (var item in Features)
            {
                s += item + " ";
            }
            return s;
        }
    }
}
