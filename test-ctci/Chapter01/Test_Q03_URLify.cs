using System;
using Xunit;
using CH_01._Array_and_Strings;

namespace test_ctci
{
    public class Test_Chapter01_Q3_URLify
    {
        private Q03_URLify urlify = new Q03_URLify();

        [Fact]
        public void URLify1()
        {
            Assert.Equal("Mr%20John%20Smith", urlify.URLify1("Mr John Smith    ", 13));
            Assert.Equal("Mr%20John%20Smith%20", urlify.URLify1("Mr John Smith       ", 14));
        }
    }
}