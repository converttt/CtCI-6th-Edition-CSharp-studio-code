using System;

namespace CH_01._Array_and_Strings
{
    public class Q04_Palindrome_Permutation
    {
        public bool PalindromePerm1(string str)
        {
            int bitVector = 0;
            foreach (char ch in str)
            {
                if (ch > 0)
                {
                    int mask = 1 << (int) ch;
                    bitVector ^= mask;
                }
            }

            if (bitVector == 0 || (bitVector & (bitVector - 1)) == 0)
            {
                return true;
            }

            return false;
        }
    }
}