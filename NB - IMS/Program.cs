using System;

namespace NB___IMS
{
    class Program
    {
        static void Main(string[] args)
        {
            NB nb = new NB();
            nb.ReadData("simpledata.txt");
            Console.WriteLine(nb.Classify("Review us now"));

            nb = new NB();
            nb.ReadData("data.txt");
            string sms = "I am so happy this is working!";
            Console.WriteLine(sms + " --> " + nb.Classify(sms));

            sms = "Free beer and big jackpot to win!";
            Console.WriteLine(sms + " --> " + nb.Classify(sms));

        }


    }
}
