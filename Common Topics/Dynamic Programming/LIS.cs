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

        /*
            Calculating the length of the longest common subsequence of two strings A and B of length N.
         */
        public static int FindMaxOfStrings(string str1, string str2)
        {
            int[,] mem = new int[str1.Length, str1.Length];
            int max = 0;

            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] == str2[j])
                    {
                        mem[i, j] = (i == 0 || j == 0) ? 1 : mem[i - 1, j - 1] + 1;
                        max = Math.Max(max, mem[i, j]);
                    }
                }
            }

            return max;
        }

        /*
            Given a string, find the minimum number of characters to be inserted to convert it to palindrome.

            A solution can be represented as a problem of the longest common subsequence of two strings.
            This solution is valid only when insertions cab be done at the beginning or end of a string (to append).

            Time complexity: O(n^2)
         */
        public static int FindNumInsertions(string str)
        {
            char[] baseStr = str.ToCharArray();
            Array.Reverse(baseStr);
            string strReversed = new String(baseStr);

            int[] loookup = new int[str.Length];
            int[,] mem = new int[str.Length, str.Length];
            int max = 0;

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[i] == strReversed[j])
                    {
                        mem[i, j] = (i == 0 || j == 0) ? 1 : mem[i - 1, j - 1] + 1;
                        max = Math.Max(max, mem[i, j]);
                    }
                }
            }

            return str.Length - max;
        }
    }
}