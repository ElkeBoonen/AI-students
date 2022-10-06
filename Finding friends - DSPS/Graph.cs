using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finding_friends___DSPS
{
    public class Graph
    {
        private Dictionary<string, List<string>> _graph;

        public Graph()
        {
            _graph = new Dictionary<string, List<string>>();
        }

        public void AddFriend(string friend1, string friend2)
        {
            if (!_graph.ContainsKey(friend1)) _graph[friend1] = new List<string>();
            _graph[friend1].Add(friend2);

            if (!_graph.ContainsKey(friend2)) _graph[friend2] = new List<string>();
            _graph[friend2].Add(friend1);
        }
        public override string ToString()
        {
            string s = "";
            foreach (var key in _graph.Keys)
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

        public string BFS(string start)
        {
            string path = "";

            List<string> visited = new List<string>();
            Queue<string> queue = new Queue<string>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                string node = queue.Dequeue();
                path += node + " -> ";
                foreach (var item in _graph[node])
                {
                    if (!visited.Contains(item))
                    {
                        queue.Enqueue(item);
                        visited.Add(item);
                    }
                }

            }

            return path.Substring(0,path.Length-4) ;
        }

        public string NewFriends(string start)
        {
            string path = "";

            List<string> visited = new List<string>();
            Queue<string> queue = new Queue<string>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                string node = queue.Dequeue();
                if (!_graph[start].Contains(node) && node != start) path += node + " ";
                foreach (var item in _graph[node])
                {
                    if (!visited.Contains(item))
                    {
                        queue.Enqueue(item);
                        visited.Add(item);
                    }
                }

            }
            return path;
        }

        public string NewPopularFriends(string start)
        {
            string path = "";

            List<string> visited = new List<string>();
            PriorityQueue<string,int> queue = new PriorityQueue<string, int>();

            queue.Enqueue(start, (0-_graph[start].Count));
            visited.Add(start);

            while (queue.Count > 0)
            {
                string node = queue.Dequeue();
                if (!_graph[start].Contains(node) && node != start) path += node + " ";
                foreach (var item in _graph[node])
                {
                    if (!visited.Contains(item))
                    {
                        queue.Enqueue(item, (0-_graph[item].Count));
                        visited.Add(item);
                    }
                }

            }
            return path;
        }

        public string BFS_PRIORITY(string start)
        {
            string path = "";

            List<string> visited = new List<string>();
            PriorityQueue<string, int> queue = new PriorityQueue<string, int>();

            queue.Enqueue(start, (0 - _graph[start].Count));
            visited.Add(start);

            while (queue.Count > 0)
            {
                string node = queue.Dequeue();
                path += node + " -> ";
                foreach (var item in _graph[node])
                {
                    if (!visited.Contains(item))
                    {
                        queue.Enqueue(item, (0 - _graph[item].Count));
                        visited.Add(item);
                    }
                }

            }
            return path;
        }

    }
}
