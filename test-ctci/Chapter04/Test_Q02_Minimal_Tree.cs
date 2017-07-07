using System;
using System.Collections.Generic;
using Xunit;
using CH_04._Trees_and_Graphs;
using lib_ctci;

namespace test_ctci
{
    public class Test_Chapter04_Q2_Minimal_Tree
    {
        private Q02_Minimal_Tree minimal = new Q02_Minimal_Tree();

        [Fact]
        public void CreateMinimalHeight()
        {
            int[] sortedArr1 = new int[] {1, 2, 3, 4, 5, 6, 7};
            int[] sortedArr2 = new int[] {1, 2, 3, 4, 5};

            CtciTreeNode<int> node1 = CtciTreeNode<int>.CtciBinaryTreeNode(1);
            CtciTreeNode<int> node2 = CtciTreeNode<int>.CtciBinaryTreeNode(2);
            CtciTreeNode<int> node3 = CtciTreeNode<int>.CtciBinaryTreeNode(3);
            CtciTreeNode<int> node4 = CtciTreeNode<int>.CtciBinaryTreeNode(4);
            CtciTreeNode<int> node5 = CtciTreeNode<int>.CtciBinaryTreeNode(5);
            CtciTreeNode<int> node6 = CtciTreeNode<int>.CtciBinaryTreeNode(6);
            CtciTreeNode<int> node7 = CtciTreeNode<int>.CtciBinaryTreeNode(7);

            node4.Left = node2;
            node4.Right = node6;

            node2.Left = node1;
            node2.Right = node3;

            node6.Left = node5;
            node6.Right = node7;

            CtciTreeNode<int> result = minimal.CreateMinimalHeight(sortedArr1);

            Assert.True(node4.Value == result.Value);
            Assert.True(node4.Left.Value == result.Left.Value);
            Assert.True(node4.Left.Left.Value == result.Left.Left.Value);
            Assert.True(node4.Left.Right.Value == result.Left.Right.Value);
            Assert.True(node4.Right.Value == result.Right.Value);
            Assert.True(node4.Right.Left.Value == result.Right.Left.Value);
            Assert.True(node4.Right.Right.Value == result.Right.Right.Value);

            node1 = CtciTreeNode<int>.CtciBinaryTreeNode(1);
            node2 = CtciTreeNode<int>.CtciBinaryTreeNode(2);
            node3 = CtciTreeNode<int>.CtciBinaryTreeNode(3);
            node4 = CtciTreeNode<int>.CtciBinaryTreeNode(4);
            node5 = CtciTreeNode<int>.CtciBinaryTreeNode(5);

            result = minimal.CreateMinimalHeight(sortedArr2);

            node3.Left = node1;
            node3.Right = node4;

            node1.Right = node2;

            node4.Right = node5;

            Assert.True(node3.Value == result.Value);
            Assert.True(node3.Left.Value == result.Left.Value);
            Assert.True(node3.Right.Value == result.Right.Value);
            Assert.True(node3.Left.Right.Value == result.Left.Right.Value);
            Assert.True(node3.Right.Right.Value == result.Right.Right.Value);
        }

        [Fact]
        public void CreateMinimalHeight2()
        {
            int[] sortedArr1 = new int[] {1, 2, 3, 4, 5, 6, 7};
            int[] sortedArr2 = new int[] {1, 2, 3, 4, 5};

            CtciTreeNode<int> node1 = CtciTreeNode<int>.CtciBinaryTreeNode(1);
            CtciTreeNode<int> node2 = CtciTreeNode<int>.CtciBinaryTreeNode(2);
            CtciTreeNode<int> node3 = CtciTreeNode<int>.CtciBinaryTreeNode(3);
            CtciTreeNode<int> node4 = CtciTreeNode<int>.CtciBinaryTreeNode(4);
            CtciTreeNode<int> node5 = CtciTreeNode<int>.CtciBinaryTreeNode(5);
            CtciTreeNode<int> node6 = CtciTreeNode<int>.CtciBinaryTreeNode(6);
            CtciTreeNode<int> node7 = CtciTreeNode<int>.CtciBinaryTreeNode(7);

            node4.Left = node2;
            node4.Right = node6;

            node2.Left = node1;
            node2.Right = node3;

            node6.Left = node5;
            node6.Right = node7;

            CtciTreeNode<int> result = minimal.CreateMinimalHeight2(sortedArr1);

            Assert.True(node4.Value == result.Value);
            Assert.True(node4.Left.Value == result.Left.Value);
            Assert.True(node4.Left.Left.Value == result.Left.Left.Value);
            Assert.True(node4.Left.Right.Value == result.Left.Right.Value);
            Assert.True(node4.Right.Value == result.Right.Value);
            Assert.True(node4.Right.Left.Value == result.Right.Left.Value);
            Assert.True(node4.Right.Right.Value == result.Right.Right.Value);

            node1 = CtciTreeNode<int>.CtciBinaryTreeNode(1);
            node2 = CtciTreeNode<int>.CtciBinaryTreeNode(2);
            node3 = CtciTreeNode<int>.CtciBinaryTreeNode(3);
            node4 = CtciTreeNode<int>.CtciBinaryTreeNode(4);
            node5 = CtciTreeNode<int>.CtciBinaryTreeNode(5);

            result = minimal.CreateMinimalHeight2(sortedArr2);

            node3.Left = node1;
            node3.Right = node4;

            node1.Right = node2;

            node4.Right = node5;

            Assert.True(node3.Value == result.Value);
            Assert.True(node3.Left.Value == result.Left.Value);
            Assert.True(node3.Right.Value == result.Right.Value);
            Assert.True(node3.Left.Right.Value == result.Left.Right.Value);
            Assert.True(node3.Right.Right.Value == result.Right.Right.Value);
        }
    }
}