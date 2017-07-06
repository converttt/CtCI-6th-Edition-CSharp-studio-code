using System;
using System.Collections.Generic;

namespace lib_ctci
{
    public class CtciTreeNode<T>
    {
        protected List<CtciTreeNode<T>> children = new List<CtciTreeNode<T>>();
        protected T value;
        protected CtciTreeNode<T> parent;

        public CtciTreeNode(T value)
        {
            this.value = value;
        }

        public CtciTreeNode<T> Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        public List<CtciTreeNode<T>> Children
        {
            get
            {
                return children;
            }
            set
            {
                children = value;
            }
        }

        public CtciTreeNode<T> Left
        {
            get
            {
                return children[0];
            }
            set
            {
                children[0] = value;
            }
        }

        public CtciTreeNode<T> Right
        {
            get
            {
                return children[1];
            }
            set
            {
                children[1] = value;
            }
        }
    }
}