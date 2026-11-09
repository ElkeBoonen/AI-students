// Les 10 – Neurale netwerken
// Elke test print het resultaat naast de verwachte waarde.
// Methodes die nog niet af zijn, geven 0 terug of doen niets: het programma crasht niet.

using System.Globalization;

// zodat getallen met een punt verschijnen (0.5), zoals op de slides
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

// Cursusoefening 10.6.3: 2 inputs, 2 verborgen neuronen, 1 output, target t = 1
double[] x = { 1, 2 };
NeuralNetwork Cursusnetwerk() => new(
    w1: [[0.5, 0.0],      // naar h1: w11, w21
         [-0.5, 0.5]],    // naar h2: w12, w22
    b1: [-0.5, 0.0],      // bh1, bh2
    w2: [1.0, -1.0],      // wo1, wo2
    b2: 0.0);             // bo

// ---------------------------------------------------------------------
Console.WriteLine("===== BLOK 1 – Eén neuron =====");
// ---------------------------------------------------------------------
Check("Sigmoid(0)", NeuralNetwork.Sigmoid(0), "0.5");
Check("h1", NeuralNetwork.Neuron(x, [0.5, 0.0], -0.5), "0.5");
Check("h2", NeuralNetwork.Neuron(x, [-0.5, 0.5], 0.0), "0.622");
Check("Spam-mail B uit les 7", NeuralNetwork.Neuron([3, 2], [0.8, 1.2], -3.0), "0.858");

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 2 – Forward pass =====");
// ---------------------------------------------------------------------
var net = Cursusnetwerk();
var (output, verborgen) = net.Forward(x);
CheckVec("Verborgen laag (h1, h2)", verborgen, "(0.5, 0.622)");
Check("Output", output, "0.469");
Check("Verlies", NeuralNetwork.Verlies(1, output), "0.141");

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 3 – Eén stap backpropagation =====");
// ---------------------------------------------------------------------
net = Cursusnetwerk();
double gradient = net.TrainStap(x, target: 1, eta: 0.5);
Check("Gradiënt output", gradient, "0.132");
CheckVec("wo1, wo2", net.W2, "(1.033, -0.959)");
Check("bo", net.B2, "0.066");
CheckVec("w11, w21", net.W1[0], "(0.517, 0.033)");
Check("Nieuwe output", net.Forward(x).Output, "0.508");

// ---------------------------------------------------------------------
Console.WriteLine("\n===== BLOK 4 – XOR: wie leert het? =====");
// ---------------------------------------------------------------------
// Niets coderen: voorspel eerst, run dan en vergelijk.
// XOR: 1 als precies één van de twee inputs 1 is
var xor = new List<(double[] X, double Target)>
{
    ([0, 0], 0),
    ([0, 1], 1),
    ([1, 0], 1),
    ([1, 1], 0),
};
var neuron = new EenNeuron(2, seed: 1);
var netwerk = new NeuralNetwork(2, 2, seed: 4);
Console.WriteLine("stappen   verlies 1 neuron   verlies netwerk");
int gedaan = 0;
foreach (int stappen in new[] { 0, 1000, 2000, 5000, 10000 })
{
    neuron.Train(xor, 0.5, stappen - gedaan);
    netwerk.Train(xor, 0.5, stappen - gedaan);
    gedaan = stappen;
    Console.WriteLine($"{stappen,7}   {neuron.GemiddeldVerlies(xor),16:0.000}   {netwerk.GemiddeldVerlies(xor),15:0.000}");
}
Console.WriteLine("\ninput    target   1 neuron   netwerk");
foreach (var (xi, t) in xor)
    Console.WriteLine($"({xi[0]}, {xi[1]})   {t,6}   {neuron.Voorspel(xi),8:0.00}   {netwerk.Forward(xi).Output,7:0.00}");

// ---------------------------------------------------------------------
// Hulpfuncties – niet aanpassen
// ---------------------------------------------------------------------
static void Check(string wat, double resultaat, string verwacht) =>
    Console.WriteLine($"{wat,-26} {resultaat:0.###}   verwacht: {verwacht}");

static void CheckVec(string wat, double[] v, string verwacht) =>
    Console.WriteLine($"{wat,-26} ({string.Join(", ", v.Select(x => x.ToString("0.###")))})   verwacht: {verwacht}");
