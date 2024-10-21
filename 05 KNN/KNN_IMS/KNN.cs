
namespace KNN_IMS
{
    internal class KNN
    {
        List<double[]> data = new List<double[]>();
        List<string> labels = new List<string>();

        public KNN(string filename)
        {
            foreach (string line in File.ReadAllLines(filename))
            {
                string[] items = line.Split(',');
                double[] array = new double[items.Length-1]; //lengte van array

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = double.Parse(items[i]);
                }
                data.Add(array);
                labels.Add(items[items.Length - 1]); //index van laatste 

                //Console.WriteLine(String.Join(" ", array));
            }
        }

        private double Distance(double[] p, double[] q)
        { 
            double sum = 0;
            for (int i = 0; i < p.Length; i++)
            {
                sum += Math.Pow(p[i] - q[i],2);
            }
            return Math.Sqrt(sum);
        
        }

        internal string Classify(double[] doubles)
        {
            double minDistance = Double.MaxValue;
            string label = "";
            for (int i = 0; i < data.Count; i++)
            {
                double distance = Distance(data[i], doubles);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    label = labels[i];
                }
            }
            return label;
        }
    }
}