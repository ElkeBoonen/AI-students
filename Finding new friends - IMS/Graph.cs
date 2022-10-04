using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Finding_new_friends___IMS
{
    class Graph
    {
        Dictionary<string, List<string>> _graph;

        public Graph()
        {
            _graph = new Dictionary<string, List<string>>();
        }

        public void VriendjesMaken(string vriend1, string vriend2)
        {
            //controleer of vriend1 al in de graph bestaat, en anders maak hem en zijn vriendenlijst aan
            if (!_graph.ContainsKey(vriend1)) _graph[vriend1] = new List<string>();
            //vriend2 moet altijd toegevoegd worden aan de vriendenlijsti
            _graph[vriend1].Add(vriend2);

            if (!_graph.ContainsKey(vriend2)) _graph[vriend2] = new List<string>();
            _graph[vriend2].Add(vriend1);
        }

        public string BFS(string start)
        {
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            Queue<string> queue = new Queue<string>();

            foreach (var item in _graph.Keys)
            {
                visited[item] = false;
            }

            string path = "";

            queue.Enqueue(start);
            visited[start] = true;
            while (queue.Count > 0)
            {
                string node = queue.Dequeue();
                path += node + " -> ";

                foreach (var item in _graph[node])
                {
                    if (!visited[item])
                    {
                        queue.Enqueue(item);
                        visited[item] = true;
                    }
                        
                }
            }
            return path.Substring(0, path.Length-4);
        }

        public string BFS_PRIORITY(string start)
        {
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            PriorityQueue<string, int> queue = new PriorityQueue<string, int>();

            foreach (var item in _graph.Keys)
            {
                visited[item] = false;
            }

            string path = "";

            queue.Enqueue(start, (0 - _graph[start].Count));
            visited[start] = true;
            while (queue.Count > 0)
            {
                string node = queue.Dequeue();
                path += node + " -> ";

                foreach (var item in _graph[node])
                {
                    if (!visited[item])
                    {
                        queue.Enqueue(item, (0 -_graph[item].Count));
                        visited[item] = true;
                    }

                }
            }
            return path.Substring(0, path.Length - 4);
        }

        public override string ToString()
        {
            string s = "";
            foreach (string key in _graph.Keys)
            {
                s += key + " -> ";
                foreach (var item in _graph[key])
                {
                    s += item + " ";
                }
                s += "\n";
            }
            return s;
        }


    }
}
