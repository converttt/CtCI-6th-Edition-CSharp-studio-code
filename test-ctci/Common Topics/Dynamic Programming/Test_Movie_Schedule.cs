using System;
using System.Collections.Generic;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Movie_Schedule
    {
        [Fact]
        public void GetSchedules()
        {
            Movie_Schedule schedule = new Movie_Schedule(new List<Movie>(new Movie[] {
                new Movie("Shining", new int[] {14, 15, 16}),
                new Movie("Kill Bill", new int[] {14, 15}),
                new Movie("Pulp Fiction", new int[] {14, 15})
            }));
            List<LinkedList<Movie>> schedules = schedule.CreatePossibleSchedules();

            Assert.Equal(2, schedules.Count);
        }
    }
}