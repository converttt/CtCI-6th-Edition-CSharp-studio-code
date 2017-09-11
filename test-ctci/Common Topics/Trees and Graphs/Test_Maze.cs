using System;
using Xunit;
using Common_Topics;

namespace test_ctci
{
    public class Test_Maze
    {
        [Fact]
        public void RatInMaze()
        {
            int[,] solution = new int[4, 4];
            
            Maze.RatInMaze(new int[,] {
                {1, 0, 0, 0},
                {1, 1, 0, 1},
                {0, 1, 0, 0},
                {1, 1, 1, 1}
            }, 0, 0, solution);

            Assert.Equal(new int[,] {
                {1, 0, 0, 0},
                {1, 1, 0, 0},
                {0, 1, 0, 0},
                {0, 1, 1, 1}
            }, solution);
        }

        [Fact]
        public void WaysInMaze()
        {
            Assert.Equal(4, Maze.WaysInMaze(new int[,] {
                {0,  0, 0, 0},
                {0, -1, 0, 0},
                {-1, 0, 0, 0},
                {0,  0, 0, 0}
            }, 0 , 0));
        }
    }
}