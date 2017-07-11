using System;
using System.Collections.Generic;
using lib_ctci;

namespace CH_04._Trees_and_Graphs
{
    public class Q09_BST_Sequence<T>
    {
        public List<LinkedList<T>> BuildSequence(CtciTreeNode<T> head)
        {
            if (head == null)
            {
                throw new Exception("Incorrect Data");
            }

            return AllSequences(head);
        }

        protected List<LinkedList<T>> AllSequences(CtciTreeNode<T> node)
        {
            List<LinkedList<T>> result = new List<LinkedList<T>>();

            if (node == null)
            {
                result.Add(new LinkedList<T>());
                return result;
            }

            LinkedList<T> prefix = new LinkedList<T>();
            prefix.AddLast(node.Value);

            List<LinkedList<T>> left = AllSequences(node.Left);
            List<LinkedList<T>> right = AllSequences(node.Right);

            foreach (LinkedList<T> leftList in left)
            {
                foreach (LinkedList<T> rightList in right)
                {
                    List<LinkedList<T>> weaved = new List<LinkedList<T>>();
                    WeaveLists(leftList, rightList, weaved, prefix);
                    CopyListNodes(weaved, result);
                }
            }

            return result;
        }

        protected void WeaveLists(LinkedList<T> left, LinkedList<T> right, List<LinkedList<T>> results, LinkedList<T> prefix)
        {
            if (left.Count == 0 || right.Count == 0)
            {
                LinkedList<T> result = new LinkedList<T>();
                CopyLinkedNodes(prefix, result);
                CopyLinkedNodes(left, result);
                CopyLinkedNodes(right, result);
                results.Add(result);

                return;
            }

            T headLeft = left.First.Value;
            left.RemoveFirst();
            prefix.AddLast(headLeft);
            WeaveLists(left, right, results, prefix);
            prefix.RemoveLast();
            left.AddFirst(headLeft);

            T headRight = right.First.Value;
            right.RemoveFirst();
            prefix.AddLast(headRight);
            WeaveLists(left, right, results, prefix);
            prefix.RemoveLast();
            right.AddFirst(headRight);
        }

        protected void CopyLinkedNodes(LinkedList<T> from, LinkedList<T> to)
        {
            foreach (T node in from)
            {
                to.AddLast(node);
            }
        }

        protected void CopyListNodes(List<LinkedList<T>> from, List<LinkedList<T>> to)
        {
            foreach (LinkedList<T> node in from)
            {
                to.Add(node);
            }
        }
    }
}