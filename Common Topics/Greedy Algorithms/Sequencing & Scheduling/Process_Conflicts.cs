using System;
using System.Collections.Generic;

namespace Common_Topics
{
    public static class Process_Conflicts
    {
        /*
            Consider a RAM organized in blocks. There are multiple processes running on the system. Every application gets below information.

            (Thread T, Memory Block M, time t, R/W) which essentially tells that the thread T was using memory block M at time t and operation could be read or write.

            Memory conflict is defined as –
            – Multiple read operations at the same location are not cause of conflict.
            – One write operation between x+5 to x-5 to location M, will be cause of conflict for a thread accessing location M at time x where x is some time in standard unit of time measurement.
            – Example – If thread T1 accessed memory location M at time x+1 and if a thread T2 accesses location M before time x+6, then T1 and T2 are candidate of conflict given one of them does write operation.

            Find conflicted pairs of processes
            Complexity: O(nLogn + m), m - the number of conflicts
         */
        public static List<Tuple<Greedy_Process, Greedy_Process>> FindConflicts(Greedy_Process[] processes)
        {
            List<Tuple<Greedy_Process, Greedy_Process>> result = new List<Tuple<Greedy_Process, Greedy_Process>>();

            if (processes.Length < 2)
            {
                return result;
            }

            Array.Sort(processes, new Process_ComparerMemoryThenTime());

            for (int i = 1; i < processes.Length; i++)
            {
                if (processes[i].MemoryBlock == processes[i - 1].MemoryBlock)
                {
                    if (processes[i].TimeSlot <= processes[i - 1].TimeSlot + 5)
                    {
                        int j = i - 1;

                        while (processes[i].MemoryBlock == processes[j].MemoryBlock &&
                            processes[i].TimeSlot <= processes[j].TimeSlot + 5 &&
                            j >= 0)
                        {
                            if (processes[i].Operation == Greedy_Process.Write || 
                                processes[j].Operation == Greedy_Process.Write)
                            {
                                result.Add(new Tuple<Greedy_Process, Greedy_Process>(processes[i], processes[j]));
                            }

                            j--;
                        }
                    }
                }
            }

            return result;
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