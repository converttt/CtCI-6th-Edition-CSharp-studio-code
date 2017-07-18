using System;
using System.Collections.Generic;

namespace Common_Topics
{
    public class Kruskal_Graph<T>
    {
        protected HashSet<T> vertices = new HashSet<T>();
        protected List<Kruskal_Edge<T>> edges = new List<Kruskal_Edge<T>>();

        public HashSet<T> Vertices
        {
            get
            {
                return vertices;
            }
        }

        public List<Kruskal_Edge<T>> Edges
        {
            get
            {
                return edges;
            }
        }

        public void AddVertice(T vertice)
        {
            vertices.Add(vertice);
        }

        public void AddEdge(Kruskal_Edge<T> edge)
        {
            AddVertice(edge.Source);
            AddVertice(edge.Destination);
            edges.Add(edge);
        }

        public void SetNonDecreasingOrderOfEdges()
        {
            MergeSort(0, (edges.Count - 1) / 2, edges.Count - 1);
        }

        protected void MergeSort(int start, int middle, int end)
        {
            if (start >= end)
            {
                return;
            }

            MergeSort(start, (middle - start) / 2, middle);
            MergeSort(middle + 1, (end + middle + 1) / 2, end);

            int leftIndex = start;
            int rightIndex = middle + 1;

            int tmpIndex = 0;
            Kruskal_Edge<T>[] buffer = new Kruskal_Edge<T>[end - start + 1];

            while (leftIndex <= middle && rightIndex <= end)
            {
                if (edges[leftIndex].Weight <= edges[rightIndex].Weight)
                {
                    buffer[tmpIndex] = edges[leftIndex];
                    leftIndex++;
                }
                else
                {
                    buffer[tmpIndex] = edges[rightIndex];
                    rightIndex++;
                }

                tmpIndex++;
            }

            while (leftIndex <= middle)
            {
                buffer[tmpIndex] = edges[leftIndex];
                leftIndex++;
                tmpIndex++;
            }

            while (rightIndex <= end)
            {
                buffer[tmpIndex] = edges[rightIndex];
                rightIndex++;
                tmpIndex++;
            }

            tmpIndex = 0;
            for (int i = start; i <= end; i++)
            {
                edges[i] = buffer[tmpIndex];
                tmpIndex++;
            }
        }
    }

    public class Kruskal_Edge<T>
    {
        protected T source;
        protected T destination;
        protected int weight;

        public Kruskal_Edge(T source, T destination, int weight)
        {
            this.source = source;
            this.destination = destination;
            this.weight = weight;
        }

        public T Source
        {
            get
            {
                return source;
            }
        }

        public T Destination
        {
            get
            {
                return destination;
            }
        }

        public int Weight
        {
            get
            {
                return weight;
            }
        }
    }

    public class Kruskal_MST<T>
    {
        public List<Kruskal_Edge<T>> Build_MST(Kruskal_Graph<T> graph)
        {
            Dictionary<T, T> subset = new Dictionary<T, T>();
            Dictionary<T, int> rank = new Dictionary<T, int>();

            foreach (T vertice in graph.Vertices)
            {
                subset.Add(vertice, vertice);
                rank.Add(vertice, 0);
            }

            List<Kruskal_Edge<T>> mst = new List<Kruskal_Edge<T>>();

            graph.SetNonDecreasingOrderOfEdges();
            foreach (Kruskal_Edge<T> edge in graph.Edges)
            {
                T source = Find(subset, edge.Source);
                T destination = Find(subset, edge.Destination);

                if (!source.Equals(destination))
                {
                    Union(subset, rank, source, destination);
                    mst.Add(edge);

                    if (mst.Count > graph.Vertices.Count - 1)
                    {
                        break;
                    }
                }
            }

            return mst;
        }

        public T Find(Dictionary<T, T> subset, T vertice)
        {
            if (subset[vertice].Equals(vertice))
            {
                return vertice;
            }

            return Find(subset, subset[vertice]);
        }

        public void Union(Dictionary<T, T> subset, Dictionary<T, int> rank, T source, T destination)
        {
            T xRoot = Find(subset, source);
            T yRoot = Find(subset, destination);

            if (rank[xRoot] > rank[yRoot])
            {
                subset[yRoot] = xRoot;
            }
            else if (rank[yRoot] > rank[xRoot])
            {
                subset[xRoot] = yRoot;
            }
            else
            {
                subset[yRoot] = xRoot;
                rank[xRoot]++;
            }
        }
    }
}