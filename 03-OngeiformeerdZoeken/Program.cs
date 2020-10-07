using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OngeiformeerdZoeken
{
    class Program
    {
        static List<int>[] aList;
        static int nodes;

        public static void BFS(int s)
        {
            bool[] visited = new bool[nodes];

            //maak queue
            Queue<int> queue = new Queue<int>();
            
            //start is bezocht en voeg toe aan queue
            visited[s] = true;
            queue.Enqueue(s);

            //zolang queue niet leeg is!
            while (queue.Count != 0)
            {
                //neem node van queue
                s = queue.Dequeue();
                Console.WriteLine("next->" + s); //alleen om te tonen ;)
                
                //bekijk alle kinderen!
                foreach (int next in aList[s])
                {
                    if (next == 0) return;
                    //indien nog niet bezocht
                    if (!visited[next])
                    {
                        visited[next] = true; //bezoek
                        queue.Enqueue(next); //voeg toe aan queue
                    }
                }
            }
        }
        public static void DFS(int s)
        {
            bool[] visited = new bool[nodes];

            //gebruiken een stack
            Stack<int> stack = new Stack<int>();

            //start is bezocht en toegevoegd aan stack
            visited[s] = true;
            stack.Push(s);

            //zolang stack niet leeg is
            while (stack.Count != 0)
            {
                //haal node van stack
                s = stack.Pop();
                Console.WriteLine("next->" + s);

                //bekijk alle kinderen
                foreach (int next in aList[s])
                {
                     if (next == 0) return;
                    //indien nog niet bezocht
                    if (!visited[next])
                    {
                        visited[next] = true; //bezoek
                        stack.Push(next); //voeg oe aan stack (bovenaan, dus gaat eerst bezocht worden!)
                    }
                }
            }
        }

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

        public static void Main()
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

            Console.WriteLine("BFS vanaf node 12:");
            BFS(12);
            Console.WriteLine("DFS vanaf node 12:");
            DFS(12);
        }
    }
}

