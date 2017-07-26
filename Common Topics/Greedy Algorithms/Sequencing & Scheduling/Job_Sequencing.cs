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

            Complexety O(n^2)
         */
        public static List<Sequencing_Job> FindSequence1(Sequencing_Job[] jobs)
        {
            List<Sequencing_Job> jobSequence = new List<Sequencing_Job>();

            if (jobs.Length <= 0)
            {
                return jobSequence;
            }

            Array.Sort(jobs, new Sequencing_ReverseComparerProfit());

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

        /*
            Given a set of n jobs where each job i has a deadline di >=1 and profit pi>=0. 
            Only one job can be scheduled at a time. Each job takes 1 unit of time to complete. 
            We earn the profit if and only if the job is completed by its deadline. 
            The task is to find the subset of jobs that maximizes profit.

            Complexety: O(n*log(n))
         */
        public static List<Sequencing_Job> FindSequence2(Sequencing_Job[] jobs)
        {
            List<Sequencing_Job> jobSequence = new List<Sequencing_Job>();

            if (jobs.Length <= 0)
            {
                return jobSequence;
            }

            Array.Sort(jobs, new Sequencing_ReverseComparerProfit());

            int maxDeadline = Int32.MinValue;
            foreach (Sequencing_Job job in jobs)
            {
                if (job.Deadline > maxDeadline)
                {
                    maxDeadline = job.Deadline;
                }
            }

            Sequencing_DisjointSet disjointSet = new Sequencing_DisjointSet(maxDeadline);
            Sequencing_Job[] results = new Sequencing_Job[maxDeadline + 1];

            for (int i = 0; i < jobs.Length; i++)
            {
                int slot = disjointSet.Find(jobs[i].Deadline);

                if (slot > 0)
                {
                    int parentSlot = disjointSet.Find(slot - 1);
                    disjointSet.Merge(parentSlot, slot);
                    results[slot] = jobs[i];
                }
            }

            foreach (Sequencing_Job job in results)
            {
                if (job != null)
                {
                    jobSequence.Add(job);
                }
            }

            return jobSequence;
        }

        /*
            The problem of scheduling unit-time tasks with deadlines and penalities for a single processor has following inputs
            S={a1,a2,...,an} of n unit-time task. 
            A unit-time task requires exactly 1 unit of time to complete
            deadlines d1,d2,...,dn, 1<=di<=n
            penalities w1,w2,...,wn. 
            A penality wi is incurred if task ai is not finished by time di, and no penality if task finishes at deadline
            The problem is to find a schedule for S that minimizes the total penalty incurred for missed deadlines

            Complexety: O(n*log(n))
         */
        public static List<Tuple<Sequencing_Job, bool>> FindSequence3(Sequencing_Job[] jobs)
        {
            List<Tuple<Sequencing_Job, bool>> sequence = new List<Tuple<Sequencing_Job, bool>>();

            if (jobs.Length <= 0)
            {
                return sequence;
            }

            Array.Sort(jobs, new Sequencing_ReverseComparerPenalty());

            int maxDeadline = Int32.MinValue;
            foreach (Sequencing_Job job in jobs)
            {
                if (job.Deadline > maxDeadline)
                {
                    maxDeadline = job.Deadline;
                }
            }

            Sequencing_DisjointSet disjointSet = new Sequencing_DisjointSet(maxDeadline);
            List<Sequencing_Job> penalised = new List<Sequencing_Job>();
            Sequencing_Job[] tmpSequence = new Sequencing_Job[jobs.Length];
            foreach (Sequencing_Job job in jobs)
            {
                int slot = disjointSet.Find(job.Deadline);

                if (slot > 0)
                {
                    disjointSet.Merge(disjointSet.Find(slot - 1), slot);
                    tmpSequence[slot - 1] = job;
                }
                else
                {
                    penalised.Add(job);
                }
            }

            foreach (Sequencing_Job job in tmpSequence)
            {
                if (job != null)
                {
                    sequence.Add(new Tuple<Sequencing_Job, bool>(job, false));
                }
            }

            foreach (Sequencing_Job job in penalised)
            {
                sequence.Add(new Tuple<Sequencing_Job, bool>(job, true));
            }

            return sequence;
        }
    }

    public class Sequencing_Job : IComparable<Sequencing_Job>
    {
        protected string name;
        protected int deadline;
        protected int profit;
        protected int penalty;

        public Sequencing_Job(string name, int deadline, int profit, int penalty = 0)
        {
            this.name = name;
            this.deadline = deadline;
            this.profit = profit;
            this.penalty = penalty;
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

        public int Penalty
        {
            get
            {
                return penalty;
            }
        }
    }

    public class Sequencing_ReverseComparerProfit : IComparer<Sequencing_Job>
    {
        int IComparer<Sequencing_Job>.Compare(Sequencing_Job x, Sequencing_Job y)
        {
            return -1 * x.Profit.CompareTo(y.Profit);
        }
    }

    public class Sequencing_ReverseComparerPenalty : IComparer<Sequencing_Job>
    {
        int IComparer<Sequencing_Job>.Compare(Sequencing_Job x, Sequencing_Job y)
        {
            return -1 * x.Penalty.CompareTo(y.Penalty);
        }
    }

    public class Sequencing_DisjointSet
    {
        protected int[] disjointSet;

        public Sequencing_DisjointSet(int slots)
        {
            disjointSet = new int[slots + 1];
            for (int i = 0; i <= slots; i++)
            {
                disjointSet[i] = i;
            }
        }

        public int Find(int subset)
        {
            if (disjointSet[subset] == subset)
            {
                return subset;
            }

            return Find(disjointSet[subset]);
        }

        public void Merge(int parent, int child)
        {
            disjointSet[child] = parent;
        }
    }
}