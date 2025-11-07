namespace _06_NB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NB nb = new NB();

            string sms = "I am so happy this is working!";
            Console.WriteLine($"{sms} SPAM? {nb.CheckIfSpam(sms)}");

            sms = "Free beer and big jackpot to win!";
            Console.WriteLine($"{sms} SPAM? {nb.CheckIfSpam(sms)}");

        }
    }
}
