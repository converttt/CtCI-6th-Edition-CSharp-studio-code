using System;
using System.Threading;
using System.Collections.Generic;

namespace Common_Topics
{
    static class LockSlim
    {
        static private List<int> _items = new List<int>();
        static private Random _random = new Random();
        static private ReaderWriterLockSlim _rw = new ReaderWriterLockSlim();

        static public void Write(object threadID)
        {
            while (true)
            {
                int newNumber = GetRandNum(100);
                _rw.EnterWriteLock();
                Console.WriteLine(String.Format("Thread {0} is writing", threadID));
                _items.Add (newNumber);
                Console.WriteLine(String.Format("Thread {0} has finished writing", threadID));
                _rw.ExitWriteLock();
                Console.WriteLine (String.Format("Thread {0} added {1}", threadID, newNumber));
                Thread.Sleep (1000);
            }
        }

        static public void Read(object threadID)
        {
            while (true)
            {
                _rw.EnterReadLock();
                Console.WriteLine(String.Format("Thread {0} is reading", threadID));
                foreach (int i in _items) Thread.Sleep (100);
                Console.WriteLine(String.Format("Thread {0} has finished reading", threadID));
                _rw.ExitReadLock();
            }
        }

        static int GetRandNum (int max) { lock (_random) return _random.Next(max); }
    }
}