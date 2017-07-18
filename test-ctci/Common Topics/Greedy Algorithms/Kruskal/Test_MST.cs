using System;
using System.Collections.Generic;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Kruskal_MST
    {
        [Fact]
        public void Build_MST()
        {
            Kruskal_MST<string> kruskal = new Kruskal_MST<string>();
            
            Kruskal_Graph<string> graph = new Kruskal_Graph<string>();
            graph.AddVertice("a");
            graph.AddVertice("b");
            graph.AddVertice("c");
            graph.AddVertice("d");

            Kruskal_Edge<string> edge1 = new Kruskal_Edge<string>("a", "b", 10);
            Kruskal_Edge<string> edge2 = new Kruskal_Edge<string>("b", "d", 15);
            Kruskal_Edge<string> edge3 = new Kruskal_Edge<string>("d", "c", 4);
            Kruskal_Edge<string> edge4 = new Kruskal_Edge<string>("c", "a", 6);
            Kruskal_Edge<string> edge5 = new Kruskal_Edge<string>("a", "d", 5);

            graph.AddEdge(edge1);
            graph.AddEdge(edge2);
            graph.AddEdge(edge3);
            graph.AddEdge(edge4);
            graph.AddEdge(edge5);

            graph.SetNonDecreasingOrderOfEdges();

            List<Kruskal_Edge<string>> mst = kruskal.Build_MST(graph);

            Assert.Equal(3, mst.Count);
            Assert.Equal(new List<Kruskal_Edge<string>>(
                new Kruskal_Edge<string>[] {
                    edge3, edge5, edge1
                }
            ), kruskal.Build_MST(graph));
        }
    }
}