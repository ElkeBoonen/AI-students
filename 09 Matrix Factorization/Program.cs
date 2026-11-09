// Les 9 – Matrix Factorization
// Elke test print het resultaat naast de verwachte waarde.
// Methodes die nog niet af zijn, geven 0 terug of doen niets: het programma crasht niet.

using System.Globalization;

// zodat getallen met een punt verschijnen (0.5), zoals op de slides
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

// Ratingmatrix (1 tot 5 sterren, 0 = nog niet gezien)
// Lotte en Yusuf: de actiefans uit les 5 · Marc en Rita: de romantiekfans uit les 5
// Film A en B = actie · Film C en D = romantiek
string[] gebruikers = { "Lotte", "Yusuf", "Marc", "Rita" };
string[] films = { "A", "B", "C", "D" };
double[,] ratings =
{
    //  A  B  C  D
    {   5, 4, 1, 0 },   // Lotte  (D nog niet gezien)
    {   4, 0, 1, 2 },   // Yusuf  (B nog niet gezien)
    {   1, 2, 5, 4 },   // Marc
    {   0, 1, 4, 5 },   // Rita   (A nog niet gezien)
};

// ---------------------------------------------------------------------
Console.WriteLine("===== BLOK 1 – Voorspellen = dot product =====");
// ---------------------------------------------------------------------
Check("[0.10, 0.30] · [0.20, 0.40]", MatrixFactorization.Predict([0.10, 0.30], [0.20, 0.40]), "0.14");
Check("Gebruiker 1 · film A", MatrixFactorization.Predict([0.5, 0.8], [0.6, 0.4]), "0.62");

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 2 – Eén stap bijleren =====");
// ---------------------------------------------------------------------
double[] u = { 0.5, 0.8 };   // gebruiker 1 (cursus 9.7.3)
double[] v = { 0.6, 0.4 };   // film A
double fout = MatrixFactorization.UpdateStep(u, v, rating: 5, alpha: 0.1);
Check("Fout", fout, "4.38");
CheckVec("u na de stap", u, "(0.763, 0.975)");
CheckVec("v na de stap", v, "(0.819, 0.75)");
Check("Nieuwe voorspelling u · v", MatrixFactorization.Predict(u, v), "1.357");

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 3 – Funk SVD trainen en meten =====");
// ---------------------------------------------------------------------
Check("RMSE (5, 4, 1) vs (4, 4, 3)", MatrixFactorization.Rmse([5, 4, 1], [4, 4, 3]), "1.291");

var model = new MatrixFactorization(ratings, aantalFactoren: 2, seed: 1);
Check("RMSE vóór training", model.RmseGekend(), "2.959");
model.Train(alpha: 0.01, iteraties: 1000);
Check("RMSE na 1000 iteraties", model.RmseGekend(), "0.312");
Check("Lotte – film D", model.Voorspel(0, 3), "1.865");
Check("Yusuf – film B", model.Voorspel(1, 1), "3.343");
Check("Rita – film A", model.Voorspel(3, 0), "0.007");
Console.WriteLine();
model.Print(gebruikers, films);

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 4 – Hoe groot is een stapje? =====");
// ---------------------------------------------------------------------
// Niets coderen: voorspel eerst, run dan en vergelijk.
Console.WriteLine("alpha     10 it.   100 it.  1000 it.   Lotte – D");
foreach (double alpha in new[] { 0.001, 0.01, 0.1, 0.5 })
{
    Console.Write($"{alpha,-7}");
    double lotteD = 0;
    foreach (int iteraties in new[] { 10, 100, 1000 })
    {
        var m = new MatrixFactorization(ratings, aantalFactoren: 2, seed: 1);
        m.Train(alpha, iteraties);
        Console.Write($"{m.RmseGekend(),10:0.###}");
        lotteD = m.Voorspel(0, 3);
    }
    Console.WriteLine($"{lotteD,12:0.#}");
}

// ---------------------------------------------------------------------
// Hulpfuncties – niet aanpassen
// ---------------------------------------------------------------------
static void Check(string wat, double resultaat, string verwacht) =>
    Console.WriteLine($"{wat,-30} {resultaat:0.###}   verwacht: {verwacht}");

static void CheckVec(string wat, double[] v, string verwacht) =>
    Console.WriteLine($"{wat,-30} ({string.Join(", ", v.Select(x => x.ToString("0.###")))})   verwacht: {verwacht}");
