using System;
using System.Collections.Generic;

// This is an example for
// UNWEIGHTED UNDIRECTED GRAPH

namespace Common_Topics
{
    public class Dijkstra_Algorithm1<T> where T : IComparable
    {
        public Func<T, List<T>> FindShortestPath(Dijkstra_Graph1<T> graph, T fromVertice)
        {
            Dictionary<T, T> map = new Dictionary<T, T>();

            Queue<T> queue = new Queue<T>();
            queue.Enqueue(fromVertice);

            while (queue.Count > 0)
            {
                T current = queue.Dequeue();

                foreach (T neighbour in graph.Edges[current])
                {
                    if (map.ContainsKey(neighbour))
                    {
                        continue;
                    }

                    map[neighbour] = current;
                    queue.Enqueue(neighbour);
                }
            }

            Func<T, List<T>> shortestPath = v => 
            {
                List<T> path = new List<T>();
                T current = v;

                if (!map.ContainsKey(current))
                {
                    return new List<T>();
                }

                while (!map[current].Equals(fromVertice))
                {
                    path.Add(current);
                    current = map[current];
                }

                path.Add(current);
                path.Add(fromVertice);
                path.Reverse();

                return path;
            };

            return shortestPath;
        }
    }

    public class Dijkstra_Graph1<T>
    {
        protected HashSet<T> vertices = new HashSet<T>();
        protected Dictionary<T, HashSet<T>> edges = new Dictionary<T, HashSet<T>>();

        public void AddVertice(T vertice)
        {
            vertices.Add(vertice);
        }

        public void AddEdge(T verticeA, T verticeB)
        {
            if (!edges.ContainsKey(verticeA))
            {
                edges.Add(verticeA, new HashSet<T>());
            }

            if (!edges.ContainsKey(verticeB))
            {
                edges.Add(verticeB, new HashSet<T>());
            }

            edges[verticeA].Add(verticeB);
            edges[verticeB].Add(verticeA);
        }

        public HashSet<T> Vertices
        {
            get
            {
                return vertices;
            }
        }

        public Dictionary<T, HashSet<T>> Edges
        {
            get
            {
                return edges;
            }
        }
    }
}