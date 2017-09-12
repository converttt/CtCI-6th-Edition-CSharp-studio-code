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
    }
}