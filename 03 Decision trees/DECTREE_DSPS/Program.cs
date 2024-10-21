namespace DECTREE_DSPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] X = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] Y = { 0, 0, 0, 1, 1, 1, 1, 1, 1 };

            Tree tree = new Tree();

            Node root = tree.Train(X, Y, 0, 2);
            tree.Print(root);

            Console.WriteLine("predict 5: " + tree.Predict(root, 5));
            Console.WriteLine("predict 3: " + tree.Predict(root, 3));
            Console.WriteLine("predict 7: " + tree.Predict(root, 7));


        }
    }
}
