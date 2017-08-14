using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Best_Time_Buy_Sell
    {
        [Fact]
        public void GetMaxProfit()
        {
            int transactions = 2;
            int[] prices = new int[] {
                1, 3, 1, 2, 1, 1
            };

            int result = Best_Time_Buy_Sell.MaxProfit(transactions, prices);
        }
    }
}