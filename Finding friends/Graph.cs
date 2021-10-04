using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finding_friends
{
    public class Graph
    {
        public Dictionary<string, List<string>> People { get; private set; }

        public Graph()
        {
            People = new Dictionary<string, List<string>>();
        }
        public void AddFriend(string node, string friend)
        {
            if (!People.ContainsKey(node)) People[node] = new List<string>();
            People[node].Add(friend);

            if (!People.ContainsKey(friend)) People[friend] = new List<string>();
            People[friend].Add(node);
        }

        public override string ToString()
        {
            string s = "PRINT GRAPH\n";
            foreach (var person in People)
            {
                s += person.Key + " is friends with ";
                foreach (var friend in People[person.Key])
                {
                    s += friend + " ";
                }
                s += "\n";
            }
            return s;
        }

        public List<string> BFS(string start)
        {
            //traverse graph in BFS-way
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            Queue<string> queue = new Queue<string>();

            visited[start] = true;
            queue.Enqueue(start);

            while (queue.Count != 0)
            {
                string person = queue.Dequeue();
                foreach (string next in People[person])
                {
                    if (!visited.ContainsKey(next))
                    {
                        visited[next] = true;
                        queue.Enqueue(next);
                    }
                }
            }
            return visited.Keys.ToList();
        }

        public List<string> MutualFriends(string person1, string person2)
        {
            List<string> mutual = new List<string>();
            foreach (var f1 in People[person1])
            {
                foreach (var f2 in People[person2])
                {
                    if (f1 == f2) mutual.Add(f1);
                }
            }
            return mutual;
        }
    }
}
