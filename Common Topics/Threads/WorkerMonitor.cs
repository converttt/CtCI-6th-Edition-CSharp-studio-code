using System;
using System.Threading;
using System.Collections.Generic;

namespace Common_Topics
{
    public class Thread_WorkerMonitor : IThreads_ProducingConsuming
    {
        const int MAX_BUNCHES = 3;
        const int MAX_SLOTS = 3;

        private Queue<IThreads_Task> _queue = new Queue<IThreads_Task>();
        private int _bunch = 1;
        private Object lockObject = new Object();

        public void Producing()
        {
            Console.WriteLine("Start Producing");
            int i = 1;

            while (_bunch <= MAX_BUNCHES)
            {
                lock (lockObject)
                {
                    while (_queue.Count < MAX_SLOTS)
                    {
                        Console.WriteLine(String.Format("Create Task: {0}.{1}", _bunch, i));
                        _queue.Enqueue(new Threads_Task(i, String.Format("Task: {0}.{1}", _bunch, i)));
                        i++;
                    }

                    Monitor.Pulse(lockObject);

                    if (_bunch < MAX_BUNCHES)
                    {
                        Monitor.Wait(lockObject);
                    }
                    else
                    {
                        return;
                    }
                }

                _bunch++;
            }
        }

        public void Consuming()
        {
            Console.WriteLine("Start Consuming");
            while (true)
            {
                lock (lockObject)
                {
                    if (_queue.Count <= 0)
                    {
                        if (_bunch >= MAX_BUNCHES)
                        {
                            return;
                        }

                        Monitor.Pulse(lockObject);
                        Monitor.Wait(lockObject);
                        continue;
                    }

                    IThreads_Task task = _queue.Dequeue();
                    task.Do();
                }
            }
        }
    }
}