// Les 6 – Decision Trees
// Eén knoop van de boom. Vergelijk met de klasse Node van vorig jaar:
// nieuw is FeatureIndex (welk kenmerk), want onze data heeft nu meerdere kenmerken.

public class Node
{
    public int FeatureIndex { get; set; }        // welk kenmerk bevraagt deze knoop?
    public double FeatureThreshold { get; set; } // de vraag: kenmerk <= drempel?
    public Node? Left { get; set; }              // antwoord ja  (<= drempel)
    public Node? Right { get; set; }             // antwoord nee (> drempel)
    public string? Label { get; set; }           // enkel ingevuld bij een blad

    public bool IsLeaf => Label != null;
}

// Eén voorbeeld uit de dataset: kenmerken + het juiste antwoord.
public record Sample(double[] Features, string Label);
