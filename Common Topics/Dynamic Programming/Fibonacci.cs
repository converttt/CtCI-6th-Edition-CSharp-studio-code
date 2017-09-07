using System;

namespace Common_Topics
{
    public static class Fibonacci
    {
        /*
            Find Nth Fibonacci number.
         */

        /*
            Recusrisive solution
            Time complexity: O(2^n)
         */
        public static int GetFibonacci(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }

        /*
            Memoized solution (top down) for overlapping problems
            Time Complexity: O(n)
         */
        public static int GetFibonacci2(int n, int[] lookup)
        {
            if (n <= 1)
            {
                lookup[n] = n;
            }

            if (lookup[n] == -1)
            {
                lookup[n] = GetFibonacci2(n - 1, lookup) + GetFibonacci2(n - 2, lookup);
            }

            return lookup[n];
        }

        /*
            Tabulated solution (Bottom Up) for overlapping problems 
            Time Complexity: O(n)
         */
        public static int GetFibonacci3(int n)
        {
            int[] table = new int[n + 1];
            table[0] = 0;
            table[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                table[i] = table[i - 1] + table[i - 2];
            }

            return table[n];
        }
    }
}