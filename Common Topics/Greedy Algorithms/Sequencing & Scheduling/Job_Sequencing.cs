using System;
using System.Collections;
using System.Collections.Generic;

namespace Common_Topics
{
    public static class Greedy_Sequencing
    {
        /*
            Given an array of jobs where every job has a deadline and associated profit if the job is finished before the deadline. 
            It is also given that every job takes single unit of time, so the minimum possible deadline for any job is 1. 
            How to maximize total profit if only one job can be scheduled at a time.
         */
        public static List<Sequencing_Job> FindSequence1(Sequencing_Job[] jobs)
        {
            List<Sequencing_Job> jobSequence = new List<Sequencing_Job>();

            if (jobs.Length <= 0)
            {
                return jobSequence;
            }

            Array.Sort(jobs, new Sequencing_ReverseComparer());

            Sequencing_Job[] slots = new Sequencing_Job[jobs.Length];
            for (int i = 0; i < jobs.Length; i++)
            {
                for (int j = Math.Min(jobs.Length, jobs[i].Deadline) - 1; j >= 0; j--)
                {
                    if (slots[j] == null)
                    {
                        slots[j] = jobs[i];
                        break;
                    }
                }
            }

            foreach (Sequencing_Job slot in slots)
            {
                if (slot != null)
                {
                    jobSequence.Add(slot);
                }
            }

            return jobSequence;
        }
    }

    public class Sequencing_Job : IComparable<Sequencing_Job>
    {
        protected string name;
        protected int deadline;
        protected int profit;

        public Sequencing_Job(string name, int deadline, int profit)
        {
            this.name = name;
            this.deadline = deadline;
            this.profit = profit;
        }

        int IComparable<Sequencing_Job>.CompareTo(Sequencing_Job obj)
        {
            Sequencing_Job job = obj as Sequencing_Job;

            return profit.CompareTo(job.Profit);
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int Deadline
        {
            get
            {
                return deadline;
            }
        }

        public int Profit
        {
            get
            {
                return profit;
            }
        }
    }

    public class Sequencing_ReverseComparer : IComparer<Sequencing_Job>
    {
        int IComparer<Sequencing_Job>.Compare(Sequencing_Job x, Sequencing_Job y)
        {
            return -1 * x.Profit.CompareTo(y.Profit);
        }
    }
}