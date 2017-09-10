using System;
using Xunit;
using Common_Topics;
using lib_ctci;

namespace test_ctci
{
    public class Test_Ancestor
    {
        [Fact]
        public void TestBinaryTree()
        {
            CtciTreeNode<int> node1 = CtciTreeNode<int>.CtciBinaryTreeNode(1);
            CtciTreeNode<int> node2 = CtciTreeNode<int>.CtciBinaryTreeNode(2);
            CtciTreeNode<int> node3 = CtciTreeNode<int>.CtciBinaryTreeNode(3);
            CtciTreeNode<int> node4 = CtciTreeNode<int>.CtciBinaryTreeNode(4);
            CtciTreeNode<int> node5 = CtciTreeNode<int>.CtciBinaryTreeNode(5);
            CtciTreeNode<int> node6 = CtciTreeNode<int>.CtciBinaryTreeNode(6);
            CtciTreeNode<int> node7 = CtciTreeNode<int>.CtciBinaryTreeNode(7);

            node1.Left = node2;
            node1.Right = node3;

            node2.Left = node4;
            node2.Right = node5;

            node3.Left = node6;
            node3.Right = node7;

            Assert.Equal(node2, Ancestor.FindFromBinaryTree(node1, 4, 5));
            Assert.Equal(node1, Ancestor.FindFromBinaryTree(node1, 4, 6));
            Assert.Equal(node1, Ancestor.FindFromBinaryTree(node1, 3, 4));
            Assert.Equal(node2, Ancestor.FindFromBinaryTree(node1, 2, 4));
        }

        [Fact]
        public void TestBinarySearchTree()
        {
            CtciTreeNode<int> node20 = CtciTreeNode<int>.CtciBinaryTreeNode(20);
            CtciTreeNode<int> node8 = CtciTreeNode<int>.CtciBinaryTreeNode(8);
            CtciTreeNode<int> node22 = CtciTreeNode<int>.CtciBinaryTreeNode(22);
            CtciTreeNode<int> node4 = CtciTreeNode<int>.CtciBinaryTreeNode(4);
            CtciTreeNode<int> node12 = CtciTreeNode<int>.CtciBinaryTreeNode(12);
            CtciTreeNode<int> node10 = CtciTreeNode<int>.CtciBinaryTreeNode(10);
            CtciTreeNode<int> node14 = CtciTreeNode<int>.CtciBinaryTreeNode(14);

            node20.Left = node8;
            node20.Right = node22;

            node8.Left = node4;
            node8.Right = node12;

            node12.Left = node10;
            node12.Right = node14;

            Assert.Equal(node12, Ancestor.FindFromBST(node20, 10, 14));
            Assert.Equal(node8, Ancestor.FindFromBST(node20, 14, 8));
            Assert.Equal(node20, Ancestor.FindFromBST(node20, 10, 22));
        }
    }
}