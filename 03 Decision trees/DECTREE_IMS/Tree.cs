
namespace DECTREE_IMS
{
    internal class Tree
    {
        public int Predict(Node root, int value)
        {
            if (root.Label.HasValue)
            { 
                return root.Label.Value;
            }
            if (value <= root.FeatureThreshold) return Predict(root.Left, value);
            return Predict(root.Right, value);
        }

        public void Print(Node node, string indent = "", bool isLeftChild = true)
        {
            if (node == null) return;

            if (node.Left == null && node.Right == null)
            {
                Console.WriteLine($"{indent}Leaf: Class={node.Label}");
            }
            else
            {
                Console.WriteLine($"{indent}Node: Threshold={node.FeatureThreshold}");
                indent += isLeftChild ? "|   " : "    ";
                Console.Write($"{indent}L--> ");
                Print(node.Left, indent, true);
                Console.Write($"{indent}R--> ");
                Print(node.Right, indent, false);
            }
        }

        public Node Train(int[] x, int[] y, int depth, int maxDepth)
        {
            if (depth == maxDepth)
            {
                Node leaf = new Node();
                leaf.Left = null;
                leaf.Right = null;
                leaf.Label = MostFrequent(y);
                return leaf;
            }
            double threshold = x.Average();
            List<int> leftX = new List<int>();
            List<int> leftY = new List<int>();
            List<int> rightX = new List<int>();
            List<int> rightY = new List<int>();

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] <= threshold)
                {
                    leftX.Add(x[i]);
                    leftY.Add(y[i]);
                }
                else
                {
                    rightX.Add(x[i]);
                    rightY.Add(y[i]);
                }
            }
            Node node = new Node();
            node.FeatureThreshold = threshold;
            node.Left = Train(leftX.ToArray(), leftY.ToArray(), depth + 1, maxDepth);
            node.Right = Train(rightX.ToArray(), rightY.ToArray(), depth + 1, maxDepth);
            return node;
        }

        private int MostFrequent(int[] y)
        {
            Dictionary<int,int> dict = new Dictionary<int,int>();
            foreach (int value in y)
            {
                if (!dict.ContainsKey(value)) dict[value] = 0;
                dict[value]++;
            }
            return dict.OrderByDescending(x => x.Value).First().Key; 

        }
    }
}