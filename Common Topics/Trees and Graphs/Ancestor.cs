using System;
using lib_ctci;

namespace Common_Topics
{
    public static class Ancestor
    {
        /*
            Given values of two nodes n1 and n2 in a Binary Tree, 
            find the Lowest Common Ancestor (LCA)

            Time complexity: O(n)
         */
        public static CtciTreeNode<int> FindFromBinaryTree(CtciTreeNode<int> parent, int value1, int value2)
        {
            if (parent.Value == value1 || parent.Value == value2)
            {
                return parent;
            }

            CtciTreeNode<int> leftNode = null;
            CtciTreeNode<int> rightNode = null;

            if (parent.Left != null)
            {
                leftNode = FindFromBinaryTree(parent.Left, value1, value2);
            }

            if (parent.Right != null)
            {
                rightNode = FindFromBinaryTree(parent.Right, value1, value2);
            }

            if (leftNode != null && rightNode != null)
            {
                return parent;
            }
            else if (leftNode != null || rightNode != null)
            {
                return (leftNode != null) ? leftNode : rightNode;
            }
            else
            {
                return null;
            }
        }

        /*
            Given values of two nodes n1 and n2 in a Binary Search Tree, 
            find the Lowest Common Ancestor (LCA)

            Time complexity: O(log(n))
         */
        public static CtciTreeNode<int> FindFromBST(CtciTreeNode<int> parent, int value1, int value2)
        {
            if (value1 > value2)
            {
                int tmp = value2;
                value2 = value1;
                value1 = tmp;
            }

            if (parent.Value > value1 && parent.Value < value2)
            {
                return parent;
            }

            if (parent.Value == value1 || parent.Value == value2)
            {
                return parent;
            }

            if (parent.Value > value1 && parent.Value > value2)
            {
                return FindFromBST(parent.Left, value1, value2);
            }
            else
            {
                return FindFromBST(parent.Right, value1, value2);
            }
        }
    }
}