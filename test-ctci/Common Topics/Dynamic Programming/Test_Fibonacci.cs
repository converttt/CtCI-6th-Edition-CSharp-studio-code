using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Fibonacci
    {
        [Fact]
        public void TestFibonacci()
        {
            Assert.Equal(13, Fibonacci.GetFibonacci(7));

            int[] lookup = new int[8];
            for (int i = 0; i < 8; i++)
            {
                lookup[i] = -1;
            }

            Assert.Equal(13, Fibonacci.GetFibonacci2(7, lookup));

            Assert.Equal(13, Fibonacci.GetFibonacci3(7));
        }
    }
}