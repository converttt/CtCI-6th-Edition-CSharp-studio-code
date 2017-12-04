using System;
using System.Collections.Generic;

namespace Common_Topics
{
    public static class Sets
    {
        /*
            Partition problem is to determine whether a given set can be partitioned into two subsets such that the sum of elements in both subsets is same.

            arr[] = {1, 5, 11, 5}
            Output: true 
            The array can be partitioned as {1, 5, 5} and {11}
         */
        public static bool Solution1(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            if (sum % 2 > 0)
            {
                return false;
            }

            return Partitioning(arr, sum / 2, arr.Length);
        }

        private static bool Partitioning(int[] arr, int sum, int n)
        {
            if (sum == 0)
            {
                return true;
            }

            if (n == 0)
            {
                return false;
            }

            if (arr[n - 1] > sum)
            {
                return Partitioning(arr, sum, n - 1);
            }

            return Partitioning(arr, sum, n - 1) || Partitioning(arr, sum - arr[n - 1], n - 1);
        }

        public static bool Solution2(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            if (sum % 2 > 0)
            {
                return false;
            }

            sum = sum / 2;
            int[,] buff = new int[sum + 1, arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                buff[0, i] = 1;
            }

            for (int i = 1; i <= sum; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    int including = (i - arr[j] >= 0) ? buff[i - arr[j], j] : 0;
                    int exluding = (j >= 1) ? buff[i, j - 1] : 0;

                    buff[i, j] = including + exluding;
                }
            }

            if (buff[sum, arr.Length - 1] > 0)
            {
                return true;
            }

            return false;
        }

        /**
            Finding all subsets of a given set

            Value of Counter            Subset
                000                    -> Empty set
                001                    -> a
                010                    -> b
                011                    -> ab
                100                    -> c
                101                    -> ac
                110                    -> bc
                111                    -> abc
         */
        public static List<int>[] Solution3(int[] arr)
        {
            int resultSize = Convert.ToInt32(Math.Pow(2, arr.Length));
            List<int>[] res = new List<int>[resultSize];

            for (int i = 0; i < resultSize; i++)
            {
                res[i] = new List<int>();
                int j = i, k = 0;

                do
                {
                    if (j % 2 == 1)
                    {
                        res[i].Add(arr[k]);
                    }

                    j >>= 1;
                    k++;
                } while (j > 0);
            }

            return res;
        }

        /*
            Partition a set into two subsets such that the difference of subset sums is minimum

            If there is a set S with n elements, then if we assume Subset1 has m elements, 
            Subset2 must have n-m elements and the value of abs(sum(Subset1) – sum(Subset2)) should be minimum.
         */
        public static int Solution4(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return Partitioning2(arr, arr.Length - 1, 0, sum);
        }

        public static int Partitioning2(int[] arr, int i, int tmpSum, int sum)
        {
            if (i == 0)
            {
                return Math.Abs(sum - 2 * tmpSum);
            }

            return Math.Min(Partitioning2(arr, i - 1, tmpSum + arr[i], sum), 
                Partitioning2(arr, i - 1, tmpSum, sum));
        }

        public static int Solution5(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            bool[,] buff = new bool[sum + 1, arr.Length + 1];
            for (int i = 0; i <= buff.GetUpperBound(1); i++)
            {
                buff[0, i] = true;
            }

            for (int i = 1; i <= buff.GetUpperBound(0); i++)
            {
                buff[i, 0] = false;
            }

            for (int j = 1; j <= buff.GetUpperBound(0); j++)
            {
                for (int i = 1; i <= buff.GetUpperBound(1); i++)
                {
                    bool included = (i >= 1 && j - arr[i - 1] >= 0) 
                        ? buff[j - arr[i - 1], i - 1] 
                        : false;

                    bool excluded = (i >= 1) ? buff[j, i - 1] : false;

                    buff[j, i] = included || excluded;
                }
            }

            int diff = Int32.MaxValue;
            for (int i = sum / 2; i >= 0; i--)
            {
                if (buff[sum - i * 2, buff.GetUpperBound(1)])
                {
                    diff = sum - i * 2;
                    break;
                }
            }

            return diff;
        }
    }
}