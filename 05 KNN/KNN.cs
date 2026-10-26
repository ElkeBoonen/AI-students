using System.Diagnostics.CodeAnalysis;

namespace _05_KNN
{
    internal class KNN
    {
        Dictionary<double[], string> data;
        double[] min;
        double[] max;

        public KNN(string file)
        {
            //19,520,actie

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

        // ===== BLOK 1 =====================================================

        // Euclidisch: wortel van de som van (p[i] - q[i])²
        public double Distance(double[] p, double[] q)
        {
            if (p.Length != q.Length) throw new Exception("Dit is niet ok! P & q moeten van zelfde lengte zijn! ");
            double afstand = 0;

            for (int i =0; i < p.Length; i++)
            {
                afstand += Math.Pow(p[i]-q[i],2);
            }
            return Math.Sqrt(afstand);
        }

        // Manhattan: som van |p[i] - q[i]|   (tip: Math.Abs)
        public double Manhattan(double[] p, double[] q)
        {
            if (p.Length != q.Length) throw new Exception("Dit is niet ok! P & q moeten van zelfde lengte zijn! ");
            double afstand = 0;

            for (int i =0; i < p.Length; i++)
            {
                afstand += Math.Abs(p[i]-q[i]);
            }
            return afstand;
        }

        // ===== BLOK 2 =====================================================

        public string Classify(double[] point, int k)
        {
            // Stap 1: twee arrays: de afstanden en de punten zelf
            double[] distances = new double[data.Count];
            double[][] points = new double[data.Count][];

            // Stap 2: vul ze met een foreach over data.Keys (hou zelf een teller i bij)
            int teller = 0;
            foreach (double[] p in data.Keys)
            {
                distances[teller] = Distance(p, point);
                points[teller] = p;
                teller++;
            }

            // Stap 3: sorteer beide arrays tegelijk op afstand (staat er al)
            Array.Sort(distances, points);

            // Stap 4: toon de k dichtste buren, bv. "47  440  -> romantiek (afstand 30.48)"
            //         het label van een punt vind je met data[points[i]]
            Dictionary<string, int> labels = new Dictionary<string, int>();

            for (int i =0; i < k; i++)
            {
                Console.WriteLine(String.Join(" ",points[i]) + " --> " +  data[points[i]] + " met afstand " + distances[i]);
                string label = data[points[i]];
                if (!labels.ContainsKey(label)) labels[label] = 0;
                labels[label]++;
            }

            // Stap 6: geef het label met de hoogste telling terug
            return labels.OrderByDescending(x => x.Value).First().Key;
        }

        // ===== BLOK 3 =====================================================

        // Zoek per kenmerk de kleinste en grootste waarde in data
        // en schaal daarna alle data naar [0, 1]:  (waarde - min) / (max - min)
        public void Normalize()
        {
            int n = data.Keys.First().Length;   // aantal kenmerken
            min = new double[n];
            max = new double[n];

            for (int i = 0; i < n; i++)
            {
                min[i] = Double.MaxValue;
                max[i] = Double.MinValue;

                foreach (double[] p in data.Keys)
                {
                    if (p[i] < min[i]) min[i] = p[i];
                    if (p[i] > max[i]) max[i] = p[i];
                }
            }
            
            foreach (double[] p in data.Keys)
            {
                for (int i = 0; i < n; i++)
                {
                    p[i] = (p[i] - min[i]) / (max[i] - min[i]);
                }
            }
        }

        // Schaal een nieuw punt met dezelfde min en max
        public double[] Scale(double[] point)
        {
            // TODO: maak een nieuwe array en schaal elke waarde
            return point;
        }

        // ===== BLOK 4 =====================================================

        // Cosine: (som van p[i] * q[i]) / (wortel(som p[i]²) * wortel(som q[i]²))
        public double Cosine(double[] p, double[] q)
        {
            // TODO
            return 0;
        }
    }
}
