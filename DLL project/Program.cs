using System;
using BFS___DSPS;

namespace DLL_project
{
    class Program
    {
        static void Main(string[] args)
        {
            BFF bff = new BFF();
            bff.AddConnection("anna", "bert");
            bff.AddConnection("anne", "cedric");
            Console.WriteLine(bff.ToString());
        }
    }
}
