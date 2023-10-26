using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPS
{
    class KNN
    {
        private Dictionary<double[], string> Data { get; set; }

        public KNN(string file)
        {
            Data = new Dictionary<double[], string>();
            ReadData(file);
        }

        private void ReadData(string file)
        {
            //5,3.6,1.4,0.2,setosa
            foreach (var item in File.ReadAllLines("iris.dat"))
            {
                List<string> strings = item.Split(',').ToList();
                string value = strings[strings.Count - 1];
                strings.RemoveAt(strings.Count - 1);

                double[] features = Array.ConvertAll(strings.ToArray(), Convert.ToDouble);

                Data[features] = value;
            }
        }

        private double CalculateDistance(double[] p, double[] q)
        {
            if (p.Length != q.Length) throw new Exception("Different lenghts!");

            double distance = 0;
            for (int i = 0; i < p.Length; i++)
            {
                distance += Math.Pow(p[i]- q[i], 2);
            }
            return Math.Sqrt(distance);
        }

        public string Classify(double[] array)
        { 
            double minDistance = int.MaxValue;
            string closestClass = null;

            foreach (var item in Data)
            {
                double distance = CalculateDistance(array, item.Key);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestClass = item.Value;
                }
            }
            return closestClass;
        }

        public string Classify(double[] array, int K)
        {
            double minDistance = int.MaxValue;
            string closestClass = null;

            foreach (var item in Data)
            {
                double distance = CalculateDistance(array, item.Key);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestClass = item.Value;
                }
            }
            return closestClass;
        }
    }
}
