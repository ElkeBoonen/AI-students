using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS___IMS
{
    public class FB
    {
        Dictionary<string, List<string>> graph;

        public FB()
        {
            graph = new Dictionary<string, List<string>>();
        }

        public void AddPerson(string person1, string person2)
        {
            //checken of mijn persoon al in mijn graph zit of niet!
            if (!graph.ContainsKey(person1)) graph[person1] = new List<string>();
            graph[person1].Add(person2);

            if (!graph.ContainsKey(person2)) graph[person2] = new List<string>();
            graph[person2].Add(person1);
        }

        public string[] FindFriends(string person)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(person);

            Dictionary<string, bool> visited = new Dictionary<string, bool>();

            while (queue.Count != 0)
            {
                person = queue.Dequeue();

                visited[person] = true;

                foreach (var item in graph[person])
                {
                    if (!visited.ContainsKey(item))
                    {
                        queue.Enqueue(item);
                    } 
                }
            }
            return visited.Keys.ToArray();
        }

        public override string ToString()
        {
            string s = "";
            foreach (var person in graph) //person = key/value element
            {
                s += person.Key + " --> ";
                foreach (var friend in graph[person.Key])
                {
                    s += friend + " ";
                }
                s += "\n";
            }
            return s;
        }
    }
}
