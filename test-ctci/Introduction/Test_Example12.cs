using System;
using System.Collections.Generic;
using Xunit;
using Introduction;

namespace test_ctci
{
    public class Test_Exmaple12
    {
        private Example12 example = new Example12();

        [Fact]
        public void FindPermutations()
        {
            List<string> results = example.GetPermutations("abc");

            Assert.Equal(6, results.Count);
            Assert.Equal("abc", results[0]);
            Assert.Equal("bac", results[2]);
        }
    }
}