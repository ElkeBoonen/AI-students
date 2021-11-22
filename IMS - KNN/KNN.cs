using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IMS___KNN
{
    class KNN
    {
        List<Identifier> _training;

        public KNN()
        {
            _training = new List<Identifier>();
        }

        public void ReadData(string filename)
        {
            StreamReader reader = File.OpenText(filename);
            string[] line;
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine().Split(',');
                Identifier identifier = new Identifier(line[line.Length-1]);
                for (int i = 0; i < line.Length-1; i++)
                {
                    identifier.Features.Add(Convert.ToDouble(line[i]));
                }
                _training.Add(identifier);
            }
            reader.Close();
        }

        private double Distance(double[] p, double[] q)
        {
            if (p.Length != q.Length) throw new Exception("Dees kan niet!");
            double distance = 0;

            for (int i = 0; i < p.Length; i++)
            {
                distance += Math.Pow(p[i] - q[i], 2);
            }
            return Math.Sqrt(distance);
        }

        //test 6.1,2.6,5.6,1.4,virginica
        public string Test(double[] features)
        {
            Dictionary<double, string> distances = new Dictionary<double, string>();
            foreach (var item in _training)
            {
                double distance = Distance(features, item.Features.ToArray());
                distances[distance] = item.Class;
            }

            double min = distances.Keys.Min();
            return distances[min];
        }
    }
}
