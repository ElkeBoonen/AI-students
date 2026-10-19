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
            // TODO
            return 0;
        }

        // Manhattan: som van |p[i] - q[i]|   (tip: Math.Abs)
        public double Manhattan(double[] p, double[] q)
        {
            // TODO
            return 0;
        }

        // ===== BLOK 2 =====================================================

        public string Classify(double[] point, int k)
        {
            // Stap 1: twee arrays: de afstanden en de punten zelf
            double[] distances = new double[data.Count];
            double[][] points = new double[data.Count][];

            // Stap 2: vul ze met een foreach over data.Keys (hou zelf een teller i bij)
            // TODO

            // Stap 3: sorteer beide arrays tegelijk op afstand (staat er al)
            Array.Sort(distances, points);

            // Stap 4: toon de k dichtste buren, bv. "47  440  -> romantiek (afstand 30.48)"
            //         het label van een punt vind je met data[points[i]]
            // TODO

            // Stap 5: tel de labels van de eerste k buren in een Dictionary<string, int>
            // TODO

            // Stap 6: geef het label met de hoogste telling terug
            // TODO
            return "";
        }

        // ===== BLOK 3 =====================================================

        // Zoek per kenmerk de kleinste en grootste waarde in data
        // en schaal daarna alle data naar [0, 1]:  (waarde - min) / (max - min)
        public void Normalize()
        {
            int n = data.Keys.First().Length;   // aantal kenmerken
            min = new double[n];
            max = new double[n];

            // TODO: vul min en max
            // TODO: schaal elke waarde in data (foreach over data.Keys)
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
