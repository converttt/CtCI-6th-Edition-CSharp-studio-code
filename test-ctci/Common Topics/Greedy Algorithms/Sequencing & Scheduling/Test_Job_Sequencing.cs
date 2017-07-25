using System;
using System.Collections.Generic;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Sequencing
    {
        [Fact]
        public void FindSequence1()
        {
            Sequencing_Job job1 = new Sequencing_Job("a", 2, 100);
            Sequencing_Job job2 = new Sequencing_Job("b", 1, 19);
            Sequencing_Job job3 = new Sequencing_Job("c", 2, 27);
            Sequencing_Job job4 = new Sequencing_Job("d", 1, 25);
            Sequencing_Job job5 = new Sequencing_Job("e", 3, 15);

            List<Sequencing_Job> result = Greedy_Sequencing.FindSequence1(new Sequencing_Job[] {
                job1, job2, job3, job4, job5
            });

            Assert.Equal(3, result.Count);
            Assert.Equal(job3, result[0]);
            Assert.Equal(job1, result[1]);
            Assert.Equal(job5, result[2]);
        }

        [Fact]
        public void FindSequence2()
        {
            Sequencing_Job job1 = new Sequencing_Job("a", 2, 100);
            Sequencing_Job job2 = new Sequencing_Job("b", 1, 19);
            Sequencing_Job job3 = new Sequencing_Job("c", 2, 27);
            Sequencing_Job job4 = new Sequencing_Job("d", 1, 25);
            Sequencing_Job job5 = new Sequencing_Job("e", 3, 15);

            List<Sequencing_Job> result = Greedy_Sequencing.FindSequence2(new Sequencing_Job[] {
                job1, job2, job3, job4, job5
            });

            Assert.Equal(3, result.Count);
            Assert.Equal(job3, result[0]);
            Assert.Equal(job1, result[1]);
            Assert.Equal(job5, result[2]);
        }
    }
}