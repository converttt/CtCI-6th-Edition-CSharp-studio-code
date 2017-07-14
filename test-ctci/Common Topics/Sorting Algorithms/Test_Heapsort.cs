using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Heapsort
    {
        private Heapsort<int> heapsort = new Heapsort<int>();

        [Fact]
        public void BuildHeap()
        {
            int[] arr = new int[] {10, 64, 7, 99, 32, 18, 2, 48};

            heapsort.PerformHeapSort(arr);

            Assert.Equal(new int[] {2, 7, 10, 18, 32, 48, 64, 99}, arr);

            arr = new int[] {10, 64, 7, 99, 32, 18};

            heapsort.PerformHeapSort(arr);

            Assert.Equal(new int[] {7, 10, 18, 32, 64, 99}, arr);
        }
    }
}