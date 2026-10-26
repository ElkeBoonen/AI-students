// Les 6 – Decision Trees
// Eén knoop van de boom: een vraag (FeatureIndex, FeatureThreshold) of een blad (Label).

public class Node
{
    public int FeatureIndex { get; set; }        // welk kenmerk? (0 = eerste kenmerk)
    public double FeatureThreshold { get; set; } // de vraag: kenmerk <= drempel?
    public Node? Left { get; set; }              // antwoord ja
    public Node? Right { get; set; }             // antwoord nee
    public string? Label { get; set; }           // enkel bij een blad

    public bool IsLeaf => Label != null;
}

// Eén voorbeeld uit de dataset: de kenmerken + het juiste antwoord.
public record Sample(double[] Features, string Label);
