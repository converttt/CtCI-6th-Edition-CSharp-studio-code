using System;
using Xunit;
using CH_04._Trees_and_Graphs;
using lib_ctci;

namespace test_ctci
{
    public class Test_Chapter04_Q1_Route_Between_Nodes
    {
        private Q01_Route_Between_Nodes route = new Q01_Route_Between_Nodes();

        [Fact]
        public void FindRoute()
        {
            int[,] graph = new int[,]{
                {0, 1, 0, 0, 0},
                {0, 0, 0, 0, 1},
                {0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0},
                {0, 0, 0, 1, 0}
            };

            Assert.True(route.FindRoute(graph, 0, 2));
            Assert.False(route.FindRoute(graph, 1, 0));
        }

        [Fact]
        public void FindRoute2()
        {
            CtciTreeNode<int> node1 = new CtciTreeNode<int>(1);
            CtciTreeNode<int> node2 = new CtciTreeNode<int>(1);
            CtciTreeNode<int> node3 = new CtciTreeNode<int>(1);
            CtciTreeNode<int> node4 = new CtciTreeNode<int>(1);
            CtciTreeNode<int> node5 = new CtciTreeNode<int>(1);

            node1.Children.Add(node2);
            node1.Children.Add(node4);

            node2.Children.Add(node5);

            node5.Children.Add(node3);

            Assert.True(route.FindRoute2(node1, node3));
            Assert.False(route.FindRoute2(node2, node1));
        }
    }
}