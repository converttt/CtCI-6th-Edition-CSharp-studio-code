using System;
using System.Collections.Generic;
using lib_ctci;

namespace CH_04._Trees_and_Graphs
{
    public class Q06_Successor<T>
    {
        public CtciTreeNode<T> FindSuccessor(CtciTreeNode<T> node)
        {
            if (node.Right != null)
            {
                return FindMostLeft(node.Right);
            }
            else
            {
                return FindInOrderParent(node);
            }
        }

        protected CtciTreeNode<T> FindMostLeft(CtciTreeNode<T> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        protected CtciTreeNode<T> FindInOrderParent(CtciTreeNode<T> node)
        {
            while (node == node.Parent.Right)
            {
                node = node.Parent;
            }

            return node.Parent;
        }
    }
}