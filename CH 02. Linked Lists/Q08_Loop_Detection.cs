using System;
using System.Collections.Generic;
using lib_ctci;

namespace CH_02._Linked_Lists
{
    public class Q08_Loop_Detection<T>
    {
        public CtciLinkedListNode<T> FindBeginning(CtciLinkedListNode<T> head)
        {
            if (head == null)
            {
                throw new Exception("Incorrect Data");
            }

            CtciLinkedListNode<T> slow = head;
            CtciLinkedListNode<T> fast = head;

            do
            {
                if (fast.Next == null || fast.Next.Next == null)
                {
                    return null;
                }

                slow = slow.Next;
                fast = fast.Next.Next;
            } while (slow != fast);

            slow = head;

            while (slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            return slow;
        }
    }
}