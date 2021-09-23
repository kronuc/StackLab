using System;

namespace StackLab.Stack
{
    internal class StackNode<T>
    {
        internal T Value { get; set; }
        internal StackNode<T> Next { get; set; } 
    }
}
