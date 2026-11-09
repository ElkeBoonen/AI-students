// Les 10 – Neurale netwerken (cursus H10, p. 73-80)
// STARTCODE – vul blok 1, 2 en 3 aan. Test telkens met Program.cs.
// Netwerk met 2 lagen: inputs → verborgen laag (sigmoid) → één outputneuron (sigmoid)

public class NeuralNetwork
{
    public double[][] W1 { get; }   // W1[j][i] = gewicht van input i naar verborgen neuron j
    public double[] B1 { get; }     // bias per verborgen neuron
    public double[] W2 { get; }     // W2[j] = gewicht van verborgen neuron j naar de output
    public double B2 { get; private set; }   // bias van het outputneuron

    // Netwerk met vaste gewichten (zoals in de cursusoefening 10.6.3)
    public NeuralNetwork(double[][] w1, double[] b1, double[] w2, double b2)
    {
        W1 = w1; B1 = b1; W2 = w2; B2 = b2;
    }

    // Netwerk met willekeurige gewichten tussen −1 en 1 (cursus 10.1.1).
    // Een vaste seed geeft iedereen dezelfde start, dus dezelfde testwaarden.
    public NeuralNetwork(int aantalInputs, int aantalVerborgen, int seed)
    {
        var r = new Random(seed);
        double Klein() => r.NextDouble() * 2 - 1;
        W1 = new double[aantalVerborgen][];
        B1 = new double[aantalVerborgen];
        W2 = new double[aantalVerborgen];
        for (int j = 0; j < aantalVerborgen; j++)
        {
            W1[j] = new double[aantalInputs];
            for (int i = 0; i < aantalInputs; i++) W1[j][i] = Klein();
            B1[j] = Klein();
            W2[j] = Klein();
        }
        B2 = Klein();
    }

    // =====================================================================
    // BLOK 1 – Eén neuron
    // =====================================================================

    // σ(z) = 1 / (1 + e^(−z))
    public static double Sigmoid(double z)
    {
        // Stappen:
        // 1  bereken e^(−z) met Math.Exp(-z)
        // 2  geef 1 / (1 + dat getal) terug  (let op de haakjes)
        return 0;
    }

    // z = b + Σ w[i] · x[i], dan door de sigmoid (= Logistic Regression uit les 7)
    public static double Neuron(double[] x, double[] w, double b)
    {
        // Stappen:
        // 1  start met z = b
        // 2  voor elke input i: z += w[i] · x[i]
        // 3  geef Sigmoid(z) terug
        return 0;
    }

    // =====================================================================
    // BLOK 2 – Forward pass
    // =====================================================================

    // Elk neuron j van de laag kijkt naar dezelfde x, met zijn eigen gewichten W[j] en bias b[j]
    public static double[] Laag(double[] x, double[][] w, double[] b)
    {
        double[] uitvoer = new double[w.Length];
        // Stappen:
        // 1  voor elk neuron j van de laag (w.Length neuronen):
        // 2    uitvoer[j] = Neuron(x, w[j], b[j])
        return uitvoer;
    }

    // Input → verborgen laag → output. De verborgen laag heb je nodig bij het trainen.
    public (double Output, double[] Verborgen) Forward(double[] x)
    {
        // Stappen:
        // 1  verborgen = Laag(x, W1, B1)
        // 2  output = Neuron(verborgen, W2, B2)
        // 3  geef (output, verborgen) terug
        return (0, new double[W2.Length]);
    }

    // Verlies = ½ · (target − output)²
    public static double Verlies(double target, double output)
    {
        // Stappen:
        // 1  fout = target − output
        // 2  geef 0.5 · fout · fout terug
        return 0;
    }

    // =====================================================================
    // BLOK 3 – Eén stap backpropagation
    // =====================================================================

    // Pseudocode: cursus p. 78. Geeft de gradiënt aan de output terug.
    public double TrainStap(double[] x, double target, double eta)
    {
        // Stappen:
        // 1  forward pass: var (output, verborgen) = Forward(x)
        // 2  gradientOutput = (target − output) · SigmoidAfgeleide(output)
        // 3  per verborgen neuron j:
        //      gradientVerborgen[j] = gradientOutput · W2[j] · SigmoidAfgeleide(verborgen[j])
        //    (doe dit VÓÓR je W2 aanpast: je hebt de oude W2 nodig)
        // 4  laag 2: W2[j] += eta · gradientOutput · verborgen[j]   en   B2 += eta · gradientOutput
        // 5  laag 1: W1[j][i] += eta · gradientVerborgen[j] · x[i]   en   B1[j] += eta · gradientVerborgen[j]
        // 6  geef gradientOutput terug
        return 0;
    }

    // =====================================================================
    // GEGEVEN – niet aanpassen
    // =====================================================================

    // De helling van de sigmoid, uitgedrukt in de sigmoid-waarde zelf: s · (1 − s)
    public static double SigmoidAfgeleide(double s) => s * (1 - s);

    // Herhaal TrainStap op elk voorbeeld, aantalStappen keer.
    public void Train(List<(double[] X, double Target)> data, double eta, int aantalStappen)
    {
        for (int stap = 0; stap < aantalStappen; stap++)
            foreach (var (x, t) in data)
                TrainStap(x, t, eta);
    }

    // Gemiddeld verlies over alle voorbeelden.
    public double GemiddeldVerlies(List<(double[] X, double Target)> data) =>
        data.Average(d => Verlies(d.Target, Forward(d.X).Output));
}
