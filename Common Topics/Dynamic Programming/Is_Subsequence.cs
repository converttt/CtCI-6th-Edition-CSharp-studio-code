using System;

namespace Common_Topics
{
    public static class Is_Subsequence
    {
        /*
            Given two strings, find if first string is a subsequence of second.
         */
        public static bool IsSubsequence(string str1, string str2)
        {
            int i;
            int j;
            for (i = 0, j = 0; i < str1.Length && j < str2.Length; j++)
            {
                if (str1[i] == str2[j])
                {
                    i++;
                }
            }

            if (i == str1.Length)
            {
                return true;
            }

            return false;
        }

        /*
            Given three strings A, B and C. Write a function that checks whether C is an interleaving of A and B. 
            C is said to be interleaving A and B, if it contains all characters of A and B and order of all characters in individual strings is preserved.
         */
        public static bool Intervealed(string str1, string str2, string str3)
        {
            bool[] used = new bool[str3.Length];
            for (int m = 0; m < str3.Length; m++)
            {
                used[m] = false;
            }

            int i;
            int j;
            for (i = 0, j = 0; i < str1.Length && j < str3.Length; j++)
            {
                if (str1[i] == str3[j])
                {
                    used[j] = true;
                    i++;
                }
            }

            if (i != str1.Length)
            {
                return false;
            }

            for (i = 0, j = 0; i < str2.Length && j < str3.Length; j++)
            {
                if (str2[i] == str3[j] && used[j] == false)
                {
                    used[j] = true;
                    i++;
                }
            }

            if (i != str2.Length)
            {
                return false;
            }

            return true;
        }
    }
}