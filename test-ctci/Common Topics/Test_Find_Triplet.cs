using System;
using System.Collections.Generic;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Find_Triplet
    {
        [Fact]
        public void EqualTriple1()
        {
            List<int[]> triplets = Find_Triplet.EqualTriplets2(new int[] {0, -1, 2, -3, 1}, 0);

            Assert.Equal(2, triplets.Count);
            Assert.Equal(0, SumOfInt(triplets[0]));
            Assert.Equal(0, SumOfInt(triplets[1]));
        }


        [Fact]
        public void EqualTriplets2()
        {
            List<int[]> triplets = Find_Triplet.EqualTriplets2(new int[] {0, -1, 2, -3, 1}, 0);

            Assert.Equal(2, triplets.Count);
            Assert.Equal(0, SumOfInt(triplets[0]));
            Assert.Equal(0, SumOfInt(triplets[1]));
        }

        protected int SumOfInt(int[] arr)
        {
            int sum = 0;
            foreach (int item in arr)
            {
                sum += item;
            }
            return sum;
        }
    }
}