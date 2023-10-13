using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS
{
    class Node
    {
        public double Threshold { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int? Label { get; set; }

        public Node(double threshold, Node left, Node right)
        {
            Threshold = threshold;
            Left = left;
            Right = right;
        }

        public Node(int? label)
        {
            Label = label;
        }
    }
    class DT
    {
        public Node Train(int[] X, int[] Y, int depth, int maxDepth)
        {
            if (depth == maxDepth)
            {
                //return new Node { Label = MostFrequent(Y) };
                return new Node(MostFrequent(Y));
            }

            double threshold = X.Average();
            
            List<int> XLeft = new List<int>();
            List<int> XRight = new List<int>();

            List<int> YLeft = new List<int>();
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
            Node node = new Node(threshold,
                Train(XLeft.ToArray(), YLeft.ToArray(), depth + 1, maxDepth),
                Train(XRight.ToArray(), YRight.ToArray(), depth + 1, maxDepth));
            return node;
        }

        private int MostFrequent(int[] Y)
        {
            int count0 = 0;
            int count1 = 0;

            foreach (var item in Y)
            {
                if (item == 1) count1++;
                else count0++;
            }

            if (count1 > count0) return 1;
            return 0;
        }

        //public int Predict(Node node, double x)

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
