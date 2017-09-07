using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Ugly_Numbers
    {
        [Fact]
        public void TestUglyNumbers()
        {
            Assert.Equal(5832, Ugly_Numbers.GetUglyNumber(150));
        }
    }
}