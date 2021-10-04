using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS___DSPS
{
    class BFF
    {
        Dictionary<string, List<string>> graph;

        public BFF()
        {
            graph = new Dictionary<string, List<string>>();
        }

        public void AddConnection(string person1, string person2)
        {
            if (!graph.ContainsKey(person1)) graph[person1] = new List<string>();
            graph[person1].Add(person2);

            if (!graph.ContainsKey(person2)) graph[person2] = new List<string>();
            graph[person2].Add(person1);
        }

        public string[] Connections(string start)
        {
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            Queue<string> queue = new Queue<string>();

            queue.Enqueue(start);
            string person;
            while (queue.Count != 0)
            {
                person = queue.Dequeue();
                visited[person] = true;

                foreach (var friend in graph[person])
                {
                    if (!visited.ContainsKey(friend)) queue.Enqueue(friend);
                }
            }
            return visited.Keys.ToArray();
        }

        public override string ToString()
        {
            string s = "";
            foreach (var item in graph)
            {
                s += item.Key + " --> ";
                foreach (var friend in graph[item.Key])
                {
                    s += friend + " ";
                }
                s += "\n";
            }
            return s;
        }
    }
}
