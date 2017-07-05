using System;
using System.Collections.Generic;
using Xunit;
using CH_02._Linked_Lists;

namespace test_ctci
{
    public class Test_Chapter02_Q6_Palindrome
    {
        private Q06_Palindrome<int> palindrome = new Q06_Palindrome<int>();

        [Fact]
        public void IsPalindrome1()
        {            
            Assert.Equal(true, palindrome.IsPalindrome1(new LinkedList<int>(new int[] {1, 2, 3, 2, 1})));
            Assert.Equal(true, palindrome.IsPalindrome1(new LinkedList<int>(new int[] {1, 2, 3, 3, 2, 1})));

            Assert.Equal(false, palindrome.IsPalindrome1(new LinkedList<int>(new int[] {1, 2, 3, 4, 2, 1})));
            Assert.Equal(false, palindrome.IsPalindrome1(new LinkedList<int>(new int[] {1, 2, 3})));
        }

        [Fact]
        public void IsPalindrome2()
        {
            LinkedList<int> list1 = new LinkedList<int>(new int[] {1, 2, 3, 2, 1});
            LinkedList<int> list2 = new LinkedList<int>(new int[] {1, 2, 3, 3, 2, 1});
            LinkedList<int> list3 = new LinkedList<int>(new int[] {1, 2, 3, 4, 2, 1});
            LinkedList<int> list4 = new LinkedList<int>(new int[] {1, 2, 3});

            Assert.Equal(true, palindrome.IsPalindrome2(list1.First));
            Assert.Equal(true, palindrome.IsPalindrome2(list2.First));

            Assert.Equal(false, palindrome.IsPalindrome2(list3.First));
            Assert.Equal(false, palindrome.IsPalindrome2(list4.First));
        }
    }
}