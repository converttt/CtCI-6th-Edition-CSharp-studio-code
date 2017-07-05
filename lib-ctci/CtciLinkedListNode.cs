using System;

namespace lib_ctci
{
    public class CtciLinkedListNode<T>
    {
        protected CtciLinkedListNode<T> next;
        protected T value;

        public CtciLinkedListNode(T value)
        {
            this.value = value;
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public CtciLinkedListNode<T> Next
        {
            get
            {
                return next;
            }
            set
            {
                this.next = value;
            }
        }
    }
}
