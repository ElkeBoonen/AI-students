using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KNN___DSPS
{
    class KNN
    {
        public Dictionary<List<double>, string> Data { get; set; }

        private void ReadDate(string filename)
        {
            foreach (string item in File.ReadAllLines(filename))
            {
                string[] split = item.Split(',');
                List<double> data = new List<double>();
                for (int i = 0; i < split.Length-1; i++)
                {
                    data.Add(Convert.ToDouble(split[i]));
                }
                Data.Add(data, split.Last()); //= ^1 = split.Length-1
            }
        }
        public KNN(string filename)
        {
            Data = new Dictionary<List<double>, string>();
            ReadDate(filename);
        }

        private double Distance(double[] p, double[] q)
        {
            double distance = 0;
            for (int i = 0; i < p.Length; i++)
            {
                distance += Math.Pow(p[i] - q[i], 2);
            }
            return Math.Sqrt(distance);
        }

        public string Find(double[] testdata)
        {
            double smallest = int.MaxValue;
            string group = string.Empty;
            foreach (var item in Data)
            {
                double distance = Distance(testdata, item.Key.ToArray());
                if (distance < smallest)
                { 
                    smallest = distance;
                    group = item.Value;
                }
            }
            return group;
        }

        public string Find(double[] testdata, int K)
        {
            SortedDictionary<double, string> distances = new SortedDictionary<double, string>();
            foreach (var item in Data)
            {
                distances[Distance(testdata, item.Key.ToArray())] = item.Value;
            }

            Dictionary<string, int> count = new Dictionary<string, int>();
            for (int i = 0; i < K; i++)
            {
                string group = distances.ElementAt(i).Value;
                if (!count.ContainsKey(group)) count.Add(group, 1);
                else count[group]++;
            }

            count.OrderBy(x => x.Value);

            return count.ElementAt(0).Key;
        }

    }
}
