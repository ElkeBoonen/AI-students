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
        }
    }
}
