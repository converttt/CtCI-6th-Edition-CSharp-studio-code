using System;
using System.Collections.Generic;
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

        [Fact]
        public void Solution3()
        {
            List<int>[] res = Sets.Solution3(new int[] {1, 2, 3});
            Assert.Equal(res[1].Count, 1);
            Assert.Equal(res[1][0], 1);
            Assert.Equal(res[6].Count, 2);
            Assert.Equal(res[6][1], 3);
            Assert.Equal(res[6][0], 2);
        }

        [Fact]
        public void CloseSum()
        {
            Assert.Equal(Sets.Solution4(new int[] {1, 6, 11, 5}), 1);
            Assert.Equal(Sets.Solution4(new int[] {3, 1, 4, 2, 2, 1}), 1);

            Assert.Equal(Sets.Solution5(new int[] {1, 6, 11, 5}), 1);
            Assert.Equal(Sets.Solution5(new int[] {3, 1, 4, 2, 2, 1}), 1);
        }
    }
}