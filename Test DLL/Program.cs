using Finding_friends___DSPS;

namespace Test_DLL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.AddFriend("Elke", "Stipe");
            graph.AddFriend("Elke", "Aram");

            Console.WriteLine(graph);
        }
    }
}