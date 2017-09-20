using System;
using System.Collections.Generic;
using lib_ctci;

namespace CH_04._Trees_and_Graphs
{
    /*
        Minimal Tree: Given a sorted (increasing order) array with unique integer elements, write an algorithm to create a binary search tree with minimal height.
     */
    public class Q02_Minimal_Tree
    {
        public CtciTreeNode<int> CreateMinimalHeight(int[] sortedArr)
        {
            if (sortedArr.Length <= 0)
            {
                throw new Exception("Incorrect Data");
            }

            int value = sortedArr[sortedArr.GetUpperBound(0) / 2];
            CtciTreeNode<int> head = CtciTreeNode<int>.CtciBinaryTreeNode(value);

            int start = sortedArr.GetLowerBound(0);
            int finish = (sortedArr.GetUpperBound(0) / 2) - 1;

            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            stack.Push(new Tuple<int, int>(start, finish));

            start = (sortedArr.GetUpperBound(0) / 2) + 1;
            finish = sortedArr.GetUpperBound(0);
            stack.Push(new Tuple<int, int>(start, finish));

            while (stack.Count > 0)
            {
                Tuple<int, int> partition = stack.Pop();

                if (partition.Item1 > partition.Item2)
                {
                    continue;
                }

                value = sortedArr[(partition.Item1 + partition.Item2) / 2];
                CtciTreeNode<int> node = CtciTreeNode<int>.CtciBinaryTreeNode(value);

                AddToTree(head, node);

                start = partition.Item1;
                finish = ((partition.Item1 + partition.Item2) / 2) - 1;

                stack.Push(new Tuple<int, int>(start, finish));

                start = ((partition.Item1 + partition.Item2) / 2) + 1;
                finish = partition.Item2;

                stack.Push(new Tuple<int, int>(start, finish));
            }

            return head;
        }

        public CtciTreeNode<int> CreateMinimalHeight2(int[] sortedArr)
        {
            int start = sortedArr.GetLowerBound(0);
            int finish = sortedArr.GetUpperBound(0);
            CtciTreeNode<int> head = CreateTreeRecursively(sortedArr, start, finish);

            return head;
        }

        public CtciTreeNode<int> CreateTreeRecursively(int[] sortedArr, int start, int finish)
        {
            if (start > finish)
            {
                return null;
            }

            int mid = (start + finish) / 2;
            int value = sortedArr[mid];
            CtciTreeNode<int> node = CtciTreeNode<int>.CtciBinaryTreeNode(value);
            node.Left = CreateTreeRecursively(sortedArr, start, mid - 1);
            node.Right = CreateTreeRecursively(sortedArr, mid + 1, finish);

            return node;
        }

        protected void AddToTree(CtciTreeNode<int> head, CtciTreeNode<int> newNode)
        {
            CtciTreeNode<int> parent = head;
            CtciTreeNode<int> child = head;

            while (child != null)
            {
                parent = child;

                if (newNode.Value <= child.Value)
                {
                    child = child.Left;
                }
                else
                {
                    child = child.Right;
                }
            }

            if (newNode.Value <= parent.Value)
            {
                parent.Left = newNode;
            }
            else
            {
                parent.Right = newNode;
            }
        }
    }
}