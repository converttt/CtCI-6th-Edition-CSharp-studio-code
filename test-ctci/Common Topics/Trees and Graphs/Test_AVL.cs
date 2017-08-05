using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_AVL
    {
        [Fact]
        public void Insertion()
        {
            AVL_Node node15 = new AVL_Node(15);
            AVL_Node node9 = new AVL_Node(9);
            AVL_Node node6 = new AVL_Node(6);

            AVL_Tree avlTree = new AVL_Tree(node15);

            // Left Left Case
            avlTree.Insert(node9);
            avlTree.Insert(node6);

            Assert.Equal(node9, avlTree.Root);
            Assert.Equal(node6, avlTree.Root.Left);
            Assert.Equal(node15, avlTree.Root.Right);

            // Left Right Case
            AVL_Node node5 = new AVL_Node(5);
            AVL_Node node7 = new AVL_Node(7);
            AVL_Node node8 = new AVL_Node(8);

            avlTree.Insert(node5);
            avlTree.Insert(node7);
            avlTree.Insert(node8);

            Assert.Equal(node7, avlTree.Root);
            Assert.Equal(node9, avlTree.Root.Right);
            Assert.Equal(node8, avlTree.Root.Right.Left);
            Assert.Equal(node6, avlTree.Root.Left);

            // Right Right Case
            AVL_Node node20 = new AVL_Node(20);
            AVL_Node node25 = new AVL_Node(25);

            avlTree.Insert(node20);
            avlTree.Insert(node25);

            Assert.Equal(node20, avlTree.Root.Right.Right);
            Assert.Equal(node15, avlTree.Root.Right.Right.Left);
            Assert.Equal(node25, avlTree.Root.Right.Right.Right);

            // Right Left Case
            AVL_Node node40 = new AVL_Node(40);
            AVL_Node node35 = new AVL_Node(35);
            AVL_Node node50 = new AVL_Node(50);
            AVL_Node node47 = new AVL_Node(47);
            AVL_Node node48 = new AVL_Node(48);

            avlTree = new AVL_Tree(node40);

            avlTree.Insert(node35);
            avlTree.Insert(node47);
            avlTree.Insert(node50);
            avlTree.Insert(node48);

            Assert.Equal(node48, avlTree.Root.Right);
            Assert.Equal(node47, avlTree.Root.Right.Left);
            Assert.Equal(node50, avlTree.Root.Right.Right);
        }
    }
}