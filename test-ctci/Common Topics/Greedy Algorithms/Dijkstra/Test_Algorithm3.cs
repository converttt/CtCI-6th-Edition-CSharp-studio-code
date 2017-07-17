using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Dijkstra_Algorithm3
    {
        [Fact]
        public void FindShortestPath()
        {
            Dijkstra_Algorithm3<string> dijkstra = new Dijkstra_Algorithm3<string>();

            dijkstra.AddVertice("a");
            dijkstra.AddVertice("b");
            dijkstra.AddVertice("c");
            dijkstra.AddVertice("d");
            dijkstra.AddVertice("e");

            dijkstra.AddEdge("a", "b", 10);
            dijkstra.AddEdge("a", "c", 10);
            dijkstra.AddEdge("b", "c", 12);
            dijkstra.AddEdge("a", "d", 20);
            dijkstra.AddEdge("c", "e", 6);
            dijkstra.AddEdge("d", "e", 1);

            dijkstra.BuildMap("a");

            Assert.Equal(new string[] {"a", "c", "e", "d"}, dijkstra.GetShortestPath("a", "d").ToArray());
            Assert.Equal(new string[] {"b", "c", "e", "d"}, dijkstra.GetShortestPath("b", "d").ToArray());
            Assert.Equal(new string[] {"d", "e", "c", "a"}, dijkstra.GetShortestPath("d", "a").ToArray());

            Assert.Equal(17, dijkstra.GetShortestDistance("a", "d"));
            Assert.Equal(19, dijkstra.GetShortestDistance("b", "d"));
            Assert.Equal(17, dijkstra.GetShortestDistance("d", "a"));
        }
    }
}