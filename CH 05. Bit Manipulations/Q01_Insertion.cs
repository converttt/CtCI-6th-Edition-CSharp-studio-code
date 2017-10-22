using System;

namespace CH_05._Bit_Manipulations
{
    /*
        Insertion: You are given two 32-bit numbers, Nand M, and two bit positions, i and j. 
        Write a method to insert Minto Nsuch that Mstarts at bit j and ends at bit i. 
        You can assume that the bits j through i have enough space to fit all of M. 
        That is, if M= 18811, you can assume that there are at least 5 bits between j and i. 
        You would not, for example, have j = 3 and i = 2, because Mcould not fully fit between bit 3 and bit 2.
     */
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
