using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Common_Topics
{
    public static class Permutations
    {
        /*
            Generate all possible permutations of subsets of a set of chars.

            The number of permutations is derived by formula:
            n! / (n - k)!

            Complexity: O(2^n * n^2 * n!)
         */
        public static List<List<char>> PermuteSubset(char[] chars, int subset)
        {
            List<List<char>> results = new List<List<char>>();

            Action<string, string> Permutation = null;
            Permutation = (init, prefix) => {
                if (init.Length <= 0)
                {
                    results.Add(new List<char>(prefix.ToCharArray()));
                }

                for (int i = 0; i < init.Length; i++)
                {
                    char element = init[i];
                    string modifiedInit = init.Substring(0, i) + init.Substring(i + 1);
                    string newPrefix = prefix + element;
                    Permutation(modifiedInit, newPrefix);
                }
            };

            Action<int> AddComb = (vector) => {
                StringBuilder combination = new StringBuilder();
                for (int i = 0; i < chars.Length; i++)
                {
                    if ((vector & (1 << i)) != 0)
                    {
                        combination.Append(chars[i]);
                    }
                }

                if (combination.Length == subset)
                {
                    Permutation(combination.ToString(), "");
                }
            };

            int initVector = 1;
            int maxVector = (1 << chars.Length) - 1;
            while (initVector <= maxVector)
            {
                AddComb(initVector);

                initVector++;
            }

            return results;
        }
    }
}