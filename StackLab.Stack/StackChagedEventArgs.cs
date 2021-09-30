using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackLab.Stack
{
    public class StackChagedEventArgs<T>
    {
        public StackActions StackAction { get; set; }
        public T Value { get; set; }
    }
}
