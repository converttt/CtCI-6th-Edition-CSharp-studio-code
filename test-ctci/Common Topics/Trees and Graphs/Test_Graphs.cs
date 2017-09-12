using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Graphs
    {
        [Fact]
        public void AllPaths()
        {
            Graphs_Graph graph = new Graphs_Graph();
            graph.AddNode(0);
            graph.AddNode(1);
            graph.AddNode(2);
            graph.AddNode(3);

            graph.AddEdge(0, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(0, 3);
            graph.AddEdge(0, 1);
            graph.AddEdge(2, 1);
            graph.AddEdge(1, 3);

            Graphs graphs = new Graphs(graph);
            graphs.AllPaths(2, 3);

            Assert.Equal(3, graphs.Result.Count);
        }
    }
}