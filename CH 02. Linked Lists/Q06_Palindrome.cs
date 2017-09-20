using System;
using System.Collections.Generic;

namespace CH_02._Linked_Lists
{
    /*
        Implement a function to check if a linked list is a palindrome.
     */
    public class Q06_Palindrome<T>
    {
        public bool IsPalindrome1(LinkedList<T> list)
        {
            if (list.Count == 0)
            {   
                throw new Exception("Incorrect Data");
            }

            if (list.Count == 1)
            {
                return true;
            }

            Stack<T> stack = new Stack<T>();

            LinkedListNode<T> slow = list.First;
            LinkedListNode<T> fast = list.First;

            while (fast.Next != null && fast.Next.Next != null)
            {
                stack.Push(slow.Value);

                slow = slow.Next;
                fast = fast.Next.Next;
            }

            if (fast.Next != null)
            {
                stack.Push(slow.Value);
            }

            do
            {
                slow = slow.Next;

                T value = stack.Pop();
                if (value.Equals(slow.Value) == false)
                {
                    return false;
                }
            } while (slow.Next != null);

            return true;
        }

        public bool IsPalindrome2(LinkedListNode<T> listNode)
        {
            if (listNode == null)
            {
                throw new Exception("Incorrect Data");
            }

            LinkedList<T> list = ReverseLinkedList(listNode);

            LinkedListNode<T> slow = listNode;
            LinkedListNode<T> fast = listNode;
            LinkedListNode<T> reversed = list.First;
            while (fast.Next != null && fast.Next.Next != null)
            {
                if (slow.Value.Equals(reversed.Value) == false)
                {
                    return false;
                }

                slow = slow.Next;
                fast = fast.Next.Next;
                reversed = reversed.Next;
            }

            if (fast.Next != null)
            {
                if (slow.Value.Equals(reversed.Value) == false)
                {
                    return false;
                }
            }

            return true;
        }

        protected LinkedList<T> ReverseLinkedList(LinkedListNode<T> listNode)
        {
            LinkedList<T> list = new LinkedList<T>();

            while (listNode.Next != null)
            {
                list.AddFirst(listNode.Value);
                listNode = listNode.Next;
            }

            list.AddFirst(listNode.Value);

            return list;
        }
    }
}