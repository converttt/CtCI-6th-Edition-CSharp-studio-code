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

        [Fact]
        public void Intervealed()
        {
            Assert.Equal(false, Is_Subsequence.Intervealed("XXY", "XXZ", "XXZXXXY"));
            Assert.Equal(true, Is_Subsequence.Intervealed("XY", "WZ", "WZXXXY"));
            Assert.Equal(true, Is_Subsequence.Intervealed("XY", "X", "XXY"));
            Assert.Equal(false, Is_Subsequence.Intervealed("YX", "X", "XXY"));
            Assert.Equal(true, Is_Subsequence.Intervealed("XXY", "XXZ", "XXXXZY"));
        }
    }
}