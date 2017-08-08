using System;
using System.Collections.Generic;

namespace Common_Topics
{
    interface IThreads_Task
    {
        int ID { get; }
        string Name { get; }
        void Do();
    }

    interface IThreads_ProducingConsuming
    {
        void Producing();
        void Consuming();
    }

    interface IThreads_Producer
    {
        void Produce();
    }

    interface IThreads_Consumer
    {
        void Consume();
    }
}