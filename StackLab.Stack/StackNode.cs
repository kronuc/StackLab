using System;

namespace StackLab.Stack
{
    internal class StackNode<T>
    {
        internal T Value { get; set; }
        internal StackNode<T> Next { get; set; }
        internal StackNode<T> Previous { get; set; }
        public StackNode(T value, StackNode<T> stackHead)
        {
            this.Value = value;
            this.Next = stackHead;
            if( Next != null)
                Next.Previous = this;
        }
    }
}
