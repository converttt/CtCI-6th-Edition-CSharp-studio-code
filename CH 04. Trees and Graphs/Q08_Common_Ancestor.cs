using System;
using System.Collections.Generic;
using lib_ctci;

namespace CH_04._Trees_and_Graphs
{
    public class Q08_Common_Ancestor<T>
    {
        public CtciTreeNode<T> FindAncestor(CtciTreeNode<T> head, CtciTreeNode<T> nodeP, CtciTreeNode<T> nodeQ)
        {
            if (head == null || nodeP == null || nodeQ == null)
            {
                throw new Exception("Incorrect Data");
            }

            Q08_Result<T> result = FindRecursively(head, nodeP, nodeQ);

            return result.Node;
        }

        protected Q08_Result<T> FindRecursively(CtciTreeNode<T> head, CtciTreeNode<T> nodeP, CtciTreeNode<T> nodeQ)
        {
            if (head == null)
            {
                return new Q08_Result<T>(null, false);
            }

            if (head == nodeP && head == nodeQ)
            {
                return new Q08_Result<T>(head, true);
            }

            Q08_Result<T> resultLeft = FindRecursively(head.Left, nodeP, nodeQ);
            if (resultLeft.IsAncestor)
            {
                return resultLeft;
            }

            Q08_Result<T> resultRight = FindRecursively(head.Right, nodeP, nodeQ);
            if (resultRight.IsAncestor)
            {
                return resultRight;
            }

            if (resultLeft.Node != null && resultRight.Node != null)
            {
                return new Q08_Result<T>(head, true);
            } 
            else if (head == nodeP || head == nodeQ)
            {
                bool isAncestor = resultLeft.Node != null || resultRight.Node != null;
                return new Q08_Result<T>(head, isAncestor);
            } 
            else
            {
                return new Q08_Result<T>(resultLeft.Node != null ? resultLeft.Node : resultRight.Node, false);
            }
        }
    }

    public class Q08_Result<T>
    {
        protected CtciTreeNode<T> node;
        protected bool isAncestor;

        public Q08_Result(CtciTreeNode<T> node, bool isAncestor)
        {
            this.node = node;
            this.isAncestor = isAncestor;
        }

        public CtciTreeNode<T> Node
        {
            get
            {
                return node;
            }
        }

        public bool IsAncestor
        {
            get
            {
                return isAncestor;
            }
        }
    }
}