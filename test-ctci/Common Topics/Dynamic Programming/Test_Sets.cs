using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Sets
    {
        [Fact]
        public void TestSets()
        {
            Assert.True(Sets.Solution1(new int[] {1, 5, 11, 5}));
            Assert.False(Sets.Solution1(new int[] {1, 5, 3}));
            Assert.True(Sets.Solution1(new int[] {3, 1, 1, 2, 2, 1}));

            Assert.True(Sets.Solution2(new int[] {1, 5, 11, 5}));
            Assert.False(Sets.Solution2(new int[] {1, 5, 3}));
            Assert.True(Sets.Solution2(new int[] {3, 1, 1, 2, 2, 1}));
        }
    }
}