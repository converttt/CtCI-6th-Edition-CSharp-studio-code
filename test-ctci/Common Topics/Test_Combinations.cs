using System;
using System.Collections.Generic;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Combinations
    {
        [Fact]
        public void Combinations1()
        {
            List<List<int>> result = Combinations.CombinationProblem1(new int[] {1, 2, 3});

            Assert.Equal(result.Count, 7);
        }
    }
}