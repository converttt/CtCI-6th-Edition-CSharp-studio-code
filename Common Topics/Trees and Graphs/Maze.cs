using System;

namespace Common_Topics
{
    public static class Maze
    {
        /*
            A Maze is given as N*N binary matrix of blocks where source block is the upper left most block i.e., 
            maze[0][0] and destination block is lower rightmost block i.e., maze[N-1][N-1]. 
            A rat starts from source and has to reach destination. The rat can move only in two directions: forward and down.
         */
        public static bool RatInMaze(int[,] maze, int x, int y, int[,] solution)
        {
            solution[x, y] = 1;

            if (x == maze.GetUpperBound(0) && y == maze.GetUpperBound(0))
            {
                return true;
            }

            if (x + 1 <= maze.GetUpperBound(0) && maze[x + 1, y] == 1 && solution[x + 1, y] == 0)
            {
                if (RatInMaze(maze, x + 1, y, solution) == true)
                {
                    return true;
                }
            }

            if (y + 1 <= maze.GetUpperBound(0) && maze[x, y + 1] == 1 && solution[x, y + 1] == 0)
            {
                if (RatInMaze(maze, x, y + 1, solution) == true)
                {
                    return true;
                }
            }

            solution[x, y] = 0;

            return false;
        }

        /*
            Count number of ways to reach destination in a Maze
         */
        public static int WaysInMaze(int[,] maze, int x, int y, int num = 0)
        {
            if (x == maze.GetUpperBound(0) && y == maze.GetUpperBound(0))
            {
                return num + 1;
            }

            if (x + 1 <= maze.GetUpperBound(0) && maze[x + 1, y] == 0)
            {
                num = WaysInMaze(maze, x + 1, y, num);
            }

            if (y + 1 <= maze.GetUpperBound(0) && maze[x, y + 1] == 0)
            {
                num = WaysInMaze(maze, x, y + 1, num);
            }

            return num;
        }
    }
}