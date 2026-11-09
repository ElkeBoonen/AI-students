// Les 7 – Logistic Regression
// Elke test print het resultaat naast de verwachte waarde.
// Methodes die nog niet af zijn, geven 0 terug: het programma crasht niet.

using System.Globalization;

// zodat getallen met een punt verschijnen (0.5), zoals op de slides
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

// Drie e-mails (cursus 7.5.3)   x1 = aantal uitroeptekens   ·   x2 = aantal links
double[] A = { 1, 1 };   // e-mail A
double[] B = { 3, 2 };   // e-mail B
double[] C = { 0, 0 };   // e-mail C

// De spamfilter uit de cursus: w1 = 0.8, w2 = 1.2, b = −3.0
var spamfilter = new LogisticRegression([0.8, 1.2], -3.0);

// ---------------------------------------------------------------------
Console.WriteLine("===== BLOK 1 – De gewogen som =====");
// ---------------------------------------------------------------------
Check("z e-mail A", spamfilter.GewogenSom(A), "-1");
Check("z e-mail B", spamfilter.GewogenSom(B), "1.8");
Check("z e-mail C", spamfilter.GewogenSom(C), "-3");

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 2 – Van som naar kans naar beslissing =====");
// ---------------------------------------------------------------------
Check("Sigmoid(0)", LogisticRegression.Sigmoid(0), "0.5");
Check("Kans spam A", spamfilter.VoorspelKans(A), "0.269");
Check("Kans spam B", spamfilter.VoorspelKans(B), "0.858");
Check("Kans spam C", spamfilter.VoorspelKans(C), "0.047");
Check("Label A", spamfilter.Voorspel(A), "0");
Check("Label B", spamfilter.Voorspel(B), "1");
Check("Label C", spamfilter.Voorspel(C), "0");

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 3 – Leren: één stapje bergaf =====");
// ---------------------------------------------------------------------
// Leeg model (alles 0), leersnelheid 0.1. Labels: B = spam (1), C = geen spam (0).
var leerling = new LogisticRegression(2);
Console.WriteLine($"Start          {leerling}   verwacht: w = (0, 0)  b = 0");
leerling.TrainStap(B, 1, 0.1);
Console.WriteLine($"Na stap op B   {leerling}   verwacht: w = (0.15, 0.1)  b = 0.05");
leerling.TrainStap(C, 0, 0.1);
Console.WriteLine($"Na stap op C   {leerling}   verwacht: w = (0.15, 0.1)  b = -0.001");

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 4 – Echte data: versicolor of virginica? =====");
// ---------------------------------------------------------------------
// Iris uit les 6, zonder setosa: 0 = versicolor, 1 = virginica
List<Sample> iris = LoadIris("iris.csv");
var test = iris.Where((s, i) => i % 3 == 0).ToList();    // om te testen
var train = iris.Where((s, i) => i % 3 != 0).ToList();   // om te trainen
double[] bloem = { 6.1, 2.8, 4.9, 1.7 };                   // de bloem uit les 5 (kNN: virginica)

Console.WriteLine($"{train.Count} bloemen om te trainen, {test.Count} om te testen\n");
Console.WriteLine("stappen  train   test   kans virginica bloem les 5");
foreach (int stappen in new[] { 1, 10, 100, 1000, 5000 })
{
    var model = new LogisticRegression(4);
    model.Train(train, 0.01, stappen);
    Console.WriteLine($"{stappen,7}  {Accuracy(model, train),5:P0}  {Accuracy(model, test),5:P0}   {model.VoorspelKans(bloem):0.00}");
}

// ---------------------------------------------------------------------
// Hulpfuncties – niet aanpassen
// ---------------------------------------------------------------------
static void Check(string wat, double resultaat, string verwacht) =>
    Console.WriteLine($"{wat,-28} {resultaat:0.###}   verwacht: {verwacht}");

static double Accuracy(LogisticRegression model, List<Sample> data) =>
    (double)data.Count(s => model.Voorspel(s.Features) == s.Label) / data.Count;

// Leest iris.csv, laat setosa weg en zet de soort om naar 0 (versicolor) of 1 (virginica).
static List<Sample> LoadIris(string pad)
{
    var data = new List<Sample>();
    foreach (string lijn in File.ReadLines(pad).Skip(1))
    {
        string[] delen = lijn.Split(',');
        if (delen[^1] == "setosa") continue;
        double[] kenmerken = delen[..^1].Select(v => double.Parse(v, CultureInfo.InvariantCulture)).ToArray();
        data.Add(new Sample(kenmerken, delen[^1] == "virginica" ? 1 : 0));
    }
    return data;
}
