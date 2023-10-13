namespace IMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] X = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] Y = { 0, 0, 0, 1, 1, 1, 1, 1, 1 };

            DT tree = new DT();
            Node root = tree.Train(X, Y, 0, 4);

          
            tree.Print(root); ;
        }
    }
}