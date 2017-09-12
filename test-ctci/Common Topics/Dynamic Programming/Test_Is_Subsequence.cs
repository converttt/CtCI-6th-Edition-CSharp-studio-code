using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Is_Subsequence
    {
        [Fact]
        public void IsSubsequence()
        {
            Assert.Equal(true, Is_Subsequence.IsSubsequence("AXY", "ADXCPY"));
            Assert.Equal(false, Is_Subsequence.IsSubsequence("AXY", "YADXCP"));
            Assert.Equal(true, Is_Subsequence.IsSubsequence("gksrek", "geeksforgeeks"));
        }
    }
}