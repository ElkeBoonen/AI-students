
namespace KNN_DSPS
{
    internal class KNN
    {
        private string file;
        Dictionary<double[], string> data;

        public KNN(string filename)
        {
            this.file = filename;
            data = ReadData();
        }

        private Dictionary<double[], string> ReadData()
        {
            Dictionary<double[], string> data = new Dictionary<double[], string>();
            foreach (string line in File.ReadAllLines(file))
            {
                string[] items = line.Split(',');

                string value = items[items.Length-1]; //index
                double[] features = new double[items.Length-1]; //length
                for (int i = 0; i < features.Length; i++)
                {
                    features[i] = double.Parse(items[i]);
                }
                data[features] = value;
                //Console.WriteLine(String.Join(" ", features) + " --> " + value);
            }
            return data;
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

        internal string Classify(double[] doubles)
        {
            double minDistance = Double.MaxValue;
            string value = "";

            foreach (var item in data)
            {
                double distance = Distance(item.Key, doubles);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    value = item.Value;
                }
            }
            return value;
        }

        internal string Classify(double[] doubles, int k)
        {
            Dictionary<double, string> distances = new Dictionary<double, string>();

            foreach (var item in data)
            {
                double distance = Distance(item.Key, doubles);
                distances[distance] = item.Value;
            }

            var dist_order = distances.OrderBy(item => item.Key);
            foreach (var item in dist_order)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            return "";
        }
    }
}