using System;

namespace CH_05._Bit_Manipulations
{
    public class Q01_Insertion
    {
        public int Insert(int a, int b, int start, int end)
        {
            int allOnes = ~0;

            int leftMask = allOnes << end;
            int rightMask = 1 << start;
            rightMask--;

            int mask = leftMask | rightMask;

            int result = a;
            int insertion = b;

            result = result & mask;

            insertion = insertion << start;

            result |= insertion;

            return result;
        }
    }
}
