using System;
using Common_Topics;

namespace ctci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cracking The Coding Interview!");

            Threads_Monitor();
        }

        static void Threads_Monitor()
        {
            /*
                Producer Consumer Problem
             */
            // Threads_RunThreads.Monitor();


            /*
                Producer Consumer Problem with Semaphores
             */
            // Threads_RunThreads.Semaphores();

            /*
                Producer Consumer Pattern with a queue
             */
            // Threads_RunThreads.CPQueueTemplate();

            /*
                Reader/Writer Locks pattern
                Concurrent read operations but not concurrent updates (nor for a concurrent read and update) are allowed.
             */
            // Threads_RunThreads.readWriteLockSlim();
        }
    }
}
