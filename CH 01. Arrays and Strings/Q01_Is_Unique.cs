using System;

namespace CH_01._Array_and_Strings
{
    public class Q01_Is_Unique
    {
        public bool IsUniqueChar1(string str)
        {
            if (str.Length > 256)
            {
                return false;
            }

            bool[] chars = new bool[256];

            for (int i = 0; i < str.Length; i++)
            {
                int val = (int) str[i];

                if (chars[val] == true)
                {
                    return false;
                }

                chars[val] = true;
            }

            return true;
        }

        public bool IsUniqueChar2(string str)
        {
            if (str.Length > 256)
            {
                return false;
            }

            int checker = 0;

            for (int i = 0; i < str.Length; i++)
            {
                int val = 1 << (int) str[i];

                if ((checker & val) > 0)
                {
                    return false;
                }

                checker |= val;
            }

            return true;
        }
    }
}
