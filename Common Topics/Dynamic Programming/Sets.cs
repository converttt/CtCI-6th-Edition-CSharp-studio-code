using System;

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

        /*
            Partition a set into two subsets such that the difference of subset sums is minimum
         */
        
    }
}