using System;

namespace Common_Topics
{
    /*
        Given a number n, print all primes smaller than or equal to n. It is also given that n is a small number.
        For example, if n is 10, the output should be “2, 3, 5, 7”. If n is 20, the output should be “2, 3, 5, 7, 11, 13, 17, 19”.

        Time Complexity: O(n)
     */
    public static class Prime_Numbers
    {
        public static bool[] AllTo(int n)
        {
            bool[] arr = new bool[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                arr[i] = true;
            }

            for (int p = 2; p <= n; p++)
            {
                if (arr[p] == true)
                {
                    for (int k = 2; k * p <= n; k++)
                    {
                        arr[k * p] = false;
                    }
                }
            }

            return arr;
        }
    }
}