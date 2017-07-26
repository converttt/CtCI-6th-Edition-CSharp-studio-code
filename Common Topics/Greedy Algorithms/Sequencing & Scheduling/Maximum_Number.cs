using System;
using System.Collections;
using System.Collections.Generic;

namespace Common_Topics
{
    public static class Greedy_Maximum_Number
    {
        // You are given n activities with their start and finish times. 
        // Select the maximum number of activities that can be performed by a single person, 
        // assuming that a person can only work on a single activity at a time.
        //
        //Complexety: O(n*log(n))
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

        /*
            The array of tasks is given. 
            Find the number of tasks that are performed simultaneusly.

            Complexety: O(n*log(n))
         */
        public static List<Greedy_Task> FindOverlapNumber(Greedy_Task[] tasks)
        {
            List<Greedy_Task> overlapped = new List<Greedy_Task>();

            if (tasks.Length <= 0)
            {
                return overlapped;
            }

            if (tasks.Length == 1)
            {
                overlapped.Add(tasks[0]);
                return overlapped;
            }

            Greedy_Task[] starts = new Greedy_Task[tasks.Length];
            for (int i = 0; i < tasks.Length; i++)
            {
                starts[i] = tasks[i];
            }

            Greedy_Task[] ends = new Greedy_Task[tasks.Length];
            for (int i = 0; i < tasks.Length; i++)
            {
                ends[i] = tasks[i];
            }

            Array.Sort(starts, new Number_ComparerStarttime());
            Array.Sort(ends, new Number_ComparerEndtime());

            int startCoursor = 1;
            int endCoursor = 0;
            int currentNumber = 1;
            int maxNumber = 1;

            HashSet<Greedy_Task> tmpSet = new HashSet<Greedy_Task>();
            tmpSet.Add(starts[0]);

            while (startCoursor < tasks.Length && endCoursor < tasks.Length)
            {
                if (starts[startCoursor].Starttime < ends[endCoursor].Endtime)
                {
                    currentNumber++;
                    tmpSet.Add(starts[startCoursor]);

                    if (currentNumber > maxNumber)
                    {
                        maxNumber = currentNumber;
                        
                        overlapped.Clear();
                        foreach (Greedy_Task task in tmpSet)
                        {
                            overlapped.Add(task);
                        }
                    }

                    startCoursor++;
                }
                else
                {
                    currentNumber--;
                    tmpSet.Remove(ends[endCoursor]);

                    endCoursor++;
                }
            }

            return overlapped;
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

    public class Number_ComparerEndtime : IComparer<Greedy_Task>
    {
        int IComparer<Greedy_Task>.Compare(Greedy_Task x, Greedy_Task y)
        {
            return x.Endtime.CompareTo(y.Endtime);
        }
    }

    public class Number_ComparerStarttime : IComparer<Greedy_Task>
    {
        int IComparer<Greedy_Task>.Compare(Greedy_Task x, Greedy_Task y)
        {
            return x.Starttime.CompareTo(y.Starttime);
        }
    }
}