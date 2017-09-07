using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Optimal_Strategy
    {
        [Fact]
        public void TestStrategy()
        {
            Assert.Equal(22, Optimal_Strategy.FindMaxValue(new int[] {
                8, 15, 3, 7
            }, 0, 3));

            Assert.Equal(4, Optimal_Strategy.FindMaxValue(new int[] {
                2, 2, 2, 2
            }, 0, 3));

            Assert.Equal(42, Optimal_Strategy.FindMaxValue(new int[] {
                20, 30, 2, 2, 2, 10
            }, 0, 5));

            Assert.Equal(22, Optimal_Strategy.FindMaxValue2(new int[] {
                8, 15, 3, 7
            }));

            Assert.Equal(4, Optimal_Strategy.FindMaxValue2(new int[] {
                2, 2, 2, 2
            }));

            Assert.Equal(42, Optimal_Strategy.FindMaxValue2(new int[] {
                20, 30, 2, 2, 2, 10
            }));
        }
    }
}