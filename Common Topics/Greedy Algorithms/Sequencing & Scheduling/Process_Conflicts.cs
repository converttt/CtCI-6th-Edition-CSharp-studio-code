using System;
using System.Collections.Generic;

namespace Common_Topics
{
    public static class Process_Conflicts
    {
        public static Greedy_Process[] FindConflicts(Greedy_Process[] processes)
        {
            Array.Sort(processes, new Process_ComparerMemoryThenTime());

            return processes;
        }
    }

    public class Greedy_Process
    {
        protected int id;
        protected int memoryBlock;
        protected int timeSlot;
        protected string operation;

        public const string Read = "R";
        public const string Write = "W";

        public Greedy_Process(int id, int memoryBlock, int timeSlot, string operation)
        {
            this.id = id;
            this.memoryBlock = memoryBlock;
            this.timeSlot = timeSlot;
            this.operation = operation;
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public int MemoryBlock
        {
            get
            {
                return memoryBlock;
            }
        }

        public int TimeSlot
        {
            get
            {
                return timeSlot;
            }
        }

        public string Operation
        {
            get
            {
                return operation;
            }
        }
    }

    public class Process_ComparerMemoryThenTime : IComparer<Greedy_Process>
    {
        int IComparer<Greedy_Process>.Compare(Greedy_Process x, Greedy_Process y)
        {
            if (x.MemoryBlock == y.MemoryBlock)
            {
                return x.TimeSlot.CompareTo(y.TimeSlot);
            }
            else
            {
                return x.MemoryBlock.CompareTo(y.MemoryBlock);
            }
        }
    }
}