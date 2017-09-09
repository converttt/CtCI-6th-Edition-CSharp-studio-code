using System;

namespace Common_Topics
{
    public static class Palindromes
    {
        /*
            Given a string, find the minimum number of characters to be inserted to convert it to palindrome.

            Bottom Up solution.

            Time complexity: O(n^2)
         */
        public static int FindInsertions(string str)
        {
            int[,] table = new int[str.Length, str.Length];

            for (int gap = 1; gap < str.Length; gap++)
            {
                for (int i = 0, j = gap; j < str.Length; i++, j++)
                {
                    table[i, j] = (str[i] == str[j]) ?
                        table[i + 1, j - 1] :
                        Math.Min(table[i, j - 1], table[i + 1, j]) + 1;
                }
            }

            return table[0, str.Length - 1];
        }
    }
}