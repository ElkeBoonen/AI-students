// Les 11 – Large Language Models (cursus H11, p. 82-91)
// STARTCODE – vul blok 1, 2 en 3 aan. Test telkens met Program.cs.

public class Taalmodel
{
    public const int AantalLetters = 26;
    public double[,] Embedding { get; }    // 26 × embeddingGrootte: rij i = de embedding van letter i
    public double[,] Output { get; }       // embeddingGrootte × 26: van embedding naar een score per letter
    public int EmbeddingGrootte { get; }

    // Kleine willekeurige startwaarden. Vaste seed = iedereen dezelfde start.
    public Taalmodel(int embeddingGrootte, int seed = 1)
    {
        EmbeddingGrootte = embeddingGrootte;
        var r = new Random(seed);
        Embedding = new double[AantalLetters, embeddingGrootte];
        Output = new double[embeddingGrootte, AantalLetters];
        for (int i = 0; i < AantalLetters; i++)
            for (int j = 0; j < embeddingGrootte; j++)
            {
                Embedding[i, j] = r.NextDouble() * 0.2 - 0.1;
                Output[j, i] = r.NextDouble() * 0.2 - 0.1;
            }
    }

    // =====================================================================
    // BLOK 1 – Embeddings vergelijken
    // =====================================================================

    // cos(θ) = A · B / (‖A‖ · ‖B‖)   (pseudocode cursus p. 85)
    public static double Cosine(double[] a, double[] b)
    {
        // Stappen:
        // 1  product = 0, normA = 0, normB = 0
        // 2  voor elke dimensie i: product += a[i]·b[i], normA += a[i]², normB += b[i]²
        // 3  geef product / (√normA · √normB) terug
        return 0;
    }

    // =====================================================================
    // BLOK 2 – Softmax en temperatuur
    // =====================================================================

    // softmax(zᵢ) = e^(zᵢ/T) / Σ e^(zⱼ/T)
    public static double[] Softmax(double[] scores, double temperatuur = 1)
    {
        double[] uit = new double[scores.Length];
        // Stappen:
        // 1  blaas elke score op: uit[i] = Math.Exp(scores[i] / temperatuur)
        // 2  tel alles op
        // 3  deel elke uit[i] door die som
        return uit;
    }

    // =====================================================================
    // BLOK 3 – Een taalmodel in miniatuur
    // =====================================================================

    // 'a' → (1, 0, 0, ...), 'b' → (0, 1, 0, ...)
    public static double[] OneHot(char letter)
    {
        double[] v = new double[AantalLetters];
        // Stappen:
        // 1  de positie van de letter: letter − 'a'  ('a' → 0, 'b' → 1, ...)
        // 2  zet daar een 1
        return v;
    }

    // Forward pass: one-hot · Embedding = de rij van die letter, dan · Output = een score per letter
    public double[] Voorspel(char letter)
    {
        // Stappen:
        // 1  input = OneHot(letter)
        // 2  emb = MaalMatrix(input, Embedding)
        // 3  geef MaalMatrix(emb, Output) terug
        return new double[AantalLetters];
    }

    // Eén trainstap op het paar (huidige letter → volgende letter). Pseudocode: cursus p. 87.
    public void TrainStap(char huidige, char volgende, double eta)
    {
        // Stappen:
        // 1  forward: input = OneHot(huidige), emb = MaalMatrix(input, Embedding),
        //             voorspelling = MaalMatrix(emb, Output)
        // 2  fout[k] = OneHot(volgende)[k] − voorspelling[k]
        // 3  gradientEmb[j] = som over k van fout[k] · Output[j, k]
        //    (doe dit VÓÓR je Output aanpast: je hebt de oude gewichten nodig)
        // 4  laag 2: Output[j, k] += eta · fout[k] · emb[j]
        // 5  laag 1: Embedding[i, j] += eta · gradientEmb[j] · input[i]
    }

    // =====================================================================
    // GEGEVEN – niet aanpassen
    // =====================================================================

    // Houdt enkel de letters a-z over: "De bakker bakt!" → "debakkerbakt"
    public static string Letters(string tekst) =>
        new string(tekst.ToLower().Where(c => c >= 'a' && c <= 'z').ToArray());

    public void Train(string tekst, double eta, int epochs)
    {
        string t = Letters(tekst);
        for (int e = 0; e < epochs; e++)
            for (int i = 0; i < t.Length - 1; i++)
                TrainStap(t[i], t[i + 1], eta);
    }

    // De letter met de hoogste score
    public char VolgendeLetter(char letter)
    {
        double[] v = Voorspel(letter);
        int beste = 0;
        for (int k = 1; k < AantalLetters; k++) if (v[k] > v[beste]) beste = k;
        return (char)('a' + beste);
    }

    // De embedding (rij) van één letter
    public double[] EmbeddingVan(char letter)
    {
        double[] e = new double[EmbeddingGrootte];
        for (int j = 0; j < EmbeddingGrootte; j++) e[j] = Embedding[letter - 'a', j];
        return e;
    }

    // Genereer tekst: telkens een letter trekken volgens softmax(log-score / T).
    // De voorspelling is al een soort kans; log maakt er een ruwe score van, zoals de logits van een LLM.
    public string Genereer(char start, int lengte, double temperatuur, int seed)
    {
        var r = new Random(seed);
        var sb = new System.Text.StringBuilder().Append(start);
        char huidige = start;
        for (int n = 1; n < lengte; n++)
        {
            double[] v = Voorspel(huidige);
            double[] scores = v.Select(x => Math.Log(Math.Max(x, 1e-6))).ToArray();
            double[] kansen = Softmax(scores, temperatuur);
            double som = kansen.Sum();
            if (!(som > 0)) { huidige = 'a'; sb.Append(huidige); continue; }   // Softmax nog niet af
            double trek = r.NextDouble() * som, cumul = 0;
            int k = 0;
            for (; k < AantalLetters - 1; k++) { cumul += kansen[k]; if (trek < cumul) break; }
            huidige = (char)('a' + k);
            sb.Append(huidige);
        }
        return sb.ToString();
    }

    // rijvector · matrix
    private static double[] MaalMatrix(double[] v, double[,] m)
    {
        double[] uit = new double[m.GetLength(1)];
        for (int i = 0; i < m.GetLength(0); i++)
            for (int k = 0; k < m.GetLength(1); k++)
                uit[k] += v[i] * m[i, k];
        return uit;
    }
}
