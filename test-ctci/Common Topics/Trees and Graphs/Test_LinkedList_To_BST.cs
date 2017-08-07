using System;
using System.Collections.Generic;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_LinkedList_To_BST
    {
        [Fact]
        public void TestBuildTree1()
        {
            LinkedList<int> linkedList = new LinkedList<int>(new int[] {
                1, 2, 3, 4, 5, 6, 7
            });

            LinkedList_To_BST_Node head = LinkedList_To_BST.BuildTree1(linkedList);

            Assert.Equal(4, head.ID);
            Assert.Equal(2, head.Left.ID);
            Assert.Equal(6, head.Right.ID);
            Assert.Equal(1, head.Left.Left.ID);
            Assert.Equal(3, head.Left.Right.ID);
        }

        [Fact]
        public void TestBuildTree2()
        {
            LinkedList<int> linkedList = new LinkedList<int>(new int[] {
                1, 2, 3, 4, 5, 6, 7
            });

            LinkedList_To_BST_Node head = LinkedList_To_BST.BuildTree2(linkedList);

            Assert.Equal(4, head.ID);
            Assert.Equal(2, head.Left.ID);
            Assert.Equal(6, head.Right.ID);
            Assert.Equal(1, head.Left.Left.ID);
            Assert.Equal(3, head.Left.Right.ID);
        }

        [Fact]
        public void TestBuildBalancedTreeFromTree()
        {
            LinkedList_To_BST_Node node1 = new LinkedList_To_BST_Node(1);
            LinkedList_To_BST_Node node2 = new LinkedList_To_BST_Node(2);
            LinkedList_To_BST_Node node3 = new LinkedList_To_BST_Node(3);
            LinkedList_To_BST_Node node4 = new LinkedList_To_BST_Node(4);
            LinkedList_To_BST_Node node5 = new LinkedList_To_BST_Node(5);
            LinkedList_To_BST_Node node6 = new LinkedList_To_BST_Node(6);
            LinkedList_To_BST_Node node7 = new LinkedList_To_BST_Node(7);

            node4.Left = node3;
            node3.Left = node2;
            node2.Left = node1;

            node4.Right = node5;
            node5.Right = node6;
            node6.Right = node7;

            LinkedList_To_BST_Node head = LinkedList_To_BST.BuildBalancedTreeFromTree(node4);

            Assert.Equal(4, head.ID);
            Assert.Equal(2, head.Left.ID);
            Assert.Equal(6, head.Right.ID);
            Assert.Equal(1, head.Left.Left.ID);
            Assert.Equal(3, head.Left.Right.ID);
        }
    }
}