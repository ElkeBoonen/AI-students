
namespace _04_KNN
{
    internal class KNN
    {
        Dictionary<double[], string> data;

        public KNN(string file)
        {
            //5.1,3.5,1.4,0.2,setosa

            data = new Dictionary<double[], string>();

            foreach (string line in File.ReadAllLines(file))
            {
                string[] parts = line.Split(',');
                double[] features = new double[parts.Length - 1];
                for (int i = 0; i < features.Length; i++)
                {
                    features[i] = double.Parse(parts[i]);
                }
                data[features] = parts.Last();
            }
        }

        private double Distance(double[] p, double[] q)
        {
            double result = 0;
            for (int i = 0; i < p.Length; i++)
            {
                result += Math.Pow(p[i] - q[i], 2);
            }
            return Math.Sqrt(result);
        }

        public string Classify(double[] doubles)
        {
            Dictionary<double, string> distances = new Dictionary<double, string>();

            foreach (var item in data)
            {
                double distance = Distance(doubles, item.Key);
                distances[distance] = item.Value;
            }

            double min = Double.MaxValue;
            string result = "";
            foreach (var item in distances)
            {
                if (min > item.Key)
                {
                    min = item.Key;
                    result = item.Value;
                }
            }

            return result + " " + min;

        }
    }
}