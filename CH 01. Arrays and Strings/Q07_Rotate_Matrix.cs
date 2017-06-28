using System;

namespace CH_01._Array_and_Strings
{
    public class Q07_Rotate_Matrix
    {
        public void Rotate(int[,] matrix, int n)
        {
            for (var layer = 0; layer < n / 2; ++layer)
            {
                var first = layer;
                var last = n - 1 - layer;

                for (var i = first; i < last; ++i)
                {
                    var offset = i - first;
                    var top = matrix[first, i]; // save top

                    // left -> top
                    matrix[first, i] = matrix[last - offset, first];

                    // bottom -> left
                    matrix[last - offset, first] = matrix[last, last - offset];

                    // right -> bottom
                    matrix[last, last - offset] = matrix[i, last];

                    // top -> right
                    matrix[i, last] = top; // right <- saved top
                }
            }
        }
    }
}