// Les 11 – Large Language Models
// Elke test print het resultaat naast de verwachte waarde.
// Methodes die nog niet af zijn, geven 0 terug of doen niets: het programma crasht niet.

using System.Globalization;

// zodat getallen met een punt verschijnen (0.5), zoals op de slides
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

// ---------------------------------------------------------------------
Console.WriteLine("===== BLOK 1 – Embeddings vergelijken =====");
// ---------------------------------------------------------------------
// Mini-embeddings uit de cursus (11.8.3)
double[] A = { 2, 1 }, B = { 4, 2 }, C = { -1, 2 };
Check("cos(A, B)", Taalmodel.Cosine(A, B), "1");
Check("cos(A, C)", Taalmodel.Cosine(A, C), "0");

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 2 – Softmax en temperatuur =====");
// ---------------------------------------------------------------------
CheckVec("softmax(2, 1, 0)", Taalmodel.Softmax([2, 1, 0]), "(0.665, 0.245, 0.09)");
CheckVec("softmax(2, 1, 0), T = 0.5", Taalmodel.Softmax([2, 1, 0], 0.5), "(0.867, 0.117, 0.016)");
CheckVec("softmax(2, 1, 0), T = 2", Taalmodel.Softmax([2, 1, 0], 2), "(0.506, 0.307, 0.186)");

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 3 – Een taalmodel in miniatuur =====");
// ---------------------------------------------------------------------
double[] c = Taalmodel.OneHot('c');
Console.WriteLine($"{"OneHot('c')",-30} 1 op positie {Array.IndexOf(c, 1.0)}, som {c.Sum()}   verwacht: 1 op positie 2, som 1");

string zin = "De bakker bakt";                        // cursus 11.1
var model = new Taalmodel(embeddingGrootte: 4, seed: 1);
Console.WriteLine($"{"Trainingstekst",-30} {Taalmodel.Letters(zin)}");
Check("Score b → a, vóór training", model.Voorspel('b')[0], "0.005");
model.Train(zin, eta: 0.1, epochs: 1000);
Check("Score b → a, na training", model.Voorspel('b')[0], "1");
Console.WriteLine($"{"Na 'a' komt",-30} {model.VolgendeLetter('a')}   verwacht: k");
Console.WriteLine($"{"Na 'd' komt",-30} {model.VolgendeLetter('d')}   verwacht: e");
Console.WriteLine($"{"Na 'r' komt",-30} {model.VolgendeLetter('r')}   verwacht: b");

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 4 – Aan de knoppen: temperatuur =====");
// ---------------------------------------------------------------------
// Niets coderen: voorspel eerst, run dan en vergelijk.
// Trainingstekst: de eerste zinnen van hoofdstuk 11
string tekst = "Wanneer je met een chatbot praat, lijkt het alsof er iemand aan de andere kant zit " +
               "die je begrijpt. Dat is een illusie, maar wel een indrukwekkend goed gebouwde illusie.";
var groot = new Taalmodel(embeddingGrootte: 8, seed: 1);
groot.Train(tekst, eta: 0.05, epochs: 300);
foreach (double T in new[] { 0.1, 1.0, 3.0 })
    Console.WriteLine($"T = {T,-4} {groot.Genereer('d', 40, T, seed: 7)}");


// ---------------------------------------------------------------------
// Hulpfuncties – niet aanpassen
// ---------------------------------------------------------------------
static void Check(string wat, double resultaat, string verwacht) =>
    Console.WriteLine($"{wat,-30} {resultaat:0.###}   verwacht: {verwacht}");

static void CheckVec(string wat, double[] v, string verwacht) =>
    Console.WriteLine($"{wat,-30} ({string.Join(", ", v.Select(x => x.ToString("0.###")))})   verwacht: {verwacht}");
