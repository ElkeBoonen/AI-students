// Les 10 – GEGEVEN, niet aanpassen
// Eén neuron zonder verborgen laag = Logistic Regression uit les 7.
// Dient in blok 4 om te vergelijken met het netwerk.

public class EenNeuron
{
    public double[] W { get; }
    public double B { get; private set; }

    public EenNeuron(int aantalInputs, int seed)
    {
        var r = new Random(seed);
        W = new double[aantalInputs];
        for (int i = 0; i < aantalInputs; i++) W[i] = r.NextDouble() * 2 - 1;
        B = r.NextDouble() * 2 - 1;
    }

    public double Voorspel(double[] x) => NeuralNetwork.Neuron(x, W, B);

    // Zelfde update-regel als in les 7: w = w + η · gradiënt · x
    public void Train(List<(double[] X, double Target)> data, double eta, int aantalStappen)
    {
        for (int stap = 0; stap < aantalStappen; stap++)
            foreach (var (x, t) in data)
            {
                double o = Voorspel(x);
                double gradient = (t - o) * NeuralNetwork.SigmoidAfgeleide(o);
                for (int i = 0; i < W.Length; i++) W[i] += eta * gradient * x[i];
                B += eta * gradient;
            }
    }

    public double GemiddeldVerlies(List<(double[] X, double Target)> data) =>
        data.Average(d => NeuralNetwork.Verlies(d.Target, Voorspel(d.X)));
}
