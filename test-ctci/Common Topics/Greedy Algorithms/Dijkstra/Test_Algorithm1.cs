using System;
using System.Collections.Generic;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Dijkstra_Algorithm1
    {
        private Dijkstra_Algorithm1<string> dijkstra = new Dijkstra_Algorithm1<string>();

        [Fact]
        public void FindShortestPath()
        {
            Dijkstra_Graph1<string> graph = new Dijkstra_Graph1<string>();

            graph.AddVertice("a");
            graph.AddVertice("b");
            graph.AddVertice("c");
            graph.AddVertice("d");
            graph.AddVertice("e");
            graph.AddVertice("f");

            graph.AddEdge("a", "b");
            graph.AddEdge("b", "c");
            graph.AddEdge("c", "d");
            graph.AddEdge("a", "c");
            graph.AddEdge("d", "e");
            graph.AddEdge("c", "e");

            Func<string, List<string>> PathFromA = dijkstra.FindShortestPath(graph, "a");
            List<string> result1 = PathFromA("d");
            List<string> result2 = PathFromA("e");
            List<string> result3 = PathFromA("f");

            Assert.Equal(new string[] {"a", "c", "d"}, result1.ToArray());
            Assert.Equal(new string[] {"a", "c", "e"}, result2.ToArray());
            Assert.Equal(new string[] {}, result3.ToArray());
        }
    }
}