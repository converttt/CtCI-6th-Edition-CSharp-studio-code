using System;
using System.Collections.Generic;

namespace CH_01._Array_and_Strings
{
    /*
        Check Permutation: Given two strings, write a method to decide if one is a permutation of the other.
     */
    public class Q02_Check_Permutation
    {
        public bool IsPermutation1(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (char ch in str1)
            {
                if (dict.ContainsKey((int) ch) == false)
                {
                    dict.Add((int) ch, 1);
                }
                else
                {
                    dict[(int) ch]++;
                }
            }

            foreach (char ch in str2)
            {
                if (dict.ContainsKey((int) ch) == false)
                {
                    return false;
                }

                if (dict[(int) ch] == 0)
                {
                    return false;
                }

                dict[(int) ch]--;
            }

            return true;
        }

        public bool IsPermutation2(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            char[] char1 = str1.ToCharArray();
            char[] char2 = str2.ToCharArray();

            Array.Sort(char1);
            Array.Sort(char2);

            for (int i = 0; i <= char1.GetUpperBound(0); i++)
            {
                if (char1[i] != char2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}