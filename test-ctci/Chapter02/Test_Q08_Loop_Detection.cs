using System;
using System.Collections.Generic;
using Xunit;
using CH_02._Linked_Lists;
using lib_ctci;

namespace test_ctci
{
    public class Test_Chapter02_Q8_Loop_Detection
    {
        private Q08_Loop_Detection<int> loopDetection = new Q08_Loop_Detection<int>();

        [Fact]
        public void FindBeginning()
        {
            CtciLinkedListNode<int> node1 = new CtciLinkedListNode<int>(1);
            CtciLinkedListNode<int> node2 = new CtciLinkedListNode<int>(2);
            CtciLinkedListNode<int> node3 = new CtciLinkedListNode<int>(3);
            CtciLinkedListNode<int> node4 = new CtciLinkedListNode<int>(4);
            CtciLinkedListNode<int> node5 = new CtciLinkedListNode<int>(5);
            CtciLinkedListNode<int> node6 = new CtciLinkedListNode<int>(6);
            CtciLinkedListNode<int> node7 = new CtciLinkedListNode<int>(7);
            CtciLinkedListNode<int> node8 = new CtciLinkedListNode<int>(8);
            CtciLinkedListNode<int> node9 = new CtciLinkedListNode<int>(9);
            CtciLinkedListNode<int> node10 = new CtciLinkedListNode<int>(10);
            CtciLinkedListNode<int> node11 = new CtciLinkedListNode<int>(11);
            CtciLinkedListNode<int> node12 = new CtciLinkedListNode<int>(12);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node6;
            node6.Next = node7;
            node7.Next = node8;
            node8.Next = node9;
            node9.Next = node10;
            node10.Next = node11;
            node11.Next = node12;
            
            node12.Next = node5;
            Assert.Equal(node5, loopDetection.FindBeginning(node1));

            node12.Next = node7;
            Assert.Equal(node7, loopDetection.FindBeginning(node1));

            node12.Next = null;
            Assert.Null(loopDetection.FindBeginning(node1));
        }
    }
}