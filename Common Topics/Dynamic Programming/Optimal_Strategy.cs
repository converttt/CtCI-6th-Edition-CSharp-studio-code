using System;

namespace Common_Topics
{
    public static class Optimal_Strategy
    {
        /*
            Problem statement: Consider a row of n coins of values v1 . . . vn, where n is even. 
            We play a game against an opponent by alternating turns. 
            In each turn, a player selects either the first or last coin from the row, removes it from the row permanently, 
            and receives the value of the coin. Determine the maximum possible amount of money we can definitely win if we move first.
         */
        public static int FindMaxValue(int[] arr, int i, int j)
        {
            if (i == j)
            {
                return arr[i];
            }
            else if (i + 1 == j)
            {
                return Math.Max(arr[i], arr[j]);
            }
            else
            {
                return Math.Max(
                    arr[i] + Math.Min(FindMaxValue(arr, i + 1, j - 1), FindMaxValue(arr, i + 2, j)),
                    arr[j] + Math.Min(FindMaxValue(arr, i, j - 2), FindMaxValue(arr, i + 1, j - 1))
                );
            }
        }

        /*
            Solution of the prolem with memoization.
         */
        public static int FindMaxValue2(int[] arr)
        {
            int[,] lookup = new int[arr.Length, arr.Length];
            return FindMaxValue(lookup, arr, 0, arr.Length - 1);
        }

        public static int FindMaxValue(int[,] lookup, int[] arr, int i, int j)
        {
            if (lookup[i, j] == 0)
            {
                if (i == j)
                {
                    return arr[i];
                }
                else if (i + 1 == j)
                {
                    return Math.Max(arr[i], arr[j]);
                }
                else
                {
                    return Math.Max(
                        arr[i] + Math.Min(FindMaxValue(lookup, arr, i + 1, j - 1), FindMaxValue(lookup, arr, i + 2, j)),
                        arr[j] + Math.Min(FindMaxValue(lookup, arr, i + 1, j - 1), FindMaxValue(lookup, arr, i, j - 2))
                    );
                }
            }
            else
            {
                return lookup[i, j];
            }
        }
    }
}