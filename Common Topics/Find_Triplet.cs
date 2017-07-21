using System;
using System.Collections.Generic;

namespace Common_Topics
{
    public static class Find_Triplet
    {
        public static List<int[]> EqualTriplets1(int[] arr, int sum)
        {
            List<int[]> results = new List<int[]>();

            Array.Sort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                int j = i + 1;
                int k = arr.GetUpperBound(0);

                while (j < k)
                {
                    int summary = arr[i] + arr[j] + arr[k];

                    if (summary == sum)
                    {
                        results.Add(new int[] {arr[i], arr[j], arr[k]});
                    }
                    else if (summary < sum)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }
            }

            return results;
        }

        public static List<int[]> EqualTriplets2(int[] arr, int sum)
        {
            List<int[]> results = new List<int[]>();
            Dictionary<int, List<Tuple<int, int>>> sums = new Dictionary<int, List<Tuple<int, int>>>();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int summary = arr[i] + arr[j];
                    if (!sums.ContainsKey(summary))
                    {
                        sums.Add(summary, new List<Tuple<int, int>>());
                    }
                    sums[summary].Add(new Tuple<int, int>(i, j));
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (sums.ContainsKey(sum - arr[i]))
                {
                    foreach (Tuple<int, int> item in sums[sum - arr[i]])
                    {
                        if (i < item.Item1)
                        {
                            results.Add(new int[] {arr[item.Item1], arr[item.Item2], arr[i]});
                        }
                    }
                }
            }

            return results;
        }
    }
}