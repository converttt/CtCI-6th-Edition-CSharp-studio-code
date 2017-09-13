using System;
using System.Collections.Generic;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Overlapping
    {
        [Fact]
        public void Intervals()
        {
            List<int[]> result = Overlapping.Intervals(new int[][] {
                new int[] {1, 3},
                new int[] {2, 4},
                new int[] {5, 7},
                new int[] {6, 8},
            });

            Assert.Equal(1, result[0][0]);
            Assert.Equal(4, result[0][1]);
            Assert.Equal(5, result[1][0]);
            Assert.Equal(8, result[1][1]);

            result = Overlapping.Intervals(new int[][] {
                new int[] {6, 8},
                new int[] {1, 9},
                new int[] {2, 4},
                new int[] {4, 7},
            });

            Assert.Equal(1, result[0][0]);
            Assert.Equal(9, result[0][1]);
        }
    }
}