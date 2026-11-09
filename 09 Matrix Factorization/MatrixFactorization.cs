// Les 9 – Matrix Factorization (cursus H9, p. 65-72)
// STARTCODE – vul blok 1, 2 en 3 aan. Test telkens met Program.cs.

public class MatrixFactorization
{
    public double[,] Ratings { get; }              // gebruikers × films, 0 = onbekend
    public int AantalFactoren { get; }
    public double[][] GebruikerFactoren { get; }   // één rij u per gebruiker
    public double[][] ItemFactoren { get; }        // één rij v per film

    // Stap 1 (cursus 9.6.1): begin met kleine willekeurige getallen, geen nullen.
    // Een vaste seed geeft iedereen dezelfde start, dus dezelfde testwaarden.
    public MatrixFactorization(double[,] ratings, int aantalFactoren, int seed = 1)
    {
        Ratings = ratings;
        AantalFactoren = aantalFactoren;
        var random = new Random(seed);
        GebruikerFactoren = Willekeurig(ratings.GetLength(0), aantalFactoren, random);
        ItemFactoren = Willekeurig(ratings.GetLength(1), aantalFactoren, random);
    }

    // =====================================================================
    // BLOK 1 – Voorspellen = dot product
    // =====================================================================

    // r̂ = u · v = u[0]·v[0] + u[1]·v[1] + ...
    public static double Predict(double[] u, double[] v)
    {
        // Stappen:
        // 1  start met som = 0
        // 2  voor elke factor k: som += u[k] · v[k]
        // 3  geef de som terug
        return 0;
    }

    // =====================================================================
    // BLOK 2 – Eén stap bijleren
    // =====================================================================

    // Past u en v aan (in de array zelf) en geeft de fout terug.
    public static double UpdateStep(double[] u, double[] v, double rating, double alpha)
    {
        // Stappen:
        // 1  voorspelling = Predict(u, v)
        // 2  fout = rating − voorspelling
        // 3  voor elke factor k:  u[k] = u[k] + alpha · fout · v[k]
        //                         v[k] = v[k] + alpha · fout · (de OUDE u[k])
        // 4  geef de fout terug
        return 0;
    }

    // =====================================================================
    // BLOK 3 – Funk SVD trainen en meten
    // =====================================================================

    // RMSE = √( gemiddelde van (echt − voorspeld)² )
    public static double Rmse(double[] echt, double[] voorspeld)
    {
        // Stappen:
        // 1  per rating: fout = echt − voorspeld, tel fout² op
        // 2  deel door het aantal ratings (MSE)
        // 3  geef de vierkantswortel terug: Math.Sqrt(...)
        return 0;
    }

    // Pseudocode: cursus p. 70-71
    public void Train(double alpha, int iteraties)
    {
        // Stappen:
        // 1  herhaal iteraties keer:
        // 2    voor elke gebruiker g en elke film f (Ratings.GetLength(0) en (1))
        // 3      lege cel (Ratings[g, f] == 0)? Sla over: daar train je niet op
        // 4      anders: UpdateStep(GebruikerFactoren[g], ItemFactoren[f], Ratings[g, f], alpha)
    }

    // =====================================================================
    // GEGEVEN – niet aanpassen
    // =====================================================================

    // De voorspelde rating voor één gebruiker en één film, ook voor een lege cel.
    public double Voorspel(int gebruiker, int film) => Predict(GebruikerFactoren[gebruiker], ItemFactoren[film]);

    // RMSE over alle gekende ratings (de lege cellen tellen niet mee).
    public double RmseGekend()
    {
        var echt = new List<double>();
        var voorspeld = new List<double>();
        for (int g = 0; g < Ratings.GetLength(0); g++)
            for (int f = 0; f < Ratings.GetLength(1); f++)
                if (Ratings[g, f] != 0)
                {
                    echt.Add(Ratings[g, f]);
                    voorspeld.Add(Voorspel(g, f));
                }
        return Rmse(echt.ToArray(), voorspeld.ToArray());
    }

    // Toont de voorspelde matrix. Lege cellen (nieuwe voorspellingen) staan tussen haakjes.
    public void Print(string[] gebruikers, string[] films)
    {
        Console.WriteLine("         " + string.Concat(films.Select(f => $"{f,8}")));
        for (int g = 0; g < gebruikers.Length; g++)
        {
            Console.Write($"{gebruikers[g],-9}");
            for (int f = 0; f < films.Length; f++)
            {
                string cel = Ratings[g, f] == 0 ? $"({Voorspel(g, f):0.0})" : $"{Voorspel(g, f):0.0}";
                Console.Write($"{cel,8}");
            }
            Console.WriteLine();
        }
    }

    // Een rij per gebruiker of film met kleine willekeurige getallen tussen 0 en 1.
    private static double[][] Willekeurig(int rijen, int factoren, Random random)
    {
        var m = new double[rijen][];
        for (int i = 0; i < rijen; i++)
        {
            m[i] = new double[factoren];
            for (int k = 0; k < factoren; k++) m[i][k] = random.NextDouble();
        }
        return m;
    }
}
