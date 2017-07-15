using System;
using System.Collections.Generic;

// This is an example for
// Weighted Undirected Graph with a 2-dimensional array

namespace Common_Topics
{
    public class Dijkstra_Algorithm2
    {
        protected int[,] graph;
        protected int[] mapPath;
        protected int[] mapDistance;
        protected int? fromVertice = null;

        public Dijkstra_Algorithm2(int[,] graph)
        {
            this.graph = graph;
        }

        public Tuple<int, List<int>> FindShortestPath(int fromVertice, int toVertice)
        {
            if (this.fromVertice != fromVertice)
            {
                BuildMap(fromVertice);
            }

            List<int> path = new List<int>();

            int current = toVertice;

            while (current != fromVertice)
            {
                if (mapDistance[current] == Int32.MaxValue)
                {
                    return new Tuple<int, List<int>>(Int32.MaxValue, new List<int>());
                }

                path.Add(current);
                current = mapPath[current];
            }

            path.Add(fromVertice);
            path.Reverse();

            return new Tuple<int, List<int>>(mapDistance[toVertice], path);
        }

        public int[] MapPath
        {
            get
            {
                return mapPath;
            }
        }

        public int[] MapDistance
        {
            get
            {
                return mapDistance;
            }
        }

        public void BuildMap(int fromVertice)
        {
            this.fromVertice = fromVertice;

            mapDistance = new int[graph.GetLength(0)];
            for (int i = 0; i < mapDistance.Length; i++)
            {
                mapDistance[i] = Int32.MaxValue;
            }
            mapDistance[fromVertice] = 0;

            mapPath = new int[graph.GetLength(0)];
            mapPath[fromVertice] = fromVertice;

            bool[] visited = new bool[graph.GetLength(0)];

            while (true)
            {
                int shortestDistance = Int32.MaxValue;
                int currentNode = fromVertice;

                for (int node = 0; node < graph.GetLength(0); node++)
                {
                    if (!visited[node] && shortestDistance > mapDistance[node])
                    {
                        shortestDistance = mapDistance[node];
                        currentNode = node;
                    }
                }

                if (shortestDistance == Int32.MaxValue)
                {
                    break;
                }

                visited[currentNode] = true;

                for (int neighbour = 0; neighbour < graph.GetLength(0); neighbour++)
                {
                    if (graph[currentNode, neighbour] > 0)
                    {
                        int distanceToNode = mapDistance[currentNode] + graph[currentNode, neighbour];

                        if (distanceToNode < mapDistance[neighbour])
                        {
                            mapDistance[neighbour] = distanceToNode;
                            mapPath[neighbour] = currentNode;
                        }
                    }
                }
            }
        }
    }
}