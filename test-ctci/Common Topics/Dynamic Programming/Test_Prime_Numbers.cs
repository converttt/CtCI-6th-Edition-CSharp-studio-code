using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Prime_Numbers
    {
        [Fact]
        public void PrimeNumbers()
        {
            bool[] result = Prime_Numbers.AllTo(20);

            bool[] check = new bool[21];
            check[0] = true;
            check[1] = true;
            check[2] = true;
            check[3] = true;
            check[5] = true;
            check[7] = true;
            check[11] = true;
            check[13] = true;
            check[17] = true;
            check[19] = true;

            Assert.Equal(check, result);
        }
    }
}