using System;
using System.Threading;

namespace Common_Topics
{
    public static class Threads_RunThreads
    {
        public const int CONSUMERS_IN_POOL = 7;

        public static void Monitor()
        {
            Thread_WorkerMonitor worker = new Thread_WorkerMonitor();
            Threads_Producer producer = new Threads_Producer(worker);
            Threads_Consumer consumer = new Threads_Consumer(worker);
            
            Thread p = new Thread(producer.Produce);
            Thread c1 = new Thread(consumer.Consume);
            Thread c2 = new Thread(consumer.Consume);

            c1.Name = "Thread 1";
            c1.Start();

            c2.Name = "Thread 2";
            c2.Start();

            Thread.Sleep(1000);

            p.Start();
        }

        public static void Semaphores()
        {
            Thread_WorkerSemaphores worker = new Thread_WorkerSemaphores();
            Threads_Producer producer = new Threads_Producer(worker);
            Threads_Consumer consumer = new Threads_Consumer(worker);

            Thread p = new Thread(producer.Produce);
            Thread[] c = new Thread[7];

            for (int i = 0; i < CONSUMERS_IN_POOL; i++)
            {
                c[i] = new Thread(consumer.Consume);
                c[i].Name = String.Format("Tread{0}", i);
                c[i].Start();
            }

            Thread.Sleep(1000);

            p.Start();
        }
    }
}