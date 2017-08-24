using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Medians
    {
        [Fact]
        public void TestMedianOfEqual()
        {
            int[] a = new int[] {1, 12, 15, 26, 38};
            int[] b = new int[] {2, 13, 17, 30, 45};
            
            // int result = Medians.MedianOfEqual(a, b);

            // Assert.Equal(16, result);

            a = new int[] {1, 2, 3, 6};
            b = new int[] {4, 6, 8, 10};

            int result = Medians.MedianOfEqual(a, b);

            Assert.Equal(5, result);
        }

        [Fact]
        public void TestMedianOfUnequal()
        {
            int[] a = new int[] {1, 2, 3, 4, 5};
            int[] b = new int[] {-2, -1, 0};

            Assert.Equal(_MedianOf2(a, b), Medians.MedianOfUnequal(a, b));

            a = new int[] {4, 6, 8, 10, 12, 20};
            b = new int[] {5, 7, 9, 11};

            Assert.Equal(_MedianOf2(a, b), Medians.MedianOfUnequal(a, b));
        }

        private int _MedianOf2(int[] a, int[] b)
        {
            int[] arr = new int[a.Length + b.Length];
            Array.Copy(a, 0, arr, 0, a.Length);
            Array.Copy(b, 0, arr, a.Length, b.Length);
            Array.Sort(arr);

            int medianI = arr.Length / 2;
            if (arr.Length % 2 == 0)
            {
                return (arr[medianI - 1] + arr[medianI]) / 2;
            }
            else
            {
                return arr[medianI];
            }
        }
    }
}