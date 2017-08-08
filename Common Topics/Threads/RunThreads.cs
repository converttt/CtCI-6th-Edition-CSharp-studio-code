using System;
using System.Threading;

namespace Common_Topics
{
    public static class Threads_RunThreads
    {
        public static void Monitor()
        {
            Thread_WorkerMonitor worker = new Thread_WorkerMonitor();
            Threads_Producer producer = new Threads_Producer(worker);
            Threads_Consumer consumer = new Threads_Consumer(worker);
            
            Thread p = new Thread(producer.Produce);
            Thread c = new Thread(consumer.Consume);

            c.Start();

            Thread.Sleep(1000);

            p.Start();
        }
    }
}