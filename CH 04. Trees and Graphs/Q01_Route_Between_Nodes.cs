using System;
using System.Collections.Generic;
using lib_ctci;

namespace CH_04._Trees_and_Graphs
{
    public class Q01_Route_Between_Nodes
    {
        public bool FindRoute(int[,] graph, int node1, int node2)
        {
            if (graph.GetLength(0) <= 0 || graph.GetLength(0) != graph.GetLength(1))
            {
                throw new Exception("Incorrect Data");
            }

            if (node1 > graph.GetLength(0) || node2 > graph.GetLength(0))
            {
                throw new Exception("Incorrect Data");
            }

            if (node1 == node2)
            {
                return true;
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(node1);

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                for (int connection = 0; connection <= graph.GetUpperBound(1); connection++)
                {
                    if (graph[node, connection] == 1 && connection == node2)
                    {
                        return true;
                    }
                    else if (graph[node, connection] == 1)
                    {
                        queue.Enqueue(connection);
                    }
                }
            }

            return false;
        }

        public bool FindRoute2(CtciTreeNode<int> node1, CtciTreeNode<int> node2)
        {
            if (node1 == node2)
            {
                return true;
            }

            Queue<CtciTreeNode<int>> queue = new Queue<CtciTreeNode<int>>();
            queue.Enqueue(node1);
            while (queue.Count > 0)
            {
                CtciTreeNode<int> node = queue.Dequeue();
                foreach (CtciTreeNode<int> child in node.Children)
                {
                    if (child == node2)
                    {
                        return true;
                    }

                    queue.Enqueue(child);
                }
            }

            return false;
        }
    }
}
