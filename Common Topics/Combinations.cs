using System;
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
                    if ((vector & (1 << i)) == 1)
                    {
                        combination.Add(arr[i]);
                    }
                }
            };

            int initVector = 1;
            int maxVector = (1 << arr.Length) - 1;
            List<List<int>> result = new List<List<int>>();

            while (initVector < maxVector)
            {
                addComb(initVector, result);

                initVector++;
            }
        }
    }
}