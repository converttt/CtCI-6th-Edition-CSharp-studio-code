﻿using System;
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
            Threads_RunThreads.Monitor();
        }
    }
}
