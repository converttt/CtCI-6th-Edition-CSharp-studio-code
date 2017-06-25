using System;
using Xunit;
using CH_01._Array_and_Strings;

namespace test_ctci
{
    public class Test_Chapter01_Q2_Check_Permutation
    {
        private Q02_Check_Permutation permutation = new Q02_Check_Permutation();

        [Fact]
        public void IsPermutation1()
        {
            Assert.True(permutation.IsPermutation1("Bat", "taB"));
            Assert.True(permutation.IsPermutation1("pine, apple", "apple, pine"));
            Assert.True(permutation.IsPermutation1("credit", "direct"));

            Assert.False(permutation.IsPermutation1("credit", "direcT"));
            Assert.False(permutation.IsPermutation1("hello world", "howdy world"));
        }

        [Fact]
        public void IsPermutation2()
        {
            Assert.True(permutation.IsPermutation1("Bat", "taB"));
            Assert.True(permutation.IsPermutation1("pine, apple", "apple, pine"));
            Assert.True(permutation.IsPermutation1("credit", "direct"));

            Assert.False(permutation.IsPermutation1("credit", "direcT"));
            Assert.False(permutation.IsPermutation1("hello world", "howdy world"));
        }
    }
}