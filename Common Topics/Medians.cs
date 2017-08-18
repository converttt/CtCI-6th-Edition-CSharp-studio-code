using System;

namespace Common_Topics
{
    public static class Medians
    {
        private static int _median;

        /*
            There are 2 sorted arrays A and B of size n each. 
            Write an algorithm to find the median of the array obtained after merging the above 2 arrays(i.e. array of length 2n). 
            The complexity should be O(log(n))
         */
        public static int MedianOfEqual(int[] a, int[] b)
        {
            if (a.Length == 1)
            {
                _median = (a[0] + b[0]) / 2;
            }

            _MedianOfEqual(a, 0, a.Length - 1, b, 0, b.Length - 1);

            return _median;
        }

        private static void _MedianOfEqual(int[] a, int aStart, int aFinish, int[] b, int bStart, int bFinish)
        {
            if ((aFinish - aStart + 1) == 2)
            {
                _median = (Math.Max(a[aStart], b[bStart]) + Math.Min(a[aFinish], b[bFinish])) / 2;
                return;
            }

            int aMedian = _Median(a, aStart, aFinish);
            int bMedian = _Median(b, bStart, bFinish);

            if (aMedian == bMedian)
            {
                _median = aMedian;
            }
            else if (aMedian < bMedian)
            {
                _MedianOfEqual(a, (aFinish + aStart) / 2 + 1, aFinish, b, bStart, (bFinish + bStart) / 2);
            }
            else
            {
                _MedianOfEqual(a, aStart, (aFinish + aStart) / 2, b, (bFinish + bStart) / 2 + 1, bFinish);   
            }
        }
        
        private static int _Median(int[] arr, int start, int finish)
        {
            int i = finish - start + 1;

            int median;
            if (i % 2 == 0)
            {
                median = (arr[(start + finish) / 2] + arr[(start + finish) / 2 + 1]) / 2;
            }
            else
            {
                median = arr[(start + finish) / 2];
            }

            return median;
        }
    }
}