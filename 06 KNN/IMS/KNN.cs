using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS
{
    internal class KNN
    {

        private Dictionary<List<double>, string> Data;

        public KNN(string file)
        {
            Data = ReadData(file);
        }

        private Dictionary<List<double>, string> ReadData(string file)
        { 
            Dictionary<List<double>, string> data = new Dictionary<List<double>, string>();

            foreach (var item in File.ReadAllLines(file))
            {
                //5.1,3.5,1.4,0.2,setosa
                string[] array = item.Split(',');
                List<double> list = new List<double>();
                for (int i = 0; i < array.Length-1; i++)
                {
                    list.Add(Convert.ToDouble(array[i]));
                }
                data[list] = array[array.Length - 1];
            }

            return data;
        }

        private double CalculateDistance(List<double> p, double[] q)
        {
            if (p.Count != q.Length) throw new Exception("Different lengths!");

            double distance = 0;
            for (int i = 0; i < p.Count; i++)
            {
                distance += Math.Pow(p[i] - q[i], 2);
            }
            return Math.Sqrt(distance);
        }

        public string Classify(double[] features)
        {
            double minDistance = int.MaxValue;
            string prediction = null;

            foreach (var item in Data)
            {
                double distance = CalculateDistance(item.Key, features);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    prediction = item.Value;
                }
            }

            return prediction;
        }
    }
}
