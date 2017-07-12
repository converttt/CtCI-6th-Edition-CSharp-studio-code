using System;
using System.Collections.Generic;
using Xunit;
using CH_04._Trees_and_Graphs;
using lib_ctci;

namespace test_ctci
{
    public class Test_Chapter04_Q9_BST_Sequence
    {
        private Q09_BST_Sequence<int> sequence = new Q09_BST_Sequence<int>();

        [Fact]
        public void BuildSequence()
        {
            CtciTreeNode<int> node1 = CtciTreeNode<int>.CtciBinaryTreeNode(1);
            CtciTreeNode<int> node2 = CtciTreeNode<int>.CtciBinaryTreeNode(2);
            CtciTreeNode<int> node3 = CtciTreeNode<int>.CtciBinaryTreeNode(3);
            CtciTreeNode<int> node4 = CtciTreeNode<int>.CtciBinaryTreeNode(4);
            CtciTreeNode<int> node5 = CtciTreeNode<int>.CtciBinaryTreeNode(5);
            CtciTreeNode<int> node6 = CtciTreeNode<int>.CtciBinaryTreeNode(6);

            node4.Left = node2;
            node4.Right = node6;

            List<LinkedList<int>> results1 = sequence.BuildSequence(node4);

            Assert.Equal(2, results1.Count);

            node2.Left = node1;

            List<LinkedList<int>> results2 = sequence.BuildSequence(node4);

            Assert.Equal(3, results2.Count);

            node2.Right = node3;

            List<LinkedList<int>> results3 = sequence.BuildSequence(node4);

            Assert.Equal(8, results3.Count);
        }
    }
}