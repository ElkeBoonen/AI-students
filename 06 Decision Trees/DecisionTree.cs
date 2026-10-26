// Les 6 – Decision Trees (cursus H6, p. 49-53)
// STARTCODE – vul blok 1, 2 en 3 aan. Test telkens met Program.cs.

public class DecisionTree
{
    public string[] FeatureNames { get; }
    public int MaxDepth { get; }
    public int MinSamples { get; }
    public Node? Root { get; private set; }

    public DecisionTree(string[] featureNames, int maxDepth = 3, int minSamples = 2)
    {
        FeatureNames = featureNames;
        MaxDepth = maxDepth;
        MinSamples = minSamples;
    }

    // =====================================================================
    // BLOK 1 – Hoe zuiver is een groep?
    // =====================================================================

    // Gini = 1 − Σ p²
    public static double Gini(List<Sample> data)
    {
        // Stappen:
        // 1  tel de labels met CountLabels(data)
        // 2  per label: p = aantal / data.Count
        // 3  tel alle p² op en geef 1 − die som terug
        return 0;
    }

    // =====================================================================
    // BLOK 2 – De beste vraag
    // =====================================================================

    // Winst = Gini vóór − gewogen Gini na
    public static double GiniGain(List<Sample> data, int feature, double threshold)
    {
        // Stappen:
        // 1  knip de groep in twee met Split(data, feature, threshold)
        // 2  gewogen Gini = (aantal links / totaal) · Gini(links)
        //                 + (aantal rechts / totaal) · Gini(rechts)
        // 3  geef Gini(data) − gewogen Gini terug
        return 0;
    }

    // Probeer elk kenmerk en elke drempel. Onthoud de vraag met de grootste winst.
    public (int Feature, double Threshold, double Gain) BestSplit(List<Sample> data)
    {
        int besteKenmerk = -1;
        double besteDrempel = 0;
        double besteWinst = 0;

        for (int f = 0; f < data[0].Features.Length; f++)
        {
            // alle verschillende waarden van kenmerk f, van klein naar groot (gegeven)
            double[] waarden = data.Select(s => s.Features[f]).Distinct().OrderBy(v => v).ToArray();

            // Stappen:
            // 1  voor elke twee buurwaarden: drempel = het midden
            // 2  winst = GiniGain(data, f, drempel)
            // 3  is de winst groter dan besteWinst? Onthoud kenmerk, drempel en winst.
        }

        return (besteKenmerk, besteDrempel, besteWinst);
    }

    // =====================================================================
    // BLOK 3 – De boom bouwen en voorspellen
    // =====================================================================

    public void Train(List<Sample> data) => Root = Build(data, 0);

    // Pseudocode: cursus p. 52
    private Node Build(List<Sample> data, int depth)
    {
        // Stappen:
        // 1  stoppen? Groep zuiver (CountLabels(data).Count == 1), depth == MaxDepth
        //    of data.Count < MinSamples  ->  geef een blad terug: new Node { Label = MostFrequent(data) }
        // 2  zoek de beste vraag met BestSplit(data). Winst 0?  ->  ook een blad
        // 3  knip de groep in twee met Split
        // 4  geef een knoop terug met FeatureIndex, FeatureThreshold,
        //    Left = Build(links, depth + 1) en Right = Build(rechts, depth + 1)

        return new Node { Label = MostFrequent(data) };   // tijdelijk: de boom is één blad
    }

    public string Predict(double[] x) => Predict(Root!, x);

    private string Predict(Node node, double[] x)
    {
        // Stappen:
        // 1  is node een blad? Geef het label terug
        // 2  anders: x[node.FeatureIndex] <= node.FeatureThreshold?  ->  ga links, anders rechts
        return "?";
    }

    // =====================================================================
    // GEGEVEN – niet aanpassen
    // =====================================================================

    // Telt hoe vaak elk label voorkomt, bv. { "Binge": 3, "Geen binge": 1 }
    public static Dictionary<string, int> CountLabels(List<Sample> data)
    {
        var tellingen = new Dictionary<string, int>();
        foreach (Sample s in data)
        {
            if (tellingen.ContainsKey(s.Label)) tellingen[s.Label]++;
            else tellingen[s.Label] = 1;
        }
        return tellingen;
    }

    // Het label dat het vaakst voorkomt. Gelijkspel? Dan wint het label dat eerst voorkomt.
    public static string MostFrequent(List<Sample> data)
    {
        string beste = "";
        int max = 0;
        foreach (var (label, aantal) in CountLabels(data))
        {
            if (aantal > max) { beste = label; max = aantal; }
        }
        return beste;
    }

    // Knipt de groep in twee. Links: kenmerk <= drempel (ja). Rechts: kenmerk > drempel (nee).
    public static (List<Sample> Left, List<Sample> Right) Split(List<Sample> data, int feature, double threshold)
    {
        var left = data.Where(s => s.Features[feature] <= threshold).ToList();
        var right = data.Where(s => s.Features[feature] > threshold).ToList();
        return (left, right);
    }

    // Print de boom op het scherm.
    public void Print()
    {
        if (Root == null) Console.WriteLine("(nog geen boom: roep eerst Train op)");
        else Print(Root, "", "");
    }

    private void Print(Node node, string indent, string prefix)
    {
        if (node.IsLeaf)
        {
            Console.WriteLine($"{indent}{prefix}Blad: {node.Label}");
            return;
        }

        Console.WriteLine($"{indent}{prefix}{FeatureNames[node.FeatureIndex]} <= {node.FeatureThreshold:0.##}?");
        string dieper = indent + new string(' ', prefix.Length);
        Print(node.Left!, dieper, "ja  --> ");
        Print(node.Right!, dieper, "nee --> ");
    }
}
