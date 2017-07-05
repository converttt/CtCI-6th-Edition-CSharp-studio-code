using System;
using System.Collections.Generic;
using lib_ctci;

namespace CH_02._Linked_Lists
{
    public class Q07_Palindrome<T>
    {
        public CtciLinkedListNode<T> FindIntersection(CtciLinkedListNode<T> listNode1, CtciLinkedListNode<T> listNode2)
        {
            if (listNode1 == null || listNode2 == null)
            {
                throw new Exception("Incorrect Data");
            }

            Q07_Result<T> result1 = FindLengthAndLastNode(listNode1);
            Q07_Result<T> result2 = FindLengthAndLastNode(listNode2);

            if (result1.lastNode != result2.lastNode)
            {
                return null;
            }

            CtciLinkedListNode<T> longer;
            CtciLinkedListNode<T> shorter;
            if (result1.length >= result2.length)
            {
                longer = listNode1;
                shorter = listNode2;
            }
            else
            {
                longer = listNode2;
                shorter = listNode1;
            }

            int diff = result1.length - result2.length;

            for (int i = 0; i < diff; i++)
            {
                longer = longer.Next;
            }

            while (longer != null)
            {
                if (longer == shorter)
                {
                    return longer;
                }

                longer = longer.Next;
                shorter = shorter.Next;
            }

            return null;
        }

        public Q07_Result<T> FindLengthAndLastNode(CtciLinkedListNode<T> listNode)
        {
            int length = 1;

            while (listNode.Next != null)
            {
                listNode = listNode.Next;
                length++;
            }

            return new Q07_Result<T>(length, listNode);
        }
    }

    public class Q07_Result<T>
    {
        public int length;
        public CtciLinkedListNode<T> lastNode;

        public Q07_Result(int length, CtciLinkedListNode<T> lastNode)
        {
            this.length = length;
            this.lastNode = lastNode;
        }
    }
}