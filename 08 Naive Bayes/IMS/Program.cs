namespace IMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NB nb = new NB("data.txt");
            Console.WriteLine(nb.Predict("As a valued network customer you have been selected to receivea"));
            Console.WriteLine(nb.Predict("Elephants are animals"));

        }
    }
}