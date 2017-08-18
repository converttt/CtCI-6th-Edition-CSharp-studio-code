using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Medians
    {
        [Fact]
        public void TestMedianOfEqual()
        {
            int[] a = new int[] {1, 12, 15, 26, 38};
            int[] b = new int[] {2, 13, 17, 30, 45};
            
            // int result = Medians.MedianOfEqual(a, b);

            // Assert.Equal(16, result);

            a = new int[] {1, 2, 3, 6};
            b = new int[] {4, 6, 8, 10};

            int result = Medians.MedianOfEqual(a, b);

            Assert.Equal(5, result);
        }
    }
}