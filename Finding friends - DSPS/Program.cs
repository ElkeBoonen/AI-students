namespace Finding_friends___DSPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            foreach (string item in File.ReadAllLines(@"data\input1.txt"))
            {
                string[] strings = item.Split(' ');
                graph.AddFriend(strings[0], strings[1]);
            }

            Console.WriteLine(graph.ToString());

            Console.WriteLine(graph.BFS("Anna"));
            Console.WriteLine(graph.BFS("Gene"));
            Console.WriteLine(graph.BFS("Fred"));

            Console.WriteLine(graph.BFS_PRIORITY("Anna"));
            Console.WriteLine(graph.BFS_PRIORITY("Gene"));
            Console.WriteLine(graph.BFS_PRIORITY("Fred"));

            Console.WriteLine("Possible new friends for Anna: " + graph.NewFriends("Anna"));
            Console.WriteLine("Possible new friends for Gene: " + graph.NewFriends("Gene"));
            Console.WriteLine("Possible new friends for Fred: " + graph.NewFriends("Fred"));

            Console.WriteLine("Possible more popular friends for Anna: " + graph.NewPopularFriends("Anna"));
            Console.WriteLine("Possible more popular for Gene: " + graph.NewPopularFriends("Gene"));
            Console.WriteLine("Possible more popular for Fred: " + graph.NewPopularFriends("Fred"));
        }
    }
}