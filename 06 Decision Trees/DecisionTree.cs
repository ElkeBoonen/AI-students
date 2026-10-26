// Les 6 – Decision Trees (cursus H6, p. 49-53)
// STARTCODE – vul blok 1 tot 3 aan. Test telkens met Program.cs.

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

    // Gini = 1 − Σ p²   (p = aandeel van elke klasse in de groep)
    public static double Gini(List<Sample> data)
    {
        // TODO 1a: tel de labels (CountLabels), reken per klasse p = aantal / totaal
        //          en geef 1 − (som van p²) terug. Lege groep? Geef 0 terug.
        return 0;
    }

    // =====================================================================
    // BLOK 2 – Welke vraag eerst?
    // =====================================================================

    // Gini-winst = Gini vóór de splitsing − gewogen Gini na de splitsing
    public static double GiniGain(List<Sample> data, int feature, double threshold)
    {
        // TODO 2a: splits de data (Split is gegeven),
        //          bereken de gewogen Gini van links en rechts (gewicht = aandeel van de groep)
        //          en geef Gini(data) − gewogen Gini terug.
        return 0;
    }

    // Probeer elk kenmerk en elke kandidaat-drempel; onthoud de beste.
    // Kandidaat-drempels = het midden tussen twee opeenvolgende (gesorteerde) waarden.
    public (int Feature, double Threshold, double Gain) BestSplit(List<Sample> data)
    {
        int besteKenmerk = -1;
        double besteDrempel = 0;
        double besteWinst = 0;

        // TODO 2b: voor elk kenmerk f:
        //   1  verzamel de verschillende waarden van kenmerk f, gesorteerd
        //      (tip: data.Select(s => s.Features[f]).Distinct().OrderBy(v => v).ToArray())
        //   2  voor elk paar opeenvolgende waarden: drempel = het midden
        //   3  winst = GiniGain(data, f, drempel)
        //   4  strikt groter dan besteWinst? Onthoud kenmerk, drempel en winst.

        return (besteKenmerk, besteDrempel, besteWinst);
    }

    // =====================================================================
    // BLOK 3 – Recursief bouwen en voorspellen (pseudocode cursus p. 52)
    // =====================================================================

    public void Train(List<Sample> data) => Root = Build(data, 0);

    private Node Build(List<Sample> data, int depth)
    {
        // TODO 3a: volg de pseudocode van cursus p. 52
        //   1  stopcriteria: zuiver (CountLabels(data).Count == 1), depth == MaxDepth
        //      of data.Count < MinSamples  ->  blad met MostFrequent(data)
        //   2  zoek de beste splitsing (BestSplit); winst 0?  ->  blad
        //   3  splits de data (Split)
        //   4  bouw links en rechts met Build(..., depth + 1)  <- recursie
        //   5  geef een knoop terug met FeatureIndex, FeatureThreshold, Left en Right

        return new Node { Label = MostFrequent(data) };   // tijdelijk: de boom is één blad
    }

    public string Predict(double[] x) => Predict(Root!, x);

    private string Predict(Node node, double[] x)
    {
        // TODO 3b: zelfde idee als vorig jaar.
        //   blad?  ->  geef het label terug
        //   anders: x[node.FeatureIndex] <= node.FeatureThreshold  ->  links, anders rechts
        return "?";
    }

    // =====================================================================
    // BONUS
    // =====================================================================

    // BONUS B3 – Entropie = − Σ p · log2(p)   (cursus 6.1, p. 50-51)
    public static double Entropy(List<Sample> data)
    {
        // TODO BONUS: zelfde recept, maar som = Σ p · log2(p) en geef −som terug.
        //          Tip: Math.Log2. Waarom komt log2(0) hier nooit voor?
        return 0;
    }

    // =====================================================================
    // GEGEVEN – niet aanpassen
    // =====================================================================

    // Telt hoe vaak elk label voorkomt (in volgorde van eerste voorkomen).
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

    // Meest voorkomende label. Gelijkspel? Dan wint het label dat eerst voorkomt.
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

    // Links: kenmerk <= drempel (ja)   ·   Rechts: kenmerk > drempel (nee)
    public static (List<Sample> Left, List<Sample> Right) Split(List<Sample> data, int feature, double threshold)
    {
        var left = data.Where(s => s.Features[feature] <= threshold).ToList();
        var right = data.Where(s => s.Features[feature] > threshold).ToList();
        return (left, right);
    }

    public int CountNodes() => CountNodes(Root);

    private static int CountNodes(Node? node) =>
        node == null ? 0 : 1 + CountNodes(node.Left) + CountNodes(node.Right);

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
