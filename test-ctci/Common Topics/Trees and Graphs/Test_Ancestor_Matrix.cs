using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Ancestor_Matrix
    {
        [Fact]
        public void BuildMatrix()
        {
            Ancestor_Matrix_Node node5 = new Ancestor_Matrix_Node(5);
            Ancestor_Matrix_Node node1 = new Ancestor_Matrix_Node(1);
            Ancestor_Matrix_Node node2 = new Ancestor_Matrix_Node(2);
            Ancestor_Matrix_Node node0 = new Ancestor_Matrix_Node(0);
            Ancestor_Matrix_Node node4 = new Ancestor_Matrix_Node(4);
            Ancestor_Matrix_Node node3 = new Ancestor_Matrix_Node(3);

            node5.Left = node1;
            node5.Right = node2;

            node1.Left = node0;
            node1.Right = node4;

            node2.Right = node3;

            int[,] template = new int[,] {
                {0, 0, 0, 0, 0, 0},
                {1, 0, 0, 0, 1, 0},
                {0, 0, 0, 1, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {1, 1, 1, 1, 1, 0}
            };

            int[,] result = Ancestor_Matrix.BuildMatrix(node5);

            Assert.Equal(template, result);
        }

        [Fact]
        public void BuildTree()
        {
            int[,] template = new int[,] {
                {0, 0, 0, 0, 0, 0},
                {1, 0, 0, 0, 1, 0},
                {0, 0, 0, 1, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {1, 1, 1, 1, 1, 0}
            };

            Ancestor_Matrix_Node result = Ancestor_Matrix.BuildTree(template);

            Assert.Equal(5, result.ID);
            Assert.True(result.Left.ID == 1 || result.Left.ID == 2);
            Assert.True(result.Left.Left.ID == 0 || result.Left.Left.ID == 3 || result.Left.Left.ID == 4);
        }
    }
}