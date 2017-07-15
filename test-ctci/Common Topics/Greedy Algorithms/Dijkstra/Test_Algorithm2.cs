using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Dijkstra_Algorithm2
    {
        [Fact]
        public void FindPath()
        {
            int[,] graph = new int[,]{
                {0 , 10, 10, 20, 0 },
                {10, 0 , 12, 0 , 0 },
                {10, 12, 0 , 8 , 6 },
                {20, 0 , 8 , 0 , 1 },
                {0 , 0 , 6 , 1 , 0 }
            };

            Dijkstra_Algorithm2 dijkstra = new Dijkstra_Algorithm2(graph);

            dijkstra.BuildMap(0);

            Assert.Equal(new int[] {0, 2, 4, 3}, dijkstra.FindShortestPath(0, 3).Item2.ToArray());
            Assert.Equal(17, dijkstra.FindShortestPath(0, 3).Item1);
            Assert.Equal(new int[] {1, 2, 4, 3}, dijkstra.FindShortestPath(1, 3).Item2.ToArray());
            Assert.Equal(19, dijkstra.FindShortestPath(1, 3).Item1);
        }
    }
}