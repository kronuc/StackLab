using StackLab.Stack;
using System;

namespace StackLab
{
    class Program
    {
        static void Main(string[] args)
        {
            ConstructorWithArrayDemonstration();
            PopDemonstration();
            TryPopDemonstration();
            PushDemonstration();
            PeekDemonstration();
            TryPeekDemonstration();
            TrimExcessDemonstration();
            ClearDemonstration();
            StackEventsDemonstration();
            PopFromEmptyStackDemonstration();
            PeekFromEmptyStackDemonstration();
        }

        static void ConstructorWithArrayDemonstration() 
        {
            Console.WriteLine("\nDemonstration of creating stack from array items\n");


            Console.WriteLine("\n1) Create stack from array items\n");
            string[] items = new string[10];
            FillArray(items);
            MyStack<string> stack = new MyStack<string>(items);
            Console.WriteLine("\n2) Showing stack items with foreach cycle\n");

            foreach (string item in stack)
                Console.WriteLine(item);
            Console.WriteLine($"\ncount of items in stack: {stack.Count}");
        }

        static void PushDemonstration()
        {
            Console.WriteLine("\n Push demonstration\n");

            Console.WriteLine("\n1) Create stack with start data");
            MyStack<string> stack = new MyStack<string>();
            FillStack(stack);
            foreach(string item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"\ncount of items in stack: {stack.Count}");

            Console.WriteLine("\n2) Push string \"test\" in stack");
            stack.Push("test");

            Console.WriteLine("\n2) Showing stack items after pushing with foreach cycle\n");
            foreach (string item in stack)
                Console.WriteLine(item);
            Console.WriteLine($"\ncount of items in stack: {stack.Count}");
        }

        static void PopDemonstration()
        {

            Console.WriteLine("\n Pop demonstration\n");

            Console.WriteLine("\n1) Create stack with start data");
            MyStack<string> stack = new MyStack<string>();
            FillStack(stack);
            foreach (string item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"\ncount of items in stack: {stack.Count}");

            Console.WriteLine("\n2) Execute \"pop\" method on ");
            string popedItem =  stack.Pop();

            Console.WriteLine($"\n item value: {popedItem}");

            Console.WriteLine("\n2) Showing stack items after executing method \"pop\" with foreach cycle\n");
            foreach (string item in stack)
                Console.WriteLine(item);
            Console.WriteLine($"\ncount of items in stack: {stack.Count}");

        }
        
        static void TryPopDemonstration()
        {
            Console.WriteLine("\n TryPop demonstration\n");

            Console.WriteLine("\n1) Create stack with start data");
            MyStack<string> stack = new MyStack<string>();
            FillStack(stack);
            foreach (string item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"\ncount of items in stack: {stack.Count}");

            Console.WriteLine("\n create variable");
            
            string popedItem = "";
            
            Console.WriteLine("\n2) Execute \"TryPop\" method on atack");
            
            if (stack.TryPop(out popedItem)) Console.WriteLine("value put into variable");

            Console.WriteLine($"\n variable value: {popedItem}");

            Console.WriteLine("\n2) Showing stack items after executing method \"pop\" with foreach cycle\n");
            foreach (string item in stack)
                Console.WriteLine(item);
            Console.WriteLine($"\ncount of items in stack: {stack.Count}");
        }


        static void PeekDemonstration()
        {

            Console.WriteLine("\n Peek demonstration\n");

            Console.WriteLine("\n1) Create stack with start data");
            MyStack<string> stack = new MyStack<string>();
            FillStack(stack);
            foreach (string item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"\n count of items in stack: {stack.Count}");

            Console.WriteLine("\n2) Execute \"peek\" method on stack");
            string peekedItem = stack.Peek();

            Console.WriteLine($"\n item value: {peekedItem}");

            Console.WriteLine("\n2) Showing stack items after executing method \"peek\" with foreach cycle\n");
            foreach (string item in stack)
                Console.WriteLine(item);
            Console.WriteLine($"\ncount of items in stack: {stack.Count}");

        }
        
        static void TryPeekDemonstration()
        {
            Console.WriteLine("\n Peek demonstration\n");

            Console.WriteLine("\n1) Create stack with start data");
            MyStack<string> stack = new MyStack<string>();
            FillStack(stack);
            foreach (string item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"\n count of items in stack: {stack.Count}");

            Console.WriteLine("\n Create variable");
            string peekedItem = "";

            Console.WriteLine("\n2) Execute \"TryPeek\" method on stack");
            if (stack.TryPeek(out peekedItem)) Console.WriteLine("value put in variable");

            Console.WriteLine($"\n item value: {peekedItem}");

            Console.WriteLine("\n2) Showing stack items after executing method \"peek\" with foreach cycle\n");
            foreach (string item in stack)
                Console.WriteLine(item);
            Console.WriteLine($"\ncount of items in stack: {stack.Count}");
        }

        static void TrimExcessDemonstration()
        {
            Console.WriteLine("\n Trim Excess demonstration\n");

            Console.WriteLine("\n1) Create stack with start data");
            MyStack<string> stack = new MyStack<string>();
            FillStack(stack);
            Console.WriteLine($"\n stack carpasity: {stack.Carpasity}");

            Console.WriteLine($"\n2) Showing stack Carpasity after executing method \"TrimExcess\"{stack.Carpasity}");
            Console.WriteLine($"\ncount of items in stack: {stack.Count}");
        }

        static void ClearDemonstration()
        {
            Console.WriteLine("\n Clear demonstration\n");

            Console.WriteLine("\n1) Create stack with start data");
            MyStack<string> stack = new MyStack<string>();
            FillStack(stack);
            foreach (string item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"\n count of items in stack: {stack.Count}");

            Console.WriteLine("\n2) Execute \"Clear\" method on stack");
            stack.Clear();
            Console.WriteLine($"\ncount of items in stack: {stack.Count}");
        }

        static void StackEventsDemonstration()
        {
            Console.WriteLine("\n Stack event demonstration\n");

            Console.WriteLine("\n1) Create stack with start data");
            MyStack<string> stack = new MyStack<string>();
            FillStack(stack);
            foreach (string item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"\n count of items in stack: {stack.Count}");

            Console.WriteLine("\n2) put event handler on stack");
            stack.StackChangedEvent += StackEventHandler;

            Console.WriteLine("\n3) execute methods");
            stack.Push("something");
            stack.Pop();
            stack.Peek();
            string a;
            stack.TryPeek(out a);
            stack.TryPop(out a);
            stack.TrimExcess();
            stack.Clear();
            
        }

        static void PopFromEmptyStackDemonstration()
        {
            Console.WriteLine("\n Pop from empty stack demonstration\n");

            Console.WriteLine("\n1) Create stack withoutdata");
            MyStack<string> stack = new MyStack<string>();
            Console.WriteLine($"\ncount of items in stack: {stack.Count}");

            Console.WriteLine("\n2) Execute \"pop\" method on ");
            try
            {
                string popedItem = stack.Pop();
            }
            catch (StackNoElementException e)
            {
                Console.WriteLine("exception message: " + e.Message);
            }
            
        }

        static void PeekFromEmptyStackDemonstration()
        {
            Console.WriteLine("\n Peek on empty stack demonstration\n");

            Console.WriteLine("\n1) Create stack with start data");
            MyStack<string> stack = new MyStack<string>();
            
            Console.WriteLine($"\n count of items in stack: {stack.Count}");

            Console.WriteLine("\n2) Execute \"peek\" method on stack");
            try
            {
                string peekedItem = stack.Peek();
            }
            catch (StackNoElementException e)
            {
                Console.WriteLine("exception message: " + e.Message);
            }

           
        }

        static void StackEventHandler(object sender, StackChagedEventArgs<string> args)
        {
            switch (args.StackAction)
            {
                case StackActions.Clear:
                    Console.WriteLine("clear occurred in stack");
                    break;
                case StackActions.Peek:
                    Console.WriteLine("peek occurred in stack");
                    break;
                case StackActions.Pop:
                    Console.WriteLine("pop occurred in stack");
                    break;
                case StackActions.TryPeek:
                    Console.WriteLine("try peek occurred in stack");
                    break;
                case StackActions.TryPop:
                    Console.WriteLine("try pop occurred in stack");
                    break;
                case StackActions.Push:
                    Console.WriteLine("push occurred in stack");
                    break;
                case StackActions.TrimExcess:
                    Console.WriteLine("trim excess occurred in stack");
                    break;
                default:
                    Console.WriteLine("something occurred in stack");
                    break;
            }
        }
        
        static void FillStack(MyStack<string> stack)
        {
            for (int i = 0; i < 10; i++)
                stack.Push(i.ToString());
        }

        static void FillArray(string[] stack)
        {
            for (int i = 0; i < 10; i++)
                stack[i] = i.ToString();
        }

    }
}
