// Les 6 – Decision Trees
// Elke test print het resultaat naast de verwachte waarde.
// Methodes die nog niet af zijn, geven 0 of "?" terug: het programma crasht niet.

using System.Globalization;

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

// Binge-watchen (cursus 6.3.3)   Genre: 0 = Drama, 1 = SF   ·   Tempo: 0 = Traag, 1 = Snel
var binge = new List<Sample>
{
    new([1, 1], "Binge"),        // 1  SF     Snel
    new([1, 1], "Binge"),        // 2  SF     Snel
    new([1, 0], "Binge"),        // 3  SF     Traag
    new([1, 0], "Geen binge"),   // 4  SF     Traag
    new([0, 1], "Binge"),        // 5  Drama  Snel
    new([0, 1], "Geen binge"),   // 6  Drama  Snel
    new([0, 0], "Geen binge"),   // 7  Drama  Traag
    new([0, 0], "Geen binge"),   // 8  Drama  Traag
};

// Zes klanten uit les 5: leeftijd, kijkminuten per week
var klanten = new List<Sample>
{
    new([19, 520], "actie"),      // Lotte
    new([21, 260], "actie"),      // Emma
    new([27, 640], "actie"),      // Yusuf
    new([47, 440], "romantiek"),  // Marc
    new([58, 410], "romantiek"),  // Rita
    new([52, 390], "romantiek"),  // Hilde
};

// ---------------------------------------------------------------------
Console.WriteLine("===== BLOK 1 – Gini =====");
// ---------------------------------------------------------------------
Check("Groep A: alle 8 (4 – 4)", DecisionTree.Gini(binge), "0.5");
Check("Groep B: SF (3 – 1)", DecisionTree.Gini(binge.Take(4).ToList()), "0.375");
Check("Groep C: zuiver (2 – 0)", DecisionTree.Gini(binge.Take(2).ToList()), "0");

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 2 – De beste vraag =====");
// ---------------------------------------------------------------------
Check("Winst Genre", DecisionTree.GiniGain(binge, 0, 0.5), "0.125");
Check("Winst Tempo", DecisionTree.GiniGain(binge, 1, 0.5), "0.125");
Check("Winst leeftijd <= 24", DecisionTree.GiniGain(klanten, 0, 24), "0.25");
Check("Winst leeftijd <= 37", DecisionTree.GiniGain(klanten, 0, 37), "0.5");

var leeg = new DecisionTree(new[] { "x", "y" });
CheckSplit("Beste vraag binge", leeg.BestSplit(binge), "(0, 0.5, 0.125)");
CheckSplit("Beste vraag klanten", leeg.BestSplit(klanten), "(0, 37, 0.5)");

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 3 – De boom bouwen =====");
// ---------------------------------------------------------------------
var boomKlanten = new DecisionTree(new[] { "Leeftijd", "Minuten" }, maxDepth: 3);
boomKlanten.Train(klanten);
boomKlanten.Print();
Console.WriteLine($"Nieuwe klant (24 jaar, 420 min) --> {boomKlanten.Predict([24, 420])}   verwacht: actie\n");

var boomBinge = new DecisionTree(new[] { "Genre", "Tempo" }, maxDepth: 2);
boomBinge.Train(binge);
boomBinge.Print();

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 4 – Hoe diep? =====");
// ---------------------------------------------------------------------
List<Sample> iris = LoadCsv("iris.csv");
var test = iris.Where((s, i) => i % 3 == 0).ToList();    // 50 bloemen om te testen
var train = iris.Where((s, i) => i % 3 != 0).ToList();   // 100 bloemen om te trainen
string[] irisKenmerken = { "kelkblad_lengte", "kelkblad_breedte", "kroonblad_lengte", "kroonblad_breedte" };
double[] bloem = { 6.1, 2.8, 4.9, 1.7 };                   // de bloem uit les 5 (kNN: virginica)

Console.WriteLine("maxDepth  train   test   bloem uit les 5");
for (int d = 1; d <= 6; d++)
{
    var boom = new DecisionTree(irisKenmerken, maxDepth: d);
    boom.Train(train);
    Console.WriteLine($"{d,8}  {Accuracy(boom, train),5:P0}  {Accuracy(boom, test),5:P0}   {boom.Predict(bloem)}");
}

// BONUS B1: print de iris-boom met maxDepth 2. Welke kenmerken gebruikt hij?
// BONUS B2: vermenigvuldig in 'klanten' de minuten met 1000. Verandert de boom?
// BONUS B3: schrijf Entropy (onderaan DecisionTree.cs). Verwacht: alle 8 → 1, SF → 0.811, zuiver → 0.

// ---------------------------------------------------------------------
// Hulpfuncties – niet aanpassen
// ---------------------------------------------------------------------
static void Check(string wat, double resultaat, string verwacht) =>
    Console.WriteLine($"{wat,-28} {resultaat:0.###}   verwacht: {verwacht}");

static void CheckSplit(string wat, (int Feature, double Threshold, double Gain) s, string verwacht) =>
    Console.WriteLine($"{wat,-28} ({s.Feature}, {s.Threshold:0.##}, {s.Gain:0.###})   verwacht: {verwacht}");

static double Accuracy(DecisionTree boom, List<Sample> data) =>
    (double)data.Count(s => boom.Predict(s.Features) == s.Label) / data.Count;

static List<Sample> LoadCsv(string pad)
{
    var data = new List<Sample>();
    foreach (string lijn in File.ReadLines(pad).Skip(1))
    {
        string[] delen = lijn.Split(',');
        double[] kenmerken = delen[..^1].Select(v => double.Parse(v, CultureInfo.InvariantCulture)).ToArray();
        data.Add(new Sample(kenmerken, delen[^1]));
    }
    return data;
}
