using System;
using Xunit;
using CH_01._Array_and_Strings;

namespace test_ctci
{
    public class Test_Chapter01_Q7_Rotate_Matrix
    {
        private Q07_Rotate_Matrix rotateMatrix = new Q07_Rotate_Matrix();

        [Fact]
        public void Rotate()
        {
            int[,] matrix = GetDefaultMatrix();

            rotateMatrix.Rotate(matrix, 4);
            Assert.Equal(new [,] {
                {0, 1, 0, 1},
                {0, 1, 1, 1},
                {0, 0, 0, 1},
                {0, 0, 1, 1}
            }, matrix);

            rotateMatrix.Rotate(matrix, 4);
            Assert.Equal(new [,] {
                {0, 0, 0, 0},
                {0, 0, 1, 1},
                {1, 0, 1, 0},
                {1, 1, 1, 1}
            }, matrix);

            Assert.NotEqual(new [,] {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0}
            }, matrix);
        }

        public int[,] GetDefaultMatrix()
        {
            return new int[,] {
                {1, 1, 1, 1},
                {0, 1, 0, 1},
                {1, 1, 0, 0},
                {0, 0, 0, 0}
            };
        }
    }
}