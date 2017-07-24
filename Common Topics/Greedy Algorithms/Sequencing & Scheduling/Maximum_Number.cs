using System;
using System.Collections;
using System.Collections.Generic;

// You are given n activities with their start and finish times. 
// Select the maximum number of activities that can be performed by a single person, 
// assuming that a person can only work on a single activity at a time.

namespace Common_Topics
{
    public static class Greedy_Maximum_Number
    {
        public static LinkedList<Greedy_Task> FindTaskSequence(Greedy_Task[] tasks)
        {
            LinkedList<Greedy_Task> sequence = new LinkedList<Greedy_Task>();

            if (tasks.Length <= 0)
            {
                return sequence;
            }

            Heapsort<Greedy_Task> heap = new Heapsort<Greedy_Task>();
            int lastAdded = 0;
            heap.PerformHeapSort(tasks);

            sequence.AddLast(tasks[0]);
            for (int i = 1; i < tasks.Length; i++)
            {
                if (tasks[i].Starttime >= sequence.Last.Value.Endtime)
                {
                    sequence.AddLast(tasks[i]);
                    lastAdded = i;
                }
            }

            return sequence;
        }
    }

    public class Greedy_Task : IComparable
    {
        protected int starttime;
        protected int endtime;

        public Greedy_Task(int starttime, int endtime)
        {
            this.starttime = starttime;
            this.endtime = endtime;
        }

        public int CompareTo(object taskToCompare)
        {
            Greedy_Task task = taskToCompare as Greedy_Task;

            return this.endtime.CompareTo(task.Endtime);
        }

        public int Starttime
        {
            get
            {
                return starttime;
            }
        }

        public int Endtime
        {
            get
            {
                return endtime;
            }
        }
    }
}