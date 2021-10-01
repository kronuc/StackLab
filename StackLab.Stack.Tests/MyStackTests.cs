using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace StackLab.Stack.Tests
{
    [TestFixture]
    public class MyStackTests
    {
        [Test]
        [TestCase(new int[] {})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public void Push_PushInStack_StackCountIncreacedBy1(int[] items)
        {
            MyStack<int> stack = new MyStack<int>(items);
            int numberForPushing = 5;
            int currentCount = stack.Count;
            int expected = currentCount + 1;
            
            
            stack.Push(numberForPushing);
            int result = stack.Count;

            Assert.AreEqual(expected, result, message: "stack dosn`t change his count when new element was pushed into empty stack");
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        public void Push_PushInStackWithCountAndCarpasityEqual_StackCarpasityIncreasedBy1(int[] items)
        {
            MyStack<int> stack = new MyStack<int>(items);
            int numberForPushing = 5;
            int currentCarpasity = stack.Carpasity;
            int expected = currentCarpasity + 1;


            stack.Push(numberForPushing);
            int result = stack.Carpasity;

            Assert.AreEqual(expected, result, message: "Stack doesn`t change his carpasity after pushing new element");
        }


        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        public void Push_PushInStackWithCount1andCarpasity2_2StackCarpasity(int[] items)
        {
            MyStack<int> stack = new MyStack<int>(items);
            stack.Push(1);
            stack.Push(1);
            stack.Pop();
            stack.Pop();
            int numberForPushing = 5;
            int expected = stack.Carpasity;

            stack.Push(numberForPushing);

            int result = stack.Carpasity;

            Assert.AreEqual(expected, result, message: "Stack doesn`change his carpasity after pushing new element into stack while in stack count < carpasity");
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        public void Push_Push5InStack_5LastItem(int [] items)
        {
            MyStack<int> stack = new MyStack<int>(items);
            int numberForPushing = 5;
            int expected = numberForPushing;

            stack.Push(numberForPushing);

            List<int> stackItems = new List<int>();
            foreach (int item in stack)
                stackItems.Add(item);
            int result = stackItems[0];

            Assert.AreEqual(expected, result, message: "pushed elemend aren`t become the laast element of stack");
        }

    }
}
