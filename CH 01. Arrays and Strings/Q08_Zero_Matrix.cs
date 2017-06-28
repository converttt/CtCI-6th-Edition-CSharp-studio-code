using System;
using System.Collections.Generic;

namespace CH_01._Array_and_Strings
{
    public class Q08_Zero_Matrix
    {
        public void SetZeros(int[,] matrix)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            List<Tuple<int, int>> positions = new List<Tuple<int, int>>();

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (matrix[row, column] == 0)
                    {
                        positions.Add(new Tuple<int, int>(row, column));
                    }
                }
            }

            foreach(Tuple<int, int> zero in positions)
            {
                ZerofyRow(matrix, zero.Item1);
                ZerofyColumn(matrix, zero.Item2);
            }
        }

        protected void ZerofyColumn(int[,] matrix, int column)
        {
            for (int row = 0; row <= matrix.GetUpperBound(0); row++)
            {
                matrix[row, column] = 0;
            }
        }

        protected void ZerofyRow(int[,] matrix, int row)
        {
            for (int column = 0; column <= matrix.GetUpperBound(1); column++)
            {
                matrix[row, column] = 0;
            }
        }
    }
}