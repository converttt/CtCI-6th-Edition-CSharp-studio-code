using System;
using System.Collections.Generic;
using Xunit;
using CH_04._Trees_and_Graphs;
using lib_ctci;

namespace test_ctci
{
    public class Test_Chapter04_Q4_Successor
    {
        private Q06_Successor<int> successor = new Q06_Successor<int>();

        [Fact]
        public void FindSuccessor()
        {
            CtciTreeNode<int> node1 = new CtciTreeNode<int>(1);
            node1.Children.Add(null);
            node1.Children.Add(null);

            CtciTreeNode<int> node2 = new CtciTreeNode<int>(2);
            node2.Children.Add(null);
            node2.Children.Add(null);

            CtciTreeNode<int> node3 = new CtciTreeNode<int>(3);
            node3.Children.Add(null);
            node3.Children.Add(null);

            CtciTreeNode<int> node4 = new CtciTreeNode<int>(4);
            node4.Children.Add(null);
            node4.Children.Add(null);

            CtciTreeNode<int> node5 = new CtciTreeNode<int>(5);
            node5.Children.Add(null);
            node5.Children.Add(null);

            CtciTreeNode<int> node6 = new CtciTreeNode<int>(6);
            node6.Children.Add(null);
            node6.Children.Add(null);

            CtciTreeNode<int> node7 = new CtciTreeNode<int>(7);
            node7.Children.Add(null);
            node7.Children.Add(null);

            CtciTreeNode<int> node8 = new CtciTreeNode<int>(8);
            node8.Children.Add(null);
            node8.Children.Add(null);

            CtciTreeNode<int> node9 = new CtciTreeNode<int>(9);
            node9.Children.Add(null);
            node9.Children.Add(null);

            node1.Left = node2;
            node2.Parent = node1;

            node1.Right = node3;
            node3.Parent = node1;

            node3.Left = node6;
            node6.Parent = node3;
            node3.Right = node7;
            node7.Parent = node3;

            node2.Left = node4;
            node4.Parent = node2;
            node2.Right = node5;
            node5.Parent = node2;

            node5.Left = node8;
            node8.Parent = node5;
            node5.Right = node9;
            node9.Parent = node5;

            Assert.Equal(successor.FindSuccessor(node9), node1);
            Assert.Equal(successor.FindSuccessor(node8), node5);
            Assert.Equal(successor.FindSuccessor(node5), node9);
            Assert.Equal(successor.FindSuccessor(node2), node8);

            Assert.NotEqual(successor.FindSuccessor(node2), node4);
        }
    }
}