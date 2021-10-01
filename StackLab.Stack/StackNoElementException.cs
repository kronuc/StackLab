using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackLab.Stack
{
    public class StackNoElementException : Exception
    {
        public StackNoElementException(string message) : base(message)
        {
        }
    }
}
