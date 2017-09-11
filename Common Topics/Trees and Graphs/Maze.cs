using System;
using System.Collections.Generic;

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

        /*
            Find shortest path in a maze
         */
        public static int ShortestPath(int[,] maze, int nX, int nY, int mX, int mY)
        {
            if (nX == mX && nY == mY)
            {
                return 0;
            }

            int[,] solution = new int[maze.GetLength(0), maze.GetLength(0)];
            int path = 0;

            Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
            queue.Enqueue(new Tuple<int, int, int>(nX, nY, path));

            while (queue.Count > 0)
            {
                Tuple<int, int, int> node = queue.Dequeue();
                solution[node.Item1, node.Item2] = 1;
                path = node.Item3 + 1;

                if (node.Item1 == mX && node.Item2 == mY)
                {
                    return path;
                }

                if (node.Item1 - 1 >= 0 && maze[node.Item1 - 1, node.Item2] == 1 && solution[node.Item1 - 1, node.Item2] == 0)
                {
                    queue.Enqueue(new Tuple<int, int, int>(node.Item1 - 1, node.Item2, path));
                }

                if (node.Item2 - 1 >= 0 && maze[node.Item1, node.Item2 - 1] == 1 && solution[node.Item1, node.Item2 - 1] == 0)
                {
                    queue.Enqueue(new Tuple<int, int, int>(node.Item1, node.Item2 - 1, path));
                }

                if (node.Item1 + 1 <= maze.GetUpperBound(0) && maze[node.Item1 + 1, node.Item2] == 1 && solution[node.Item1 + 1, node.Item2] == 0)
                {
                    queue.Enqueue(new Tuple<int, int, int>(node.Item1 + 1, node.Item2, path));
                }

                if (node.Item2 + 1 <= maze.GetUpperBound(0) && maze[node.Item1, node.Item2 + 1] == 1 && solution[node.Item1, node.Item2 + 1] == 0)
                {
                    queue.Enqueue(new Tuple<int, int, int>(node.Item1, node.Item2 + 1, path));
                }
            }

            return 0;
        }
    }
}