using System;
using System.Collections.Generic;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Word_Break
    {
        [Fact]
        public void Word_Break()
        {
            Word_Break wordbreaker1 = new Word_Break(new List<string>(
                new string[] {
                    "ice", "icecream", "cream", "i", "love" 
                }
            ));

            List<string> result1 = wordbreaker1.AllSentences("iloveicecream");

            Assert.Equal(2, result1.Count);
            Assert.Equal("i love ice cream", result1[0]);
            Assert.Equal("i love icecream", result1[1]);


            Word_Break wordbreaker2 = new Word_Break(new List<string>(
                new string[] {
                    "ice", "icecream", "cream", "mango", "go", "good", "choice", "are", "and", "man"
                }
            ));

            List<string> result2 = wordbreaker2.AllSentences("mangoandicecreamaregoodchoice");
            Assert.Equal(4, result2.Count);
            Assert.Equal("man go and ice cream are good choice", result2[0]);
            Assert.Equal("man go and icecream are good choice", result2[1]);
            Assert.Equal("mango and ice cream are good choice", result2[2]);
            Assert.Equal("mango and icecream are good choice", result2[3]);
        }
    }
}