using System;

namespace NB___DSPS
{
    class Program
    {
        static void Main(string[] args)
        {
            NB nb = new NB("simpledata.txt");
            Console.WriteLine($"review us now {nb.IsSpam("review us now")}");
            
            nb = new NB("data.txt");
            string sms = "I am so happy this is working!";
            Console.WriteLine($"{sms} SPAM? {nb.IsSpam(sms)}");

            sms = "Free beer and big jackpot to win!";
            Console.WriteLine($"{sms} SPAM? {nb.IsSpam(sms)}");
            }

    }
}

