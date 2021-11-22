using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN___DSPS
{
    class KNN
    {
        private List<Sample> _sampledata { get; set; }

        public KNN()
        {
            _sampledata = new List<Sample>();
        }

        public void ReadFile(string filename)
        {
            foreach (var item in System.IO.File.ReadLines(filename))
            {
                string[] elements = item.Split(',');
                Sample sample = new Sample(elements[elements.Length-1]);
                for (int i = 0; i < elements.Length-1; i++)
                {
                    sample.Features.Add(Convert.ToDouble(elements[i]));
                }
                _sampledata.Add(sample);
            }
        }

        private double Distance(double[] p, double[] q)
        {
            if (p.Length != q.Length) throw new Exception("Not same length!");

            double d = 0;
            for (int i = 0; i < p.Length; i++)
            {
                d += Math.Pow(p[i] - q[i], 2);
            }
            return Math.Sqrt(d);
        }

        public string Classify(double[] features)
        {
            double smallest = Double.MaxValue;
            string classname = "";
            foreach (Sample item in _sampledata)
            {
                double d = Distance(features, item.Features.ToArray());
                if (d < smallest)
                {
                    smallest = d;
                    classname = item.Classname;
                }
            }
            return classname;
        }
    }
}
