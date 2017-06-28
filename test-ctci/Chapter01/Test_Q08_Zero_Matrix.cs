using System;
using Xunit;
using CH_01._Array_and_Strings;

namespace test_ctci
{
    public class Test_Chapter01_Q8_Rotate_Matrix
    {
        private Q08_Zero_Matrix zeroMatrix = new Q08_Zero_Matrix();

        [Fact]
        public void SetZeros()
        {
            int[,] matrix = GetDefaultMatrix();

            zeroMatrix.SetZeros(matrix);
            Assert.Equal(new [,] {
                {0, 0, 0, 0},
                {1, 0, 1, 0},
                {1, 0, 1, 0},
                {0, 0, 0, 0}
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
                {1, 1, 1, 0},
                {1, 1, 1, 1},
                {1, 1, 1, 1},
                {1, 0, 1, 1}
            };
        }
    }
}