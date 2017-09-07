using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_LIS
    {
        [Fact]
        public void TestLIS()
        {
            Assert.Equal(6, LIS.FindMax(new int[] {
                10, 22, 9, 33, 21, 50, 41, 60, 80
            }));

            Assert.Equal(3, LIS.FindMax(new int[] {
                3, 10, 2, 1, 20
            }));
        }
    }
}