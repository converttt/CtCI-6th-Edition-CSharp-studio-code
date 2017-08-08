using System;
using System.Threading;

namespace Common_Topics
{
    class Threads_Consumer : IThreads_Consumer
    {
        private IThreads_ProducingConsuming _worker;

        public Threads_Consumer(IThreads_ProducingConsuming worker)
        {
            _worker = worker;
        }

        public void Consume()
        {
            Console.WriteLine(String.Format("Consumer {0} has started", Thread.CurrentThread.Name));

            _worker.Consuming();

            Console.WriteLine(String.Format("Consumer {0} has stopped", Thread.CurrentThread.Name));
        }
    }
}