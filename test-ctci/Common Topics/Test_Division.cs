using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Division
    {
        [Fact]
        public void Division()
        {
            Assert.Equal(2, Common_Topics.Division.Divide(5, 2));
            Assert.Equal(0, Common_Topics.Division.Divide(11, 12));
            Assert.Equal(6612, Common_Topics.Division.Divide(99191, 15));
            Assert.Equal(-2, Common_Topics.Division.Divide(2, -1));
            Assert.Equal(3, Common_Topics.Division.Divide(-9, -3));
        }
    }
}