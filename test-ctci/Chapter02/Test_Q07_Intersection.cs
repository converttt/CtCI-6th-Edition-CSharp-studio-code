using System;
using System.Collections.Generic;
using Xunit;
using CH_02._Linked_Lists;

namespace test_ctci
{
    public class Test_Chapter02_Q7_Intersection
    {
        private Q07_Palindrome<int> intersection = new Q07_Palindrome<int>();

        [Fact]
        public void FindIntersection()
        {
            Q07_LinkedListNode<int> listHead1 = new Q07_LinkedListNode<int>(1);
            Q07_LinkedListNode<int> listHead2 = new Q07_LinkedListNode<int>(1);

            Q07_LinkedListNode<int> node1 = new Q07_LinkedListNode<int>(1);
            Q07_LinkedListNode<int> node2 = new Q07_LinkedListNode<int>(1);
            Q07_LinkedListNode<int> node3 = new Q07_LinkedListNode<int>(1);
            Q07_LinkedListNode<int> node4 = new Q07_LinkedListNode<int>(1);
            Q07_LinkedListNode<int> node5 = new Q07_LinkedListNode<int>(1);
            Q07_LinkedListNode<int> node6 = new Q07_LinkedListNode<int>(1);
            Q07_LinkedListNode<int> node7 = new Q07_LinkedListNode<int>(1);
            Q07_LinkedListNode<int> node8 = new Q07_LinkedListNode<int>(1);
            Q07_LinkedListNode<int> node9 = new Q07_LinkedListNode<int>(1);
            Q07_LinkedListNode<int> node10 = new Q07_LinkedListNode<int>(1);
            Q07_LinkedListNode<int> node11 = new Q07_LinkedListNode<int>(1);
            Q07_LinkedListNode<int> node12 = new Q07_LinkedListNode<int>(1);

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