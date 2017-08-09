using System;
using System.Threading;

namespace Common_Topics
{
    public class Threads_Task : IThreads_Task
    {
        private int _id;
        private string _name;

        public Threads_Task(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int ID
        {
            get
            {
                return _id;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public void Do()
        {
            Random random = new Random();
            int millis = random.Next(1000, 2001);

            Console.WriteLine(String.Format("Thread {0} starts doing task Task: {1} Time: {2}", Thread.CurrentThread.Name, _name, millis));
            Thread.Sleep(millis);
            Console.WriteLine(String.Format("Thread {0} finishes doing task Task: {1} Time: {2}", Thread.CurrentThread.Name, _name, millis));
        }
    }
}