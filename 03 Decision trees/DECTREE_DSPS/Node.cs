using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECTREE_DSPS
{
    internal class Node
    {
        public double Threshold { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int? Label { get; set; }
    }
}
