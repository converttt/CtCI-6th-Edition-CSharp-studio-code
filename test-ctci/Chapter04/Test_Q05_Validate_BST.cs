using System;
using System.Collections.Generic;
using Xunit;
using CH_04._Trees_and_Graphs;
using lib_ctci;

namespace test_ctci
{
    public class Test_Chapter04_Q5_Successor
    {
        private Q05_Validate_BST validateBst = new Q05_Validate_BST();

        [Fact]
        public void Validate()
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

            node5.Left = node3;
            node5.Right = node8;

            node3.Left = node2;
            node3.Right = node4;

            node2.Left = node1;

            node8.Left = node6;
            node8.Right = node9;

            node6.Right = node7;

            Assert.True(validateBst.Validate(node5));

            node6.Left = node7;

            Assert.False(validateBst.Validate(node5));
        }
    }
}