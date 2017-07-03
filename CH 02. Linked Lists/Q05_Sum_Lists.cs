using System;
using System.Collections.Generic;

namespace CH_02._Linked_Lists
{
    public class Q05_Sum_Lists
    {
        public LinkedList<int> SumLists (LinkedList<int> list1, LinkedList<int> list2)
        {
            if (list1.First == null || list2.First == null)
            {
                throw new Exception("Wrong Data");
            }

            LinkedListNode<int> current1 = list1.First;
            LinkedListNode<int> current2 = list2.First;

            LinkedList<int> result = new LinkedList<int>();

            int k = 0;

            while (current1 != null || current2 != null)
            {
                int value1;
                int value2;
                int sum;

                if (current1 == null)
                {
                    value1 = 0;
                }
                else
                {
                    value1 = current1.Value;
                    current1 = current1.Next;
                }

                if (current2 == null)
                {
                    value2 = 0;
                }
                else
                {
                    value2 = current2.Value;
                    current2 = current2.Next;
                }

                sum = (value1 + value2);

                result.AddLast((sum + k) % 10);
                k = (sum + k) / 10;
            }

            if (k > 0)
            {
                result.AddLast(k);
            }

            return result;
        }

        public LinkedList<int> SumListsFollowUp (LinkedList<int> list1, LinkedList<int> list2)
        {
            if (list1.First == null || list2.First == null)
            {
                throw new Exception("Wrong Data");
            }

            int k = 1;
            int number1 = GetIntNumber(list1.First, ref k);

            k = 1;
            int number2 = GetIntNumber(list2.First, ref k);

            int result = number1 + number2;

            return CreateReverseList(result);
        }

        protected int GetIntNumber (LinkedListNode<int> current, ref int k)
        {
            int value;

            if (current.Next == null)
            {
                value = k * current.Value;
                k *= 10;
                return value;
            }

            value = GetIntNumber(current.Next, ref k) + k * current.Value;
            k *= 10;
            return value;
        }

        protected LinkedList<int> CreateList (int value)
        {
            LinkedList<int> list = new LinkedList<int>();

            while ((value / 10) > 0)
            {
                list.AddLast(value % 10);

                value /= 10;
            }

            list.AddLast(value);

            return list;
        }

        protected LinkedList<int> CreateReverseList (int value)
        {
            Stack<int> stack = new Stack<int>();
            LinkedList<int> list = new LinkedList<int>();

            while ((value / 10) > 0)
            {
                stack.Push(value % 10);

                value /= 10;
            }

            stack.Push(value);

            foreach (int i in stack)
            {
                list.AddLast(i);
            }

            return list;
        }
    }
}
