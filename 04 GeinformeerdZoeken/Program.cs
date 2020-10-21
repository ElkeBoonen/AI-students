using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_GeinformeerdZoeken
{
    class Program
    {

        static List<int>[] aList;
        static int nodes;

        public static void Print()
        {
            for (int i = 0; i < nodes; i++)
            {
                Console.Write(i + " --> ");
                string s = "";
                foreach (var k in aList[i])
                {
                    s = s + (k + " ");
                }
                Console.WriteLine(s);
            }
        }

        public static int CalculateCost(int current, int next)
        {
            return Math.Abs(current - next);
        }

        public static void CreateAList(int n)
        {
            nodes = n;
            aList = new List<int>[nodes];
            for (int i = 0; i < aList.Length; i++)
            {
                aList[i] = new List<int>();
            }
        }

        public static void AddEdge(int node1, int node2)
        {
            aList[node1].Add(node2);
            aList[node2].Add(node1);
        }

        public static void AStar(int startnode)
        {
            bool[] visited = new bool[nodes];
            Stack<KeyValuePair<int, int>> stack = new Stack<KeyValuePair<int, int>>();

            stack.Push(new KeyValuePair<int, int>(startnode, 0));

            int totalcost = 0;

            while (stack.Count != 0)
            {
                KeyValuePair<int, int> node = stack.Pop();
                totalcost += node.Value;

                Console.WriteLine("next->" + node.Key);

                if (!visited[node.Key])
                {
                    visited[node.Key] = true;

                    Dictionary<int, int> neighbours = new Dictionary<int, int>();
                    foreach (int next in aList[node.Key])
                    {
                        if (next == 0) return;

                        if (!visited[next])
                            neighbours.Add(next, totalcost + CalculateCost(node.Key, next));
                    }

                    foreach (KeyValuePair<int, int> pair in neighbours.OrderByDescending(key => key.Value))
                        stack.Push(pair);
                }
            }
        }

        static void Main(string[] args)
        {
            CreateAList(25);
            AddEdge(0, 1);
            AddEdge(1, 2);
            AddEdge(2, 3);
            AddEdge(3, 4);
            AddEdge(4, 9);
            AddEdge(9, 14);
            AddEdge(18, 17);
            AddEdge(18, 19);
            AddEdge(19, 14);
            AddEdge(19, 24);
            AddEdge(24, 23);
            AddEdge(18, 23);
            AddEdge(22, 23);
            AddEdge(17, 12);
            AddEdge(21, 22);
            AddEdge(21, 20);
            AddEdge(20, 15);
            AddEdge(15, 10);
            AddEdge(10, 5);
            AddEdge(5, 0);
            //Print adjacency matrix
            Print();

            Console.WriteLine("Astar vanaf node 12:");
            AStar(12);
            
        }
    }
}
