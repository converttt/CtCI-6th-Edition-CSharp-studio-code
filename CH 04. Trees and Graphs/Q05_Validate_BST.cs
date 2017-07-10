using System;
using System.Collections.Generic;
using lib_ctci;

namespace CH_04._Trees_and_Graphs
{
    public class Q05_Validate_BST
    {
        public bool Validate(CtciTreeNode<int> head)
        {
            return Validate(head, null, null);
        }

        protected bool Validate(CtciTreeNode<int> current, int? min, int? max)
        {
            if ((min != null && current.Value <= min) || (max != null && current.Value > max))
            {
                return false;
            }

            if (current.Left != null && Validate(current.Left, min, current.Value) == false)
            {
                return false;
            }

            if (current.Right != null && Validate(current.Right, current.Value, max) == false)
            {
                return false;
            }

            return true;
        }
    }
}