using System;
using System.Collections.Generic;

// This is an example for
// Weighted Undirected Graph with min Heap as a queue

namespace Common_Topics
{
    public class Dijkstra_Algorithm3<T> where T : IComparable
    {
        protected Dictionary<T, T> mapPath = new Dictionary<T, T>();
        protected List<Tuple<T, int>> mapDistance = new List<Tuple<T, int>>();
        protected bool mapped = false;
        protected int heapSize = 0;
        protected HashSet<T> vertices = new HashSet<T>();
        protected Dictionary<T, Dictionary<T, int>> edges = new Dictionary<T, Dictionary<T, int>>();
        protected T fromVertice;

        public List<T> GetShortestPath(T fromVertice, T toVertice)
        {
            if (!mapped || !this.fromVertice.Equals(fromVertice))
            {
                mapPath.Clear();
                mapDistance.Clear();
                BuildMap(fromVertice);
            }

            List<T> path = new List<T>();
            T current = toVertice;

            while (current.CompareTo(fromVertice) != 0)
            {
                path.Add(current);
                
                if (!mapPath.ContainsKey(current))
                {
                    return new List<T>();
                }

                current = mapPath[current];
            }

            path.Add(fromVertice);
            path.Reverse();

            return path;
        }

        public int GetShortestDistance(T fromVertice, T toVertice)
        {
            if (!mapped || !this.fromVertice.Equals(fromVertice))
            {
                mapPath.Clear();
                mapDistance.Clear();
                BuildMap(fromVertice);
            }

            foreach (Tuple<T, int> distance in mapDistance)
            {
                if (distance.Item1.CompareTo(toVertice) == 0)
                {
                    return distance.Item2;
                }
            }

            return -1;
        }

        public void AddVertice(T vertice)
        {
            vertices.Add(vertice);
            edges.Add(vertice, new Dictionary<T, int>());
        }

        public void AddEdge(T vertice1, T vertice2, int distance)
        {
            if (!vertices.Contains(vertice1))
            {
                AddVertice(vertice1);
            }

            if (!vertices.Contains(vertice2))
            {
                AddVertice(vertice2);
            }

            edges[vertice1].Add(vertice2, distance);
            edges[vertice2].Add(vertice1, distance);
        }

        public void BuildMap(T fromVertice)
        {
            foreach (T vertice in vertices)
            {
                if (vertice.CompareTo(fromVertice) == 0)
                {
                    mapDistance.Add(new Tuple<T, int>(vertice, 0));
                }
                else
                {
                    mapDistance.Add(new Tuple<T, int>(vertice, Int32.MaxValue));
                }
            }
            mapPath.Add(fromVertice, fromVertice);

            BuildHeap();

            while (heapSize > 0)
            {
                Tuple<T, int> current = Pop();

                foreach (T neighbour in edges[current.Item1].Keys)
                {
                    int distance = current.Item2 + edges[current.Item1][neighbour];
                    int neighbourIndex = GetIndexFromDistanceMap(neighbour);

                    if (neighbourIndex > -1 && distance < mapDistance[neighbourIndex].Item2)
                    {
                        mapDistance[neighbourIndex] = new Tuple<T, int>(neighbour, distance);

                        if (mapPath.ContainsKey(neighbour))
                        {
                            mapPath[neighbour] = current.Item1;
                        }
                        else
                        {
                            mapPath.Add(neighbour, current.Item1);
                        }
                        
                        DecreaseKey(neighbourIndex);
                    }
                }
            }
        }

        protected int GetIndexFromDistanceMap(T vertice)
        {
            int index = -1;

            for (int i = 0; i < heapSize; i++)
            {
                if (vertice.Equals(mapDistance[i].Item1))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        protected void DecreaseKey(int index)
        {
            int parent = (index - 1) / 2;

            if (parent < 0)
            {
                return;
            }

            if (mapDistance[parent].Item2 > mapDistance[index].Item2)
            {
                Swap(parent, index);
                DecreaseKey(parent);
            }
        }

        protected void BuildHeap()
        {
            heapSize = mapDistance.Count;

            for (int i = (heapSize - 1) / 2; i >= 0; i--)
            {
                Heapify(i);
            }
        }

        protected void Heapify(int index)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int min = index;

            if (left < heapSize && mapDistance[left].Item2 < mapDistance[min].Item2)
            {
                min = left;
            }

            if (right < heapSize && mapDistance[right].Item2 < mapDistance[min].Item2)
            {
                min = right;
            }

            if (min != index)
            {
                Swap(min, index);
                Heapify(min);
            }
        }

        protected Tuple<T, int> Peek()
        {
            return mapDistance[0];
        }

        protected Tuple<T, int> Pop()
        {
            Swap(0, heapSize - 1);
            heapSize--;
            Heapify(0);
            return mapDistance[heapSize];
        }

        protected void Swap(int index1, int index2)
        {
            Tuple<T, int> tmp = mapDistance[index1];
            mapDistance[index1] = mapDistance[index2];
            mapDistance[index2] = tmp;
        }
    }
}