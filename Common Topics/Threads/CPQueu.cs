using System;
using System.Threading;
using System.Collections.Generic;

namespace Common_Topics
{
    /**
        Producer/Consumer Queue
        Resource: http://www.albahari.com/threading/part4.aspx#_Wait_and_Pulse
     */
    public class CPQueue
    {
        private Queue<Action> _queue = new Queue<Action>();
        private Object _lockObject = new Object();
        private Thread _consumer;

        public CPQueue()
        {
            (_consumer = new Thread(Consume)).Start();
        }

        public void EnqueuAction(Action item)
        {
            lock (_lockObject)
            {
                _queue.Enqueue(item);
                Monitor.Pulse(_lockObject);
            }
        }

        public void ShutDown(bool waitForWorkers)
        {
            EnqueuAction(null);

            if (waitForWorkers)
            {
                _consumer.Join();
            }
        }

        public void Consume()
        {
            while(true)
            {
                lock (_lockObject)
                {
                    while (_queue.Count == 0) Monitor.Wait(_lockObject);
                    
                    Action item = _queue.Dequeue();
                    if (item == null) return;
                    item();
                }
            }
        }
    }
}