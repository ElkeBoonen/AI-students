// Les 8 – Recommender Systems (cursus H8, p. 60-64)
// STARTCODE – vul blok 1 en 2 aan. Test telkens met Program.cs.
// Blok 3 is een experiment: run en vergelijk, er valt niets te coderen.

public static class Recommender
{
    // =====================================================================
    // BLOK 1 – Welke films hebben ze allebei beoordeeld?
    // =====================================================================

    // Geeft de indexen van de co-rated items: films die BEIDE gebruikers beoordeeld hebben.
    // 0 = niet beoordeeld.
    public static List<int> CoRated(double[] u, double[] v)
    {
        var films = new List<int>();

        // Stappen:
        // 1  loop over alle films (index i)
        // 2  hebben u én v film i beoordeeld (allebei niet 0)? voeg i toe aan films
        // 3  geef films terug
        return films;
    }

    // =====================================================================
    // BLOK 2 – Cosine op de co-rated films
    // =====================================================================

    // cos = (u · v) / (‖u‖ · ‖v‖), enkel over de co-rated films
    public static double CosineCoRated(double[] u, double[] v)
    {
        // Stappen:
        // 1  films = CoRated(u, v); geen enkele film gemeen? geef 0 terug
        // 2  per film in films: tel u·v, u² en v² op (zoals CosineAlles hieronder)
        // 3  geef dot / (√ som u² · √ som v²) terug
        return 0;
    }

    // =====================================================================
    // GEGEVEN – niet aanpassen
    // =====================================================================

    // Cosine uit les 5 over ALLE films: een lege cel telt mee als rating 0.
    public static double CosineAlles(double[] u, double[] v)
    {
        double dot = 0, kwadratenU = 0, kwadratenV = 0;
        for (int i = 0; i < u.Length; i++)
        {
            dot += u[i] * v[i];
            kwadratenU += u[i] * u[i];
            kwadratenV += v[i] * v[i];
        }
        return dot / (Math.Sqrt(kwadratenU) * Math.Sqrt(kwadratenV));
    }
}
