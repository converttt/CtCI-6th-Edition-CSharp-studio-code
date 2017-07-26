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

        [Fact]
        public void FindSequence3()
        {
            Sequencing_Job job1 = new Sequencing_Job("a", 4, 0, 70);
            Sequencing_Job job2 = new Sequencing_Job("b", 2, 0, 60);
            Sequencing_Job job3 = new Sequencing_Job("c", 4, 0, 50);
            Sequencing_Job job4 = new Sequencing_Job("d", 3, 0, 40);
            Sequencing_Job job5 = new Sequencing_Job("e", 1, 0, 30);
            Sequencing_Job job6 = new Sequencing_Job("f", 4, 0, 20);
            Sequencing_Job job7 = new Sequencing_Job("g", 6, 0, 10);

            List<Tuple<Sequencing_Job, bool>> result = Greedy_Sequencing.FindSequence3(new Sequencing_Job[] {
                job1, job2, job3, job4, job5, job6, job7
            });

            Assert.True(result[1].Item1.Deadline > 1);
            Assert.True(result[2].Item1.Deadline > 2);
            Assert.True(result[3].Item1.Deadline > 3);
            Assert.True(result[4].Item1.Deadline > 4);

            int penalised = 0;
            int fine = 0;
            foreach (Tuple<Sequencing_Job, bool> tuple in result)
            {
                if (tuple.Item2)
                {
                    penalised++;
                    fine += tuple.Item1.Penalty;
                }
            }

            Assert.Equal(2, penalised);
            Assert.Equal(50, fine);
        }
    }
}