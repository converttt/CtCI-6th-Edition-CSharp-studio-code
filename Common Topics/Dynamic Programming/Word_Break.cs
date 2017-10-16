using System;
using System.Text;
using System.Collections.Generic;

namespace Common_Topics
{
    /*
        Given an input string and a dictionary of words, find out if the input string can be segmented into a space-separated sequence of dictionary words.
     */
    public class Word_Break
    {
        protected List<string> dictionary = new List<string>();

        public Word_Break(List<string> dictionary)
        {
            this.dictionary = dictionary;
        }

        public List<string> AllSentences(string input)
        {
            List<string> results = new List<string>();
            FindBreak(input, new LinkedList<string>(), results);

            return results;
        }

        protected void FindBreak(string input, LinkedList<string> tmpResult, List<string> results)
        {
            for (int i = 1; i <= input.Length; i++)
            {
                string prefix = input.Substring(0, i);

                if (Contains(prefix))
                {
                    tmpResult.AddLast(prefix);

                    if (i == input.Length)
                    {
                        results.Add(ListToString(tmpResult));
                    }

                    string[] words = new string[tmpResult.Count];
                    tmpResult.CopyTo(words, 0);
                    FindBreak(input.Substring(i), new LinkedList<string>(words), results);

                    tmpResult.RemoveLast();
                }
            }
        }

        protected bool Contains(string substring)
        {
            return dictionary.Contains(substring);
        }

        protected string ListToString(LinkedList<string> wordsList)
        {
            StringBuilder output = new StringBuilder();

            string[] words = new string[wordsList.Count];
            wordsList.CopyTo(words, 0);

            for (int i = 0; i < words.Length; i++)
            {
                output.Append(words[i]);
                if (i < words.Length - 1)
                {
                    output.Append(" ");
                }
            }

            return output.ToString();
        }
    }
}