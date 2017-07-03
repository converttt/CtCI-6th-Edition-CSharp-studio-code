using System;
using System.Collections.Generic;
using Xunit;
using CH_02._Linked_Lists;

namespace test_ctci
{
    public class Test_Chapter02_Q5_Sum_Lists
    {
        private Q05_Sum_Lists sumLists = new Q05_Sum_Lists();

        [Fact]
        public void SumLists()
        {
            LinkedList<int> list1 = new LinkedList<int>(new int[] {6, 1, 7});
            LinkedList<int> list2 = new LinkedList<int>(new int[] {1, 9, 2, 0, 7});

            Assert.Equal(new LinkedList<int>(new int[] {7, 0, 0, 1, 7}), sumLists.SumLists(list1, list2));
            Assert.Equal(new LinkedList<int>(new int[] {1, 0, 0, 1}), sumLists.SumLists(
                new LinkedList<int>(new int[] {9, 9, 9}), new LinkedList<int>(new int[] {2})
            ));

            Assert.NotEqual(new LinkedList<int>(new int[] {1, 0, 0, 1}), sumLists.SumLists(list1, list2));
        }

        [Fact]
        public void SumListsFollowUp()
        {
            LinkedList<int> list1 = new LinkedList<int>(new int[] {6, 1, 7});
            LinkedList<int> list2 = new LinkedList<int>(new int[] {1, 9, 2, 0, 7});

            Assert.Equal(new LinkedList<int>(new int[] {1, 9, 8, 2, 4}), sumLists.SumListsFollowUp(list1, list2));
            Assert.Equal(new LinkedList<int>(new int[] {1, 1, 1}), sumLists.SumListsFollowUp(
                new LinkedList<int>(new int[] {1, 0, 9}), new LinkedList<int>(new int[] {2})
            ));

            Assert.NotEqual(new LinkedList<int>(new int[] {1, 9, 8, 2, 3}), sumLists.SumListsFollowUp(list1, list2));
        }
    }
}