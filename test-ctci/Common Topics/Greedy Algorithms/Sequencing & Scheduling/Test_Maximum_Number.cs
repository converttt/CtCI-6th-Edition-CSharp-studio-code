using System;
using System.Collections.Generic;
using Xunit;
using Common_Topics;

// You are given n activities with their start and finish times. 
// Select the maximum number of activities that can be performed by a single person, 
// assuming that a person can only work on a single activity at a time.

namespace test_ctci
{
    public class Test_Maximum_Number
    {
        [Fact]
        public void FindMaxNumber()
        {
            Greedy_Task task1 = new Greedy_Task(5, 7);
            Greedy_Task task2 = new Greedy_Task(5, 9);
            Greedy_Task task3 = new Greedy_Task(1, 2);
            Greedy_Task task4 = new Greedy_Task(0, 6);
            Greedy_Task task5 = new Greedy_Task(8, 9);
            Greedy_Task task6 = new Greedy_Task(3, 4);

            Greedy_Task[] tasks = new Greedy_Task[] {
                task1, task2, task3,
                task4, task5, task6
            };

            LinkedList<Greedy_Task> sequence = Greedy_Maximum_Number.FindTaskSequence(tasks);

            Assert.Equal(sequence.Count, 4);
            Assert.Equal(sequence.First.Value, task3);
            Assert.Equal(sequence.Last.Value, task5);
        }
    }
}