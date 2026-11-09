// Les 12 – AI-agents (cursus H12, p. 92-98)
// STARTCODE – vul blok 1, 2 en 3 aan. Test telkens met Program.cs.
// Een agent zonder taalmodel: alles wat een LLM normaal 'beslist', doen we hier met cosine similarity.
// Zo zie je wat er achter de schermen gebeurt. De echte agent met een LLM toont de docent in de demo.

public record Tool(string Naam, string Beschrijving);

public static class Agent
{
    // =====================================================================
    // GEGEVEN – cosine similarity (ken je uit les 9 en 11)
    // =====================================================================
    public static double Cosine(double[] a, double[] b)
    {
        double product = 0, normA = 0, normB = 0;
        for (int i = 0; i < a.Length; i++)
        {
            product += a[i] * b[i];
            normA += a[i] * a[i];
            normB += b[i] * b[i];
        }
        if (normA == 0 || normB == 0) return 0;
        return product / (Math.Sqrt(normA) * Math.Sqrt(normB));
    }

    // =====================================================================
    // BLOK 1 – Geheugen ophalen uit een vectorstore
    // =====================================================================

    // Geeft de positie van de herinnering met de hoogste cosine (pseudocode cursus p. 98).
    // Bij een gelijke score wint de eerste: enkel een strikt hogere score vervangt de beste.
    public static int HaalOp(double[] vraag, List<double[]> geheugen)
    {
        int beste = -1;
        // Stappen:
        // 0  double hoogste = double.NegativeInfinity;
        // 1  voor elke herinnering i: score = Cosine(vraag, geheugen[i])
        // 2  is score > hoogste? onthoud score en i
        // 3  geef de positie van de beste terug
        return beste;
    }

    // =====================================================================
    // BLOK 2 – Function calling: welke tool past bij de vraag?
    // =====================================================================

    // Vergelijk de vraag met de beschrijving van elke tool. De tool met de hoogste cosine wint.
    public static (Tool Tool, double Score) KiesTool(string vraag, List<Tool> tools)
    {
        // Stappen:
        // 1  v = Embed(vraag)
        // 2  voor elke tool t: score = Cosine(v, Embed(t.Beschrijving))
        // 3  onthoud de tool met de hoogste score (zelfde patroon als HaalOp)
        // 4  geef (beste tool, hoogste score) terug
        return (tools[0], 0);
    }

    // =====================================================================
    // BLOK 3 – Sense → Plan → Act → Learn
    // =====================================================================

    // Voer de tool uit. Mislukt het (null), probeer opnieuw, tot maxPogingen.
    // Lukt het nooit, geef null terug: dan moet een mens beslissen (controlepunt).
    public static (string? Resultaat, int Pogingen) AgentLus(Func<int, string?> tool, int maxPogingen, List<string> log)
    {
        // Stappen:
        // 1  voor poging = 1 tot en met maxPogingen:
        // 2    Act:   log.Add($"Act    poging {poging}") en resultaat = tool(poging)
        // 3    Learn: resultaat niet null?  log "Learn  gelukt: ..." en geef (resultaat, poging) terug
        //             anders                log "Learn  mislukt, plan aanpassen en opnieuw"
        // 4  na de lus: log "Stop   maximum bereikt: vraag het aan een mens" en geef (null, maxPogingen) terug
        return (null, 0);
    }

    // =====================================================================
    // GEGEVEN – niet aanpassen
    // =====================================================================

    // Een heel eenvoudig 'embedding-model': tel hoe vaak elk sleutelwoord in de tekst zit.
    // Een echt embedding-model kent duizenden dimensies; wij gebruiken er 5.
    public static readonly string[] Woordenschat = { "weer", "morgen", "film", "kijk", "rating" };

    public static double[] Embed(string tekst)
    {
        string[] woorden = tekst.ToLower().Split(' ', ',', '.', '?', '!');
        double[] v = new double[Woordenschat.Length];
        for (int d = 0; d < Woordenschat.Length; d++)
            v[d] = woorden.Count(w => w.Contains(Woordenschat[d]));
        return v;
    }

    // De JSON die een LLM bij function calling teruggeeft (cursus 12.2.1). De applicatie voert die zelf uit.
    public static string FunctieAanroep(string functie, string parameter, string waarde) =>
        $"{{ \"function\": \"{functie}\", \"arguments\": {{ \"{parameter}\": \"{waarde}\" }} }}";
}
