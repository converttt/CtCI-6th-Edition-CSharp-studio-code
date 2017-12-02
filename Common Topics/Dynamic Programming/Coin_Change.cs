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

        public static int Count2(int[] arr, int sum)
        {
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
                    int excluding = (j >= 1) ? buff[i, j - 1] : 0;
                    buff[i, j] = including + excluding;
                }
            }

            return buff[sum, arr.Length - 1];
        }
    }
}