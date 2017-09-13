using System;
using System.Collections.Generic;

namespace Common_Topics
{
    public static class Overlapping
    {
        /*
            Given a set of time intervals in any order, merge all overlapping intervals into one and output the result 
            which should have only mutually exclusive intervals. Let the intervals be represented as pairs of integers for simplicity. 
            For example, let the given set of intervals be {{1,3}, {2,4}, {5,7}, {6,8} }. 
            The intervals {1,3} and {2,4} overlap with each other, so they should be merged and become {1, 4}. 
            Similarly {5, 7} and {6, 8} should be merged and become {5, 8}

            Time complexity: O(n)
         */
        public static List<int[]> Intervals(int[][] intervals)
        {
            Array.Sort(intervals, (v1, v2) => v1[0].CompareTo(v2[0]));

            List<int[]> result = new List<int[]>();
            int i = 0;
            int j = 1;
            result.Add(intervals[0]);
            while (j < intervals.Length)
            {
                if (result[i][1] > intervals[j][0])
                {
                    result[i][0] = Math.Min(result[i][0], intervals[j][0]);
                    result[i][1] = Math.Max(result[i][1], intervals[j][1]);
                }
                else
                {
                    result.Add(intervals[j]);
                    i++;
                }

                j++;
            }

            return result;
        }
    }
}