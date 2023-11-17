namespace DSPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NB nb = new NB("data.txt");
            Console.WriteLine(nb.Predict("This is a test sentence, is this spam?"));
            Console.WriteLine(nb.IsSpam("This is a test sentence, is this spam?"));
            Console.WriteLine(nb.IsSpam("Free entry in 2 a wkly comp to win FA Cup final tkts 21st May 2005. Text FA to 87121 to receive entry question(std txt rate)T&C's apply 08452810075over18'"));

        }
    }
}