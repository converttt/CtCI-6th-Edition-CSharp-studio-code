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
                for (int j = 0; j < i; j++)
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

        /*
            You are given n pairs of numbers. In every pair, the first number is always smaller than the second number. 
            A pair (c, d) can follow another pair (a, b) if b < c. 
            Chain of pairs can be formed in this fashion. 
            Find the longest chain which can be formed from a given set of pairs.
         */
        public static int FindMaxOfChains(Tuple<int, int>[] pairs)
        {
            Array.Sort(pairs, (Tuple<int, int> v1, Tuple<int, int> v2) => v1.Item1.CompareTo(v2.Item1));

            int[] lis = new int[pairs.Length];
            for (int i = 0; i < pairs.Length; i++)
            {
                lis[i] = 1;
            }

            for (int i = 1; i < pairs.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (pairs[i].Item1 > pairs[j].Item2 && lis[i] < lis[j] + 1)
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