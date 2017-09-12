using System;
using System.Collections.Generic;

namespace Common_Topics
{
    public class Graphs_Graph
    {
        private HashSet<int> _nodes = new HashSet<int>();
        private Dictionary<int, HashSet<int>> _edges = new Dictionary<int, HashSet<int>>();

        public void AddNode(int id)
        {
            _nodes.Add(id);
            _edges.Add(id, new HashSet<int>());
        }

        public void AddEdge(int start, int destination)
        {
            _edges[start].Add(destination);
        }

        public HashSet<int> Nodes
        {
            get
            {
                return _nodes;
            }
        }

        public Dictionary<int, HashSet<int>> Edges
        {
            get
            {
                return _edges;
            }
        }
    }

    public class Graphs
    {
        private Dictionary<int, bool> _visited = new Dictionary<int, bool>();
        private Graphs_Graph _graph;
        private List<LinkedList<int>> _result = new List<LinkedList<int>>();
        private LinkedList<int> _tmp = new LinkedList<int>();

        public Graphs(Graphs_Graph graph)
        {
            _graph = graph;
        }

        /*
            Print all paths from a given source to a destination in a directed graph.
         */
        public void AllPaths(int start, int destination)
        {
            foreach (int node in _graph.Nodes)
            {
                _visited[node] = false;
            }

            _AllPaths(start, destination);
        }

        private void _AllPaths(int start, int destination)
        {
            _visited[start] = true;
            _tmp.AddLast(start);

            if (start == destination)
            {
                _result.Add(new LinkedList<int>(_tmp));
                _visited[start] = false;
                _tmp.RemoveLast();
                return;
            }

            foreach (int dest in _graph.Edges[start])
            {
                if (_visited[dest] == false)
                {
                    _AllPaths(dest, destination);
                }
            }

            _visited[start] = false;
            _tmp.RemoveLast();
        }

        public List<LinkedList<int>> Result
        {
            get
            {
                return _result;
            }
        }
    }
}