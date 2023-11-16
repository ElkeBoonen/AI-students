namespace DSPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NB nb = new NB("data.txt");
            Console.WriteLine(nb.Predict("This is a test sentence, is this spam?"));
            Console.WriteLine(nb.IsSpam("This is a test sentence, is this spam?"));
        }
    }
}