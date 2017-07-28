using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Permutations
    {
        [Fact]
        public void PermuteSubset()
        {
            List<List<char>> result = Permutations.PermuteSubset(new char[] {'a', 'b', 'c'}, 2);

            Assert.Equal(6, result.Count);
        }
    }
}