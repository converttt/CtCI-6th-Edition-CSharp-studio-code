using System;
using System.Collections.Generic;
using Xunit;
using CH_02._Linked_Lists;
using lib_ctci;

namespace test_ctci
{
    public class Test_Chapter02_Q7_Intersection
    {
        private Q07_Palindrome<int> intersection = new Q07_Palindrome<int>();

        [Fact]
        public void FindIntersection()
        {
            CtciLinkedListNode<int> listHead1 = new CtciLinkedListNode<int>(1);
            CtciLinkedListNode<int> listHead2 = new CtciLinkedListNode<int>(1);

            CtciLinkedListNode<int> node1 = new CtciLinkedListNode<int>(1);
            CtciLinkedListNode<int> node2 = new CtciLinkedListNode<int>(1);
            CtciLinkedListNode<int> node3 = new CtciLinkedListNode<int>(1);
            CtciLinkedListNode<int> node4 = new CtciLinkedListNode<int>(1);
            CtciLinkedListNode<int> node5 = new CtciLinkedListNode<int>(1);
            CtciLinkedListNode<int> node6 = new CtciLinkedListNode<int>(1);
            CtciLinkedListNode<int> node7 = new CtciLinkedListNode<int>(1);
            CtciLinkedListNode<int> node8 = new CtciLinkedListNode<int>(1);
            CtciLinkedListNode<int> node9 = new CtciLinkedListNode<int>(1);
            CtciLinkedListNode<int> node10 = new CtciLinkedListNode<int>(1);
            CtciLinkedListNode<int> node11 = new CtciLinkedListNode<int>(1);
            CtciLinkedListNode<int> node12 = new CtciLinkedListNode<int>(1);

            listHead1.Next = node1;
            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node6;
            node6.Next = node7;
            node7.Next = node8;
            node8.Next = node9;
            node9.Next = node10;

            listHead2.Next = node11;
            node11.Next = node12;

            Assert.Equal(null, intersection.FindIntersection(listHead1, listHead2));

            node12.Next = node6;

            Assert.Equal(node6, intersection.FindIntersection(listHead1, listHead2));
        }
    }
}