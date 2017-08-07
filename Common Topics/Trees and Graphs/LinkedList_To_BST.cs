using System;
using System.Collections.Generic;

namespace Common_Topics
{
    public static class LinkedList_To_BST
    {
        private static LinkedListNode<int> _currentLinkedListNode;
        private static LinkedList<int> _linkedList;

        /*
            Given a Singly Linked List which has data members sorted in ascending order. 
            Construct a Balanced Binary Search Tree which has same data members as the given Linked List.

            Time Complexity: O(n)
         */
        public static LinkedList_To_BST_Node BuildTree1(LinkedList<int> linkedList)
        {
            _currentLinkedListNode = linkedList.First;
            return _BuildTreeRecur1(linkedList.Count);
        }

        /*
            Given a Singly Linked List which has data members sorted in ascending order. 
            Construct a Balanced Binary Search Tree which has same data members as the given Linked List.

            Time Complexity: O(n * (1 + n) / 2)
         */
        public static LinkedList_To_BST_Node BuildTree2(LinkedList<int> linkedList)
        {
            _linkedList = linkedList;
            return _BuildTreeRecur2(0, linkedList.Count - 1);
        }

        private static LinkedList_To_BST_Node _BuildTreeRecur1(int n)
        {
            if (n <= 0)
            {
                return null;
            }

            LinkedList_To_BST_Node leftNode = _BuildTreeRecur1(n / 2);

            LinkedList_To_BST_Node root = new LinkedList_To_BST_Node(_currentLinkedListNode.Value);

            _currentLinkedListNode = _currentLinkedListNode.Next;

            LinkedList_To_BST_Node rightNode = _BuildTreeRecur1(n - n/2 - 1);

            root.Left = leftNode;
            root.Right = rightNode;

            return root;
        }

        private static LinkedList_To_BST_Node _BuildTreeRecur2(int startN, int endN)
        {
            if (startN == endN)
            {
                return new LinkedList_To_BST_Node(_FindNthNode(startN).Value);
            }
            
            if (startN > endN)
            {
                return null;
            }

            LinkedList_To_BST_Node leftNode = _BuildTreeRecur2(startN, (startN + endN) / 2 - 1);
            LinkedList_To_BST_Node rightNode = _BuildTreeRecur2((startN + endN) / 2 + 1, endN);

            LinkedList_To_BST_Node root = new LinkedList_To_BST_Node(_FindNthNode((startN + endN) / 2).Value);

            root.Left = leftNode;
            root.Right = rightNode;

            return root;
        }

        private static LinkedListNode<int> _FindNthNode(int n)
        {
            LinkedListNode<int> head = _linkedList.First;

            for (int i = 1; i <= n; i++)
            {
                head = head.Next;
            }

            return head;
        }
    }

    public class LinkedList_To_BST_Node
    {
        private LinkedList_To_BST_Node _left;
        private LinkedList_To_BST_Node _right;
        private int _id;

        public LinkedList_To_BST_Node(int id)
        {
            _id = id;
        }

        public int ID
        {
            get
            {
                return _id;
            }
        }

        public LinkedList_To_BST_Node Left
        {
            set
            {
                _left = value;
            }
            get
            {
                return _left;
            }
        }

        public LinkedList_To_BST_Node Right
        {
            set
            {
                _right = value;
            }
            get
            {
                return _right;
            }
        }
    }
}