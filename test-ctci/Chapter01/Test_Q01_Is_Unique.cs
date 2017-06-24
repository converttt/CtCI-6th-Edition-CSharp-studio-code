using System;
using Xunit;
using CH_01._Array_and_Strings;

namespace test_ctci
{
    public class Test_Chapter01_Q1_Is_Unique
    {
        Q01_Is_Unique isUnique = new Q01_Is_Unique();

        [Fact]
        public void IsUniqueChar1()
        {
            Assert.True(isUnique.IsUniqueChar1("abcde"));
            Assert.True(isUnique.IsUniqueChar1("padle"));

            Assert.False(isUnique.IsUniqueChar1("Hello World!"));
            Assert.False(isUnique.IsUniqueChar1("pineapple"));
        }

        public void IsUniqueChar2()
        {
            Assert.True(isUnique.IsUniqueChar1("abcde"));
            Assert.True(isUnique.IsUniqueChar1("padle"));

            Assert.False(isUnique.IsUniqueChar1("Hello World!"));
            Assert.False(isUnique.IsUniqueChar1("pineapple"));
        }
    }
}