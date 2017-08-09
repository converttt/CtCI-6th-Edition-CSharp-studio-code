using System;
using System.Threading;
using System.Collections.Generic;

namespace Common_Topics
{
    public class Thread_WorkerSemaphores : IThreads_ProducingConsuming
    {
        const int MAX_BUNCHES = 3;
        const int MAX_SLOTS = 7;
        public const int MAX_CONSUMERS = 3;

        private Queue<Threads_Task> _queue = new Queue<Threads_Task>();
        private Semaphore _consumerPool;
        private int _bunch = 1;

        public Thread_WorkerSemaphores()
        {
            _consumerPool = new Semaphore(0, MAX_CONSUMERS);
        }

        public void Producing()
        {
            while (_bunch <= MAX_BUNCHES)
            {
                int i = 1;

                while (_queue.Count < MAX_SLOTS)
                {
                    Console.WriteLine(String.Format("Create Task: {0}.{1}", _bunch, i));
                    _queue.Enqueue(new Threads_Task(i, String.Format("{0}.{1}", _bunch, i)));
                    i++;
                }

                while (_queue.Count > 0)
                {
                    for (int k = 0; k < MAX_CONSUMERS; k++)
                    {
                        _consumerPool.Release();
                        Thread.Sleep(1000);
                    }
                }

                _bunch++;
            }

            for (int k = 0; k < Threads_RunThreads.CONSUMERS_IN_POOL; k++)
            {
                _consumerPool.Release();
            }
        }

        public void Consuming()
        {
            while (true)
            {
                if (_queue.Count > 0)
                {
                    IThreads_Task task = _queue.Dequeue();
                    task.Do();
                }

                if (_bunch <= MAX_BUNCHES)
                {
                    _consumerPool.WaitOne();
                }
                else
                {
                    return;
                }
            }
        }
    }
}