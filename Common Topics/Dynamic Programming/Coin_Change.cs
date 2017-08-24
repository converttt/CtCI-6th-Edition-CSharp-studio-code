using System;

namespace Common_Topics
{
    public static class CoinChange
    {
        public static int Count(int[] arr, int length, int sum)
        {
            if (sum < 0)
            {
                return 0;
            }
            else if (sum == 0)
            {
                return 1;
            }
            else if (length <= 0)
            {
                return 0;
            }

            return Count(arr, length - 1, sum) + Count(arr, length, sum - arr[length - 1]);
        }
    }
}