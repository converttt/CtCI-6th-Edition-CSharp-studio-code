using System;
using Xunit;
using CH_01._Array_and_Strings;

namespace test_ctci
{
    public class Test_Chapter01_Q4_Palindrome_Permutation
    {
        private Q04_Palindrome_Permutation palindromePerm = new Q04_Palindrome_Permutation();

        [Fact]
        public void PalindromePerm1()
        {
            Assert.True(palindromePerm.PalindromePerm1("aabb"));
            Assert.True(palindromePerm.PalindromePerm1("aa bb"));
            Assert.True(palindromePerm.PalindromePerm1("tactcoa"));
            Assert.True(palindromePerm.PalindromePerm1("TaccToa"));
            
            Assert.False(palindromePerm.PalindromePerm1("Tact Coa"));
            Assert.False(palindromePerm.PalindromePerm1("code core"));

            Assert.True(palindromePerm.PalindromePerm1("a man a plan a canal panama"));
        }
    }
}