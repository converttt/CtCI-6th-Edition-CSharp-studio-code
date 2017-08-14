using System;
using System.Collections.Generic;

namespace Common_Topics
{
    public static class Best_Time_Buy_Sell
    {
        /*
            An array i provided for which the ith element is the price of a given stock on day i.
            Need to design an algorithm to find the maximum profit. You may complete at most k transactions.

            Note:
            There should not be engagement in multiple transactions at the same time (ie, you must sell the stock before you buy again).
         */
        public static int MaxProfit(int k, int[] prices)
        {
            int n = prices.Length;

            if (n <= 1)
            {
                return 0;
            }

            if (k >= n / 2)
            {
                int maxProf = 0;
                for (int i = 1; i < n; i++)
                {
                    if (prices[i] - prices[i - 1] > 0)
                    {
                        maxProf += prices[i] - prices[i - 1];
                    }
                }

                return maxProf;
            }

            int[,] dp = new int[k + 1, n];
            int[,] localMax = new int[k + 1, n];
            for (int i = 1; i <= k; i++)
            {
                localMax[i, 0] = dp[i - 1, 0] - prices[0];

                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = Math.Max(dp[i, j - 1], localMax[i, j - 1] + prices[j]);
                    localMax[i, j] = Math.Max(localMax[i, j - 1], dp[i - 1, j - 1] - prices[j]);
                }
            }

            return dp[k, n - 1];
        }
    }
}