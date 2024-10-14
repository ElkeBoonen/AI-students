using System.Xml.Linq;

namespace DECTREE_IMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] X = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] Y = { 0, 0, 0, 1, 1, 1, 1, 1, 1 };

            Tree tree = new Tree();
            Node root = tree.Train(X, Y, 0, 3);

            foreach (int value in new int[] { 2, 5, 9 , -1, 20})
            {
                Console.WriteLine($"Predict {value} --> {tree.Predict(root, value)}");
            }

            tree.Print(root);
        }
    }
}
