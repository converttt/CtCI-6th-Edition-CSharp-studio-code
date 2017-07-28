using System;
using System.Linq;
using System.Collections.Generic;

namespace Common_Topics
{
    public static class Combinations
    {
        /*
            Given the list of integeres {1, 2, 3}. Generate all possible combinations as follows:
            {1, 2, 3} {1, 2} {1, 3} {2, 3} {1} {2} {3}.

            The possible number of combinations is 2^n

            Complexity: O(2^n)
         */
        public static List<List<int>> CombinationProblem1(int[] arr)
        {
            Action<int, List<List<int>>> addComb = (vector, extArr) => {
                List<int> combination = new List<int>();
                extArr.Add(combination);
                for (int i = 0; i < arr.Length; i++)
                {
                    if ((vector & (1 << i)) != 0)
                    {
                        combination.Add(arr[i]);
                    }
                }
            };

            int initVector = 1;
            int maxVector = (1 << arr.Length) - 1;
            List<List<int>> result = new List<List<int>>();

            while (initVector <= maxVector)
            {
                addComb(initVector, result);

                initVector++;
            }

            return result;
        }

        /*
            Combination (subset) extension method.

            Generate all possible combinations of fixed size subsets from a set.

            The number of combinations can be derived usgin the formula:
            n! / (k! * (n - k)!)
         */
        public static List<List<int>> CombinationProblem2(int[] arr, int subset)
        {
            List<List<int>> result = (from int vector in Enumerable.Range(1, (1 << arr.Length) - 1)
                let comb = (from int i in Enumerable.Range(0, arr.Length)
                where (vector & (1 << i)) != 0
                select arr[i]).ToList()
            where comb.Count == subset
            select comb).ToList();

            return result;
        }
    }
}