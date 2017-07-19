using System;
using System.Text;
using System.Collections.Generic;

namespace Common_Topics
{
    public class HashMap<T>
    {
        const double LoadFactor = 0.72;
        protected int size = 128;
        protected int coefficient = 1;
        protected int count;
        protected LinkedList<Tuple<string, T>>[] hashMap = new LinkedList<Tuple<string, T>>[128];

        public int Hash(string key)
        {
            StringBuilder strRepr = new StringBuilder();
            foreach (char ch in key)
            {
                strRepr.AppendFormat("{0}", (int) ch);
            }

            while (strRepr.Length < 3)
            {
                strRepr.Append("0");
            }

            string repr = strRepr.ToString();
            if (repr.Length > 9)
            {
                repr = repr.Substring(repr.Length - 9);
            }

            int result;
            if (!Int32.TryParse(repr, out result))
            {
                throw new Exception("Could not convert string representation of hash to int");
            }

            result = result / size * coefficient;
            while (result > size)
            {
                result /= 10;
            }

            return result;
        }

        public void Add(string key, T value)
        {
            bool factor = CheckFactor();

            if (!factor)
            {
                ReHash();
            }

            int hash = Hash(key);
            if (hashMap[hash] == null)
            {
                hashMap[hash] = new LinkedList<Tuple<string, T>>();
            }

            hashMap[hash].AddLast(new Tuple<string, T>(key, value));

            count++;
        }

        public T Get(string key)
        {
            int hash = Hash(key);

            if (hashMap[hash] != null)
            {
                foreach (Tuple<string, T> tuple in hashMap[hash])
                {
                    if (tuple.Item1 == key)
                    {
                        return tuple.Item2;
                    }
                }
            } 

            return default(T);
        }

        public void Delete(string key)
        {
            int hash = Hash(key);

            foreach (Tuple<string, T> tuple in hashMap[hash])
            {
                if (tuple.Item1 == key)
                {
                    hashMap[hash].Remove(tuple);
                    count--;
                    break;
                }
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        protected bool CheckFactor()
        {
            double result = (double) 1 / (double) (1 - (double) size / (double) (count + 1));
            if (LoadFactor < result)
            {
                return false;
            }

            return true;
        }

        protected void ReHash()
        {
            size <<= 1;
            coefficient *= 10;
            
            LinkedList<Tuple<string, T>>[] tmp = new LinkedList<Tuple<string, T>>[size];
            foreach (LinkedList<Tuple<string, T>> linked in hashMap)
            {
                if (linked == null)
                {
                    continue;
                }

                foreach (Tuple<string, T> value in linked)
                {
                    int hash = Hash(value.Item1);

                    if (tmp[hash] == null)
                    {
                        tmp[hash] = new LinkedList<Tuple<string, T>>();
                    }

                    tmp[Hash(value.Item1)].AddLast(value);
                }
            }

            hashMap = tmp;
        }
    }
}