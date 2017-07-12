using System;
using Xunit;
using CH_05._Bit_Manipulations;

namespace test_ctci
{
    public class Test_Chapter05_Q1_Insertion
    {
        private Q01_Insertion insertion = new Q01_Insertion();

        [Fact]
        public void Insertion()
        {
            int a = 0b1111;
            int b = 0b10;

            Assert.Equal(0b1011, insertion.Insert(a, b, 2, 3));

            a = 0b1000000000;
            b = 0b10011;

            string result = Convert.ToString(insertion.Insert(a, b, 2, 6), 2);

            Assert.Equal(0b1001001100, insertion.Insert(a, b, 2, 6));
        }
    }
}