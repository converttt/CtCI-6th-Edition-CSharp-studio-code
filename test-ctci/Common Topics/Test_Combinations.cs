using System;
using System.Linq;
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

        [Fact]
        public void Combinations2()
        {
            List<List<int>> result = Combinations.CombinationProblem2(new int[] {1, 2, 3, 4}, 2);

            List<int> check = (from int i in Enumerable.Range(0, 4).ToList()
            select i).ToList();

            Assert.Equal(result.Count, 6);
        }
    }
}