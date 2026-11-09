// Les 8 – Recommender Systems (zelfstudie)
// Elke test print het resultaat naast de verwachte waarde.
// Methodes die nog niet af zijn, geven 0 terug: het programma crasht niet.

using System.Globalization;

// zodat getallen met een punt verschijnen (0.5), zoals in de cursus
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

// Ratings op 5.   0 = NIET BEOORDEELD (een lege cel in de ratingmatrix), géén rating.

// Cursus 8.5.3: twee gebruikers, drie co-rated films
double[] gebruikerA = [5, 4, 5];   // Gebruiker A: Film 1, 2, 3
double[] gebruikerB = [4, 5, 4];   // Gebruiker B: Film 1, 2, 3

// Les 5 (kNN, blok 4): X heeft Film 5 nog niet gezien
//                 Film 1  2  3  4  5
double[] x = [4, 2, 5, 3, 0];   // X: Film 5 is een lege cel
double[] a = [5, 1, 4, 2, 5];   // A
double[] c = [4, 2, 5, 3, 2];   // C

// ---------------------------------------------------------------------
Console.WriteLine("===== BLOK 1 – Welke films hebben ze allebei beoordeeld? =====");
// ---------------------------------------------------------------------
CheckLijst("Co-rated A en B", Recommender.CoRated(gebruikerA, gebruikerB), "Film 1, 2, 3");
CheckLijst("Co-rated X en A", Recommender.CoRated(x, a), "Film 1, 2, 3, 4");
CheckLijst("Co-rated X en C", Recommender.CoRated(x, c), "Film 1, 2, 3, 4");

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 2 – Cosine op de co-rated films =====");
// ---------------------------------------------------------------------
Check("cos(A, B)", Recommender.CosineCoRated(gebruikerA, gebruikerB), "0.978");
Check("cos(X, A)", Recommender.CosineCoRated(x, a), "0.963");
Check("cos(X, C)", Recommender.CosineCoRated(x, c), "1");

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 3 – Wat als je lege cellen als 0 telt? (niets te coderen) =====");
// ---------------------------------------------------------------------
Console.WriteLine($"{"",-12} {"lege cel = 0",-14} {"enkel co-rated",-14}");
Console.WriteLine($"{"cos(X, A)",-12} {Recommender.CosineAlles(x, a),-14:0.###} {Recommender.CosineCoRated(x, a),-14:0.###} verwacht: 0.775 en 0.963");
Console.WriteLine($"{"cos(X, C)",-12} {Recommender.CosineAlles(x, c),-14:0.###} {Recommender.CosineCoRated(x, c),-14:0.###} verwacht: 0.965 en 1");

// ---------------------------------------------------------------------
// Hulpfuncties – niet aanpassen
// ---------------------------------------------------------------------
static void Check(string wat, double resultaat, string verwacht) =>
    Console.WriteLine($"{wat,-28} {resultaat:0.###}   verwacht: {verwacht}");

// toont indexen 0, 1, 2 als "Film 1, 2, 3"
static void CheckLijst(string wat, List<int> films, string verwacht)
{
    string tekst = films.Count == 0 ? "?" : "Film " + string.Join(", ", films.Select(i => i + 1));
    Console.WriteLine($"{wat,-28} {tekst}   verwacht: {verwacht}");
}
