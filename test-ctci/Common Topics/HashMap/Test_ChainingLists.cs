using System;
using System.Text;
using System.Collections.Generic;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_HashMap_ChainingLists
    {
        [Fact]
        public void Add()
        {
            HashMap<string> hashMap = new HashMap<string>();

            hashMap.Add("bla", "Hello World!");
            hashMap.Add("test", "This is a test");
            hashMap.Add("newkey", "Some secret key");
            hashMap.Add("fun", "It was fun");

            Assert.Equal("Hello World!", hashMap.Get("bla"));
            Assert.Equal("This is a test", hashMap.Get("test"));
            Assert.Equal("Some secret key", hashMap.Get("newkey"));
            Assert.Equal("It was fun", hashMap.Get("fun"));
            Assert.Null(hashMap.Get("null"));

            Assert.Equal(4, hashMap.Count);

            hashMap.Delete("fun");

            Assert.Null(hashMap.Get("fun"));
            Assert.Equal(3, hashMap.Count);
        }

        [Fact]
        public void ReHash()
        {
            HashMap<int> hashMap = new HashMap<int>();

            for (int i = 0; i <= 128; i++)
            {
                string key = RandomKey();
                hashMap.Add(key, i);
            }

            Assert.Equal(129, hashMap.Count);
            Assert.Equal(256, hashMap.Size);
        }

        public string RandomKey()
        {
            Random rand = new Random();
            StringBuilder result = new StringBuilder();
            
            int length = rand.Next(1, 32);

            int count = 0;
            while (count <= length)
            {
                char ch = (char) rand.Next(97, 123);
                result.AppendFormat("{0}", ch);

                count++;
            }

            return result.ToString();
        }
    }
}