using System.ComponentModel;

namespace DECTREE_DSPS
{
    internal class Tree
    {
        public Node Train(int[] X, int[] Y, int depth, int maxDepth) 
        {
            if (depth == maxDepth)
            {
                Node leaf = new Node();
                leaf.Left = null;
                leaf.Right = null;
                leaf.Label = MostFrequent(Y);
                return leaf;
            }

            double threshold = X.Average();
            List<int> leftX = new List<int>();
            List<int> rightX = new List<int>();
            List<int> leftY = new List<int>();
            List<int> rightY = new List<int>();

            for (int i = 0; i < X.Length; i++)
            {
                if (X[i] <= threshold)
                {
                    leftX.Add(X[i]);
                    leftY.Add(Y[i]);
                }
                else { 
                    rightX.Add(X[i]);
                    rightY.Add(Y[i]);
                }
            }

            Node node = new Node();
            node.Threshold = threshold;
            node.Left = Train(leftX.ToArray(), leftY.ToArray(), depth+1, maxDepth);
            node.Right = Train(rightX.ToArray(), rightY.ToArray(), depth + 1, maxDepth);
            return node;

        }
        public int MostFrequent(int[] Y) 
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (var item in Y)
            {
                if (!dict.ContainsKey(item)) dict[item] = 0;
                dict[item]++;
            }
            var dict1 = dict.OrderByDescending(x => x.Value);
            return dict1.ElementAt(0).Key;
        }

        public int Predict(Node node, double x) 
        {
            if (node.Label != null)
            {
                return (int)node.Label;
            }

            if (node.Threshold >= x)
            {
                return Predict(node.Left, x);
            }
            return Predict(node.Right, x);
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
                Console.WriteLine($"{indent}Node: Threshold={node.Threshold}");
                indent += isLeftChild ? "|   " : "    ";
                Console.Write($"{indent}L--> ");
                Print(node.Left, indent, true);
                Console.Write($"{indent}R--> ");
                Print(node.Right, indent, false);
            }
        }

    }
}
