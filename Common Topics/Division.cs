using System;

namespace Common_Topics
{
    public static class Division
    {
        /*
            Divide two integers without using multiplication, division and mod operator.
         */
        public static int Divide(int divident, int divisor)
        {
            if (divisor == 0)
            {
                throw new Exception("Zero Division Error");  
            }

            if (divident < 0)
            {
                return -1 * Divide(-1 * divident, divisor);
            }

            if (divisor < 0)
            {
                return -1 * Divide(divident, -1 *  divisor);
            }

            int quotient = 0;
            int sdiv = divisor;

            while (sdiv < divident)
            {
                sdiv <<= 1;
            }

            while (sdiv >= divisor)
            {
                quotient <<= 1;
                if (divident >= sdiv)
                {
                    divident -= sdiv;
                    quotient |= 1;
                }
                sdiv >>= 1;
            }

            return quotient;
        }
    }
}