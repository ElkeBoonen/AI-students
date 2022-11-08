using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace KNN___IMS
{
    public class KNN
    {
        public Dictionary<double[],string> Data { get; set; }

        public KNN(string[] data)
        {
            Data = new Dictionary<double[], string>();
            ReadData(data);
        }

        private void ReadData(string[] data)
        {
            foreach (var item in data)
            {
                string[] array = item.Split(',');
                double[] values = new double[array.Length-1];
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = Convert.ToDouble(array[i]);
                }
                Data.Add(values, array[array.Length-1]); //^1 laatste element array
            }
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

        public string FindCLosest(double[] test)
        {
            double smallest = int.MaxValue;
            string result = string.Empty;

            foreach (var item in Data)
            {
                double distance = Distance(test, item.Key);
                if (distance < smallest)
                {
                    smallest = distance;
                    result = item.Value;
                }
            }
            return result;
        }

        public string FindCLosest(double[] test, int K)
        {
            SortedDictionary<double, string> distances = new SortedDictionary<double, string>();

            foreach (var item in Data)
            {
                double distance = Distance(test, item.Key);
                distances[Distance(test, item.Key)] = item.Value;
            }

            Dictionary<string, int> result = new Dictionary<string, int>();
            for (int i = 0; i < K; i++)
            {
                string group = distances.ElementAt(i).Value;
                if (!result.ContainsKey(group)) result.Add(group, 0);
                result[group]++;
            }

            result.OrderBy(x => x.Value);
            return result.ElementAt(0).Key;

        }
    }
}
