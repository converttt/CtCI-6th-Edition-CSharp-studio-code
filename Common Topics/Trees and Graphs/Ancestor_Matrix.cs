using System;

namespace Common_Topics
{
    public static class Ancestor_Matrix
    {
        /*
            Given a Binary Tree where all values are from 0 to n-1. Construct an ancestor matrix mat[n][n]. 

            Complexity: O(n).
         */
        public static int[,] BuildMatrix(Ancestor_Matrix_Node root)
        {
            int i = Ancestor_Matrix_Node.CountNodes(root);

            int[,] matrix = new int[i,i];
            int[] vector = new int[i];

            BuildMatrix(root, matrix, vector);

            return matrix;
        }

        private static void BuildMatrix(Ancestor_Matrix_Node root, int[,] matrix, int[] vector)
        {
            if (root == null)
            {
                return;
            }

            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i] == 1)
                {
                    matrix[i, root.ID] = 1;
                }
            }

            vector[root.ID] = 1;

            BuildMatrix(root.Left, matrix, vector);
            BuildMatrix(root.Right, matrix, vector);

            vector[root.ID] = 0;

            return;
        }

        /*
            Given an ancestor matrix mat[n][n]. 
            Construct a Binary Tree from given ancestor matrix where all its values of nodes are from 0 to n-1.

            Complexity: O(n*log(n))
         */
        public static Ancestor_Matrix_Node BuildTree(int[,] matrix)
        {
            int n = matrix.GetUpperBound(0) + 1;

            Ancestor_Matrix_Node[] nodes = new Ancestor_Matrix_Node[n];
            bool[] hasParent = new bool[n];
            Tuple<int, int>[] map = new Tuple<int, int>[n];

            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        sum++;
                    }
                }

                map[i] = new Tuple<int, int>(i, sum);
            }

            Array.Sort(map, (a, b) => { return a.Item2.CompareTo(b.Item2); });

            Ancestor_Matrix_Node root = null;
            foreach (Tuple<int, int> item in map)
            {
                nodes[item.Item1] = new Ancestor_Matrix_Node(item.Item1);

                root = nodes[item.Item1];

                if (item.Item2 > 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (!hasParent[j] && matrix[item.Item1, j] == 1)
                        {
                            if (root.Left == null)
                            {
                                root.Left = nodes[j];
                            }
                            else
                            {
                                root.Right = nodes[j];
                            }

                            hasParent[j] = true;
                        }
                    }
                }
            }

            return root;
        }
    }

    public class Ancestor_Matrix_Node
    {
        private Ancestor_Matrix_Node left = null;
        private Ancestor_Matrix_Node right = null;
        private int id;

        public Ancestor_Matrix_Node(int id)
        {
            this.id = id;
        }

        public static int CountNodes(Ancestor_Matrix_Node root)
        {
            if (root == null)
            {
                return 0;
            }

            int i = 1;

            i += CountNodes(root.Left);
            i += CountNodes(root.Right);

            return i;
        }

        public Ancestor_Matrix_Node Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

        public Ancestor_Matrix_Node Right
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }

        public int ID
        {
            get
            {
                return id;
            }
        }
    }
}