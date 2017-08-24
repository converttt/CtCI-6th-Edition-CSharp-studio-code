using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_CoinChange
    {
        [Fact]
        public void Count()
        {
            Assert.Equal(5, CoinChange.Count(new int[] {2, 5, 3, 6}, 4, 10));
        }
    }
}