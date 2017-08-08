using System;
using System.Threading;

namespace Common_Topics
{
    class Threads_Producer : IThreads_Producer
    {
        private IThreads_ProducingConsuming _worker;

        public Threads_Producer(IThreads_ProducingConsuming worker)
        {
            _worker = worker;
        }

        public void Produce()
        {
            Console.WriteLine(String.Format("Producer {0} has started", Thread.CurrentThread.Name));
            
            _worker.Producing();

            Console.WriteLine(String.Format("Producer {0} has stopped", Thread.CurrentThread.Name));
        }
    }
}