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
        { }

        public string Classify(double[] array)
        { 
        
        }
    }
}
