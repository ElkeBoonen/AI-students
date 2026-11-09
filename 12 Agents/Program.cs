// Les 12 – AI-agents
// Elke test print het resultaat naast de verwachte waarde.
// Methodes die nog niet af zijn, geven een standaardwaarde terug: het programma crasht niet.

using System.Globalization;

// zodat getallen met een punt verschijnen (0.5), zoals op de slides
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

// ---------------------------------------------------------------------
Console.WriteLine("===== BLOK 1 – Geheugen ophalen =====");
// ---------------------------------------------------------------------
// Vectorstore uit de cursus (12.7.3)
var geheugen = new List<double[]> { new double[] { 1, 0, 1 }, new double[] { 0, 1, 1 }, new double[] { 1, 1, 0 } };
double[] q = { 1, 0, 0 };
for (int i = 0; i < geheugen.Count; i++)
    Check($"cos(Q, M{i + 1})", Agent.Cosine(q, geheugen[i]), i == 1 ? "0" : "0.707");
Console.WriteLine($"{"Top-1 herinnering",-34} M{Agent.HaalOp(q, geheugen) + 1}   verwacht: M1");
Console.WriteLine($"{"Top-1 voor (0, 1, 0)",-34} M{Agent.HaalOp([0, 1, 0], geheugen) + 1}   verwacht: M2");

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 2 – Welke tool past? =====");
// ---------------------------------------------------------------------
var tools = new List<Tool>
{
    new("GetVoorspelling", "Geeft de weersvoorspelling voor een stad op een datum"),
    new("GetFilmHistoriek", "Geeft de films die de gebruiker al bekeek, om te kiezen wat hij vanavond kan kijken"),
    new("VoorspelRating", "Voorspelt de rating die een gebruiker aan een film zou geven"),
};
Console.WriteLine($"Woordenschat: {string.Join(", ", Agent.Woordenschat)}");
foreach (var t in tools)
    Console.WriteLine($"  {t.Naam,-17} ({string.Join(", ", Agent.Embed(t.Beschrijving))})");

string[] vragen =
{
    "Wat voor weer wordt het morgen in Gent?",
    "Welke film moet ik vanavond kijken?",
    "Hoeveel sterren zou Lotte film D geven?",
};
string[] verwacht = { "GetVoorspelling 0.707", "GetFilmHistoriek 1", "GetFilmHistoriek 0.707" };
for (int i = 0; i < vragen.Length; i++)
{
    var (tool, score) = Agent.KiesTool(vragen[i], tools);
    Console.WriteLine($"{vragen[i],-42} → {tool.Naam} {score:0.###}   verwacht: {verwacht[i]}");
}
Console.WriteLine(Agent.FunctieAanroep("GetVoorspelling", "stad", "Gent"));

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 3 – Sense → Plan → Act → Learn =====");
// ---------------------------------------------------------------------
// Een weer-API die de eerste keer een time-out geeft
string? WankeleApi(int poging) => poging == 1 ? null : "8 °C, regen";

var log = new List<string>();
var (resultaat, pogingen) = Agent.AgentLus(WankeleApi, maxPogingen: 3, log);
log.ForEach(l => Console.WriteLine("  " + l));
Console.WriteLine($"{"Resultaat",-34} {resultaat ?? "geen"} na {pogingen} pogingen   verwacht: 8 °C, regen na 2 pogingen");

log.Clear();
(resultaat, pogingen) = Agent.AgentLus(WankeleApi, maxPogingen: 1, log);
log.ForEach(l => Console.WriteLine("  " + l));
Console.WriteLine($"{"Resultaat met max 1 poging",-34} {resultaat ?? "geen"} na {pogingen} pogingen   verwacht: geen na 1 pogingen");

// ---------------------------------------------------------------------
// Hulpfuncties – niet aanpassen
// ---------------------------------------------------------------------
static void Check(string wat, double resultaat, string verwacht) =>
    Console.WriteLine($"{wat,-34} {resultaat:0.###}   verwacht: {verwacht}");
