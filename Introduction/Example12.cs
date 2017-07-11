using System;
using System.Collections.Generic;

namespace Introduction
{
    public class Example12
    {
        public List<string> GetPermutations(string str)
        {
            List<string> results = new List<string>();
            Permute(str, "", results);

            return results;
        }

        public string Permute(string str, string prefix, List<string> results)
        {
            if (str.Length == 0)
            {
                results.Add(prefix);
                return prefix;
            }

            string newString = "";
            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                string modified = str.Substring(0, i) + str.Substring(i + 1);
                newString = Permute(modified, prefix + ch, results);
            }

            return newString;
        }
    }
}
