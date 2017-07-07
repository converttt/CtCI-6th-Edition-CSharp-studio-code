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

        static public CtciTreeNode<T> CtciBinaryTreeNode(T value)
        {
            CtciTreeNode<T> node = new CtciTreeNode<T>(value);
            node.Children.Add(null);
            node.Children.Add(null);
            return node;
        }

        public T Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
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
                if (children.Count <= 0)
                {
                    return null;
                }

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
                if (children.Count < 2)
                {
                    return null;
                }

                return children[1];
            }
            set
            {
                children[1] = value;
            }
        }
    }
}