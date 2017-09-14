using System;

namespace CH_01._Array_and_Strings
{
    public class Q04_Palindrome_Permutation
    {
        /*
            Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome. 
            A palindrome is a word or phrase that is the same forwards and backwards. 
            A permutation is a rearrangement of letters. The palindrome does not need to be limited to just dictionary words.
         */
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