using System;
using System.Collections.Generic;
using Xunit;
using CH_04._Trees_and_Graphs;
using lib_ctci;

namespace test_ctci
{
    public class Test_Chapter04_Q8_Common_Ancestor
    {
        private Q08_Common_Ancestor<int> commonAncestor = new Q08_Common_Ancestor<int>();

        [Fact]
        public void FindAncestor()
        {
            CtciTreeNode<int> node1 = CtciTreeNode<int>.CtciBinaryTreeNode(1);
            CtciTreeNode<int> node2 = CtciTreeNode<int>.CtciBinaryTreeNode(2);
            CtciTreeNode<int> node3 = CtciTreeNode<int>.CtciBinaryTreeNode(3);
            CtciTreeNode<int> node4 = CtciTreeNode<int>.CtciBinaryTreeNode(4);
            CtciTreeNode<int> node5 = CtciTreeNode<int>.CtciBinaryTreeNode(5);
            CtciTreeNode<int> node6 = CtciTreeNode<int>.CtciBinaryTreeNode(6);
            CtciTreeNode<int> node7 = CtciTreeNode<int>.CtciBinaryTreeNode(7);
            CtciTreeNode<int> node8 = CtciTreeNode<int>.CtciBinaryTreeNode(8);
            CtciTreeNode<int> node9 = CtciTreeNode<int>.CtciBinaryTreeNode(9);
            CtciTreeNode<int> node10 = CtciTreeNode<int>.CtciBinaryTreeNode(10);
            CtciTreeNode<int> node11 = CtciTreeNode<int>.CtciBinaryTreeNode(11);
            CtciTreeNode<int> node12 = CtciTreeNode<int>.CtciBinaryTreeNode(12);

            node1.Left = node2;
            node1.Right = node3;

            node2.Left = node4;
            node2.Right = node5;

            node4.Left = node8;
            node4.Right = node9;

            node5.Left = node10;
            node5.Right = node11;

            node3.Left = node6;
            node3.Right = node7;

            node7.Left = node12;

            Assert.Equal(node2, commonAncestor.FindAncestor(node1, node9, node10));
            Assert.Equal(node3, commonAncestor.FindAncestor(node1, node6, node12));
            Assert.Equal(node3, commonAncestor.FindAncestor(node1, node3, node12));
            Assert.Equal(node1, commonAncestor.FindAncestor(node1, node8, node7));
        }
    }
}