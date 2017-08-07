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
    }
}