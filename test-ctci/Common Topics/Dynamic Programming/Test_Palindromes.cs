using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Palindromes
    {
        [Fact]
        public void TestFindInsertions()
        {
            Assert.Equal(1, Palindromes.FindInsertions("ab"));
            Assert.Equal(0, Palindromes.FindInsertions("aa"));
            Assert.Equal(3, Palindromes.FindInsertions("abcd"));
            Assert.Equal(2, Palindromes.FindInsertions("abcda"));
            Assert.Equal(4, Palindromes.FindInsertions("abcde"));
        }
    }
}