using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPS
{
    class Node 
    {
        public double FeatureThreshold { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int? Label { get; set; }

        public Node(double featureThreshold, Node left, Node right)
        {
            FeatureThreshold = featureThreshold;
            Left = left;
            Right = right;
        }

        public Node(int label)
        {
            Label = label;
        }
    }
    class DT
    {

        private int MostFrequent(int[] Y)
        {
            int count0 = 0, count1 = 0;
            foreach (int i in Y)
            {
                if (i == 0) count0++;
                else count1++;
            }
            if (count0>count1) return 0;
            return 1;
        }

        public Node Train(int[] X, int[] Y, int depth, int maxDepth)
        {
            if (depth == maxDepth)
            {
                int label = MostFrequent(Y);
                return new Node(label);
            }

            double threshold = X.Average();

            List<int> XLeft = new List<int>();
            List<int> YLeft = new List<int>();
            List<int> XRight = new List<int>();
            List<int> YRight = new List<int>();

            for (int i = 0; i < X.Length; i++)
            {
                if (X[i] <= threshold)
                {
                    XLeft.Add(X[i]);
                    YLeft.Add(Y[i]);
                }
                else
                {
                    XRight.Add(X[i]);
                    YRight.Add(Y[i]);
                }

            }

            return new Node(threshold,
                Train(XLeft.ToArray(),YLeft.ToArray(),depth+1,maxDepth),
                Train(XRight.ToArray(), YRight.ToArray(), depth+1, maxDepth));
        }
        public int Predict(Node node, int x)
        {
            if (node.Label != null)
                return node.Label.Value;

            if (x <= node.FeatureThreshold)
                return Predict(node.Left, x);

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
                Console.WriteLine($"{indent}Node: Threshold={node.FeatureThreshold}");
                indent += isLeftChild ? "|   " : "    ";
                Console.Write($"{indent}L--> ");
                Print(node.Left, indent, true);
                Console.Write($"{indent}R--> ");
                Print(node.Right, indent, false);
            }
        }

    }
}
