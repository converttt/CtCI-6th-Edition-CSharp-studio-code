using System;

namespace Common_Topics
{
    public static class LIS
    {
        /*
            Longest Increasing Subsequence

            The Longest Increasing Subsequence (LIS) problem is to find the length of the longest subsequence of a given sequence such that all elements of the subsequence are sorted in increasing order. 
            For example, the length of LIS for {10, 22, 9, 33, 21, 50, 41, 60, 80} is 6 and LIS is {10, 22, 33, 50, 60, 80}.
         */
        public static int FindMax(int[] arr)
        {
            int[] lis = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                lis[i] = 1;
            }

            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[i] > arr[j] && lis[i] < lis[j] + 1)
                    {
                        lis[i] = lis[j] + 1;
                    }
                }
            }

            int max = 1;
            foreach (int lisMax in lis)
            {
                max = Math.Max(max, lisMax);
            }

            return max;
        }
    }
}