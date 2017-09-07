using System;

namespace Common_Topics
{
    public static class Ugly_Numbers
    {
        /*
            Ugly numbers are numbers whose only prime factors are 2, 3 or 5. 
            The sequence 1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15, … shows the first 11 ugly numbers. 
            By convention, 1 is included.

            Given a number n, the task is to find n’th Ugly number.
         */
        public static int GetUglyNumber(int n)
        {
            int[] table = new int[n + 1];
            table[1] = 1;

            int coursor2 = 1;
            int coursor3 = 1;
            int coursor5 = 1;

            for (int i = 2; i <= n; i++)
            {
                int num2 = table[coursor2] * 2;
                int num3 = table[coursor3] * 3;
                int num5 = table[coursor5] * 5;

                int num = Math.Min(num2, Math.Min(num3, num5));
                table[i] = num;

                if (num == num2)
                {
                    coursor2++;
                }
                
                if (num == num3)
                {
                    coursor3++;
                }

                if (num == num5) 
                {
                    coursor5++;
                }
            }

            return table[n];
        }
    }
}