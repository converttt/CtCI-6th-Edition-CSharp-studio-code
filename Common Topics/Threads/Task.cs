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
            int millis = random.Next(500, 1001);

            Console.WriteLine(String.Format("Start doing task ID: {0} Name: {1} Time: {2}", _id, _name, millis));
            Thread.Sleep(millis);
            Console.WriteLine(String.Format("Finish doing task ID: {0} Name: {1} Time: {2}", _id, _name, millis));
        }
    }
}