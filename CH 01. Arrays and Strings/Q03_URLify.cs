using System;

namespace CH_01._Array_and_Strings
{
    /*
        URLify: Write a method to replace all spaces in a string with '%20. 
        You may assume that the string has sufficient space at the end to hold the additional characters, 
        and that you are given the "true" length of the string. (Note: if implementing in Java, please use a character array so that you can perform this operation in place.)
     */
    public class Q03_URLify
    {
        public string URLify1(string str, int initLength)
        {
            if ((str.Length > 0) == false || initLength <= 0 || str.Length < initLength)
            {
                throw new Exception("Incorrect parameters");
            }

            char[] chars = str.ToCharArray();
            int spaces = 0;
            for (int i = 0; i < initLength; i++)
            {
                if (str[i] == ' ')
                {
                    spaces++;
                }
            }

            if (spaces == 0)
            {
                return str;
            }

            int newLength = initLength + spaces * 2;
            
            if (newLength > str.Length)
            {
                throw new Exception("Incorrect parameters");
            }

            int upperBound = newLength - 1;
            for (int i = initLength - 1; i >= 0; i--)
            {
                if (chars[i] == ' ')
                {
                    chars[upperBound]       = '0';
                    chars[upperBound - 1]   = '2';
                    chars[upperBound - 2]   = '%';
                    upperBound -= 3;
                }
                else
                {
                    chars[upperBound] = chars[i];
                    upperBound--;
                }
            }

            str = new string(chars);

            return str;
        }
    }
}