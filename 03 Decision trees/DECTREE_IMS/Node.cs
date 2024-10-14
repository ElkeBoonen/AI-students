namespace DECTREE_IMS
{
    internal class Node
    {
        public Node Left { get; internal set; }
        public Node Right { get; internal set; }
        public double FeatureThreshold { get; internal set; }
        public int? Label { get; internal set; }
    }
}