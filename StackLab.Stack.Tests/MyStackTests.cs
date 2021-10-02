using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace StackLab.Stack.Tests
{
    [TestFixture]
    public class MyStackTests
    {

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 3, 4, 5 })]
        public void ConstructorWithArray_CreateStackWithInputedArray_StackHasTheSameCountAsArray(int[] items)
        {
            int expected = items.Length;

            MyStack<int> stack = new MyStack<int>(items);
            int result = stack.Count;

            Assert.AreEqual(expected, result, message: "count of elements in array and stack based on it are no equal");

        }

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
        public void Push_PushInStackWithCountLessThatCarpasity_StackCarpasityDidntChange(int[] items)
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

        [Test]
        public void Pop_PopOneElementFromStack_CountDecreasedBy1()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3, 4 });
            int expected = stack.Count - 1;

            stack.Pop();
            int result = stack.Count;

            Assert.AreEqual(expected, result, message: "count of elements in stack changed uncorrectly after executing pop method");
        }

        [Test]
        public void Pop_PopOneElementFromStack_CarpasityDidntChange()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3, 4 });
            int expected = stack.Carpasity;

            stack.Pop();
            int result = stack.Carpasity;

            Assert.AreEqual(expected, result, message: "carpasity of stack changed after executing pop method");
        }

        [Test]
        public void Pop_PopOneElementFromStack_LastElementWasRemovedFromStack()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3, 4 });
            int[] temporaryArray = new int[1];
            stack.CopyTo(temporaryArray, 1);
            int unexpected = temporaryArray[0];

            stack.Pop();
            int[] secondTemporaryArray = new int[1];
            stack.CopyTo(secondTemporaryArray, 1);
            int result = secondTemporaryArray[0];

            Assert.AreNotEqual(unexpected, result, message: "last element didn`t remooved from stack after executing method Pop");
        }

        [Test]
        public void Pop_PopOneElementFromStack_LastElementEqualToResultOfPop()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3, 4 });
            int[] temporaryArray = new int[1];
            stack.CopyTo(temporaryArray, 1);
            int expected = temporaryArray[0];


            int result = stack.Pop(); ;

            Assert.AreEqual(expected, result, message: "last element didn`t equil to result of executing of pop operation");
        }

        [Test]
        public void Pop_PopElementFromEmptyStack_StackNoElementException()
        {
            MyStack<int> stack = new MyStack<int>();

            Assert.Throws<StackNoElementException>(() => stack.Pop(), message: "stack didn`t throw exception after executing pop on empty stack" );
        }

        [Test]
        public void Peek_PekOneElementFromStack_CountDidntChange()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3, 4 });
            int expected = stack.Count;

            stack.Peek();
            int result = stack.Count;

            Assert.AreEqual(expected, result, message: "count of elements in stack changed after executing peek method");
        }

        [Test]
        public void Peek_PeekOneElementFromStack_CarpasityDidntChange()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3, 4 });
            int expected = stack.Carpasity;

            stack.Peek();
            int result = stack.Carpasity;

            Assert.AreEqual(expected, result, message: "carpasity of stack changed after executing peek method");
        }
        
        [Test]
        public void Peek_PeekOneElementFromStack_LastElementWasntRemovedFromStack()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3, 4 });
            int[] temporaryArray = new int[1];
            stack.CopyTo(temporaryArray, 1);
            int expected = temporaryArray[0];

            stack.Peek();
            int[] secondTemporaryArray = new int[1];
            stack.CopyTo(secondTemporaryArray, 1);
            int result = secondTemporaryArray[0];

            Assert.AreEqual(expected, result, message: "last element remooved from stack");
        }

        [Test]
        public void Peek_PeekOneElementFromStack_LastElementEqualToResultOfPeek()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3, 4 });
            int[] temporaryArray = new int[1];
            stack.CopyTo(temporaryArray, 1);
            int expected = temporaryArray[0];


            int result = stack.Peek(); 

            Assert.AreEqual(expected, result, message: "last element didn`t equil to result of executing of peek operation");
        }

        [Test]
        public void Peek_PeekElementFromEmptyStack_StackNoElementException()
        {
            MyStack<int> stack = new MyStack<int>();

            Assert.Throws<StackNoElementException>(() => stack.Peek(), message: "stack didn`t throw exception after executing peek on empty stack");
        }

        [Test]
        public void Clear_ExecuteClearOnStack_CountBecome0()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3 });
            int expected = 0;

            stack.Clear();
            int result = stack.Count;

            Assert.AreEqual(expected, result, message: "count of elements in stack doesn`t equal 0 after executing clear method");
        }

        [Test]
        public void Clear_ExecuteClearOnStack_CarpasityBecome0()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3 });
            int expected = 0;

            stack.Clear();
            int result = stack.Carpasity;

            Assert.AreEqual(expected, result, message: "carpasity of stack doesn`t equal 0 after executing clear method");
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1,2,3,4})]
        public void TrimExcess_ExecuteTrimExcessOnStack_CountDidntChange(int [] items)
        {
            MyStack<int> stack = new MyStack<int>(items);
            int expected = stack.Count;

            stack.TrimExcess();
            int resutl = stack.Count;

            Assert.AreEqual(expected, resutl, message: "count changed after executing TrimExcess");
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        public void TrimExcess_ExecuteTrimExcessOnStackWhereCarpasityEqualToCount_CarpasityDidntChange(int[] items)
        {
            MyStack<int> stack = new MyStack<int>(items);
            int expected = stack.Carpasity;

            stack.TrimExcess();
            int resutl = stack.Carpasity;

            Assert.AreEqual(expected, resutl, message: "carpasity changed after executing TrimExcess on stack in which count equil to carpasity");
        }
        
        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        public void TrimExcess_ExecuteTrimExcessOnStackWhereCountSmallerThatCarpasity_CarpasityChanged(int[] items)
        {
            MyStack<int> stack = new MyStack<int>(items);
            stack.Push(1);
            int expected = stack.Count;

            stack.TrimExcess();
            int resutl = stack.Carpasity;

            Assert.AreEqual(expected, resutl, message: "carpasity didn`t change after executing TrimExcess on stack in which count smaller carpasity");
        }

        [Test]
        public void TryPop_PopOneElementFromStack_CountDecreasedBy1()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3, 4 });
            int expected = stack.Count - 1;

            int someVar;
            stack.TryPop(out someVar);
            int result = stack.Count;

            Assert.AreEqual(expected, result, message: "count of elements in stack changed uncorrectly after executing TryPop method");
        }

        [Test]
        public void TryPop_PopOneElementFromStack_CarpasityDidntChange()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3, 4 });
            int expected = stack.Carpasity;

            int someVar;
            stack.TryPop(out someVar);
            int result = stack.Carpasity;

            Assert.AreEqual(expected, result, message: "carpasity of stack changed after executing TryPop method");
        }

        [Test]
        public void TryPop_PopOneElementFromStack_LastElementWasRemovedFromStack()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3, 4 });
            int[] temporaryArray = new int[1];
            stack.CopyTo(temporaryArray, 1);
            int unexpected = temporaryArray[0];

            int someVar;
            stack.TryPop(out someVar);
            int[] secondTemporaryArray = new int[1];
            stack.CopyTo(secondTemporaryArray, 1);
            int result = secondTemporaryArray[0];

            Assert.AreNotEqual(unexpected, result, message: "last element wasn`t remooved from stack after executing method TryPop");
        }

        [Test]
        public void TryPop_PopOneElementFromStack_LastElementEqualToResultOfPop()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3, 4 });
            int[] temporaryArray = new int[1];
            stack.CopyTo(temporaryArray, 1);
            int expected = temporaryArray[0];


            int result;
            stack.TryPop(out result); ;

            Assert.AreEqual(expected, result, message: "last element didn`t equil to result of executing of TryPop method");
        }

        [Test]
        public void TryPop_PopElementFromEmptyStack_AvoidStackNoElementException()
        {
            MyStack<int> stack = new MyStack<int>();
            int someVar;


            Assert.DoesNotThrow(() => stack.TryPop(out someVar), message: "stack throwed exception after executing TryPop on empty stack");
        }

        [Test]
        public void TryPop_PopElementFromEmptyStack_MethodReturnFalse()
        {
            MyStack<int> stack = new MyStack<int>();
            bool expected = false;
            
            int someVar;
            bool result = stack.TryPop(out someVar);


            Assert.AreEqual(expected, result, message: "TryPop return true after pop atempt of pop element from empty stack");
        }

        [Test]
        public void TryPop_PopElementFromStack_MethodReturnTrue()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3 });
            bool expected = true;

            int someVar;
            bool result = stack.TryPop(out someVar);


            Assert.AreEqual(expected, result, message: "TryPop return false after atempt of pop element from stack that wasn`t wrong");
        }

        [Test]
        public void TryPeek_PeekOneElementFromStack_CountDidntChanged()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3, 4 });
            int expected = stack.Count;

            int someVar;
            stack.TryPeek(out someVar);
            int result = stack.Count;

            Assert.AreEqual(expected, result, message: "count of elements in stack changed after executing TryPeek method");
        }

        [Test]
        public void TryPeek_PeekOneElementFromStack_CarpasityDidntChange()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3, 4 });
            int expected = stack.Carpasity;

            int someVar;
            stack.TryPeek(out someVar);
            int result = stack.Carpasity;

            Assert.AreEqual(expected, result, message: "carpasity of stack changed after executing TryPeek method");
        }

        [Test]
        public void TryPeek_PeekOneElementFromStack_LastElementWasntRemovedFromStack()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3, 4 });
            int[] temporaryArray = new int[1];
            stack.CopyTo(temporaryArray, 1);
            int expected = temporaryArray[0];

            int someVar;
            stack.TryPeek(out someVar);
            int[] secondTemporaryArray = new int[1];
            stack.CopyTo(secondTemporaryArray, 1);
            int result = secondTemporaryArray[0];

            Assert.AreEqual(expected, result, message: "last element was remooved from stack after executing method TryPeek");
        }

        [Test]
        public void TryPeek_PeekOneElementFromStack_LastElementEqualToResultOfPop()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3, 4 });
            int[] temporaryArray = new int[1];
            stack.CopyTo(temporaryArray, 1);
            int expected = temporaryArray[0];


            int result;
            stack.TryPeek(out result); 

            Assert.AreEqual(expected, result, message: "last element didn`t equil to result of executing of TryPeek method");
        }

        [Test]
        public void TryPeek_PeekElementFromEmptyStack_AvoidStackNoElementException()
        {
            MyStack<int> stack = new MyStack<int>();
            int someVar;


            Assert.DoesNotThrow(() => stack.TryPeek(out someVar), message: "stack throwed exception after executing TryPop on empty stack");
        }

        [Test]
        public void TryPeek_PeekElementFromEmptyStack_MethodReturnFalse()
        {
            MyStack<int> stack = new MyStack<int>();
            bool expected = false;

            int someVar;
            bool result = stack.TryPeek(out someVar);


            Assert.AreEqual(expected, result, message: "TryPeek return true after atempt of peeking element from empty stack");
        }

        [Test]
        public void TryPeek_PeekElementFromStack_MethodReturnTrue()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3 });
            bool expected = true;

            int someVar;
            bool result = stack.TryPeek(out someVar);


            Assert.AreEqual(expected, result, message: "TryPeek return false after atempt of peek element from stack that wasn`t wrong");
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        public void ToArray_CreateArrayBasedOnStack_LenghtOfArrayEqualStackCount(int[] items)
        {
            MyStack<int> stack = new MyStack<int>(items);
            int expected = stack.Count;

            int resutl = stack.ToArray().Length;

            Assert.AreEqual(expected, resutl, message: "lenght of array created by ToArray method are not equal to count of elements in stack");

        }

        [Test]
        [TestCase(new int[] { 1, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        public void CopyTo_CopyStackFullStackToArray_FirstelementOfResultArrayEqualToLastStackElement(int[] items)
        {
            MyStack<int> stack = new MyStack<int>(items);
            int expected = stack.Peek();
            int[] ourArray = new int[stack.Count];

            stack.CopyTo(ourArray, 1);
            int result = ourArray[0];

            Assert.AreEqual(expected, result, message: "element of array that were gotten from method CopyTo is wrong");
        }

        [Test]
        public void StackChangedEvent_ExecutePush_EventFiredWithEventArgPush()
        {
            MyStack<int> stack = new MyStack<int>();
            StackActions expected = StackActions.Push;
            StackActions result = StackActions.Clear;
            stack.StackChangedEvent += (o, e) => { result = e.StackAction; };

            stack.Push(5);

            Assert.AreEqual(expected, result, message: "event called with wrong parameter StackAction in eventArgs");
        }

        [Test]
        public void StackChangedEvent_ExecutePop_EventFiredWithEventArgPop()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 2, 3, 4 });
            StackActions expected = StackActions.Pop;
            StackActions result = StackActions.Clear;
            stack.StackChangedEvent += (o, e) => { result = e.StackAction; };

            stack.Pop();

            Assert.AreEqual(expected, result, message: "event called with wrong parameter StackAction in eventArgs");
        }
        
        [Test]
        public void StackChangedEvent_ExecutePeek_EventFiredWithEventArgPeek()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 2, 3 });
            StackActions expected = StackActions.Peek;
            StackActions result = StackActions.Clear;
            stack.StackChangedEvent += (o, e) => { result = e.StackAction; };

            stack.Peek();

            Assert.AreEqual(expected, result, message: "event called with wrong parameter StackAction in eventArgs");
        }

        [Test]
        public void StackChangedEvent_ExecuteClear_EventFiredWithEventArgClear()
        {
            MyStack<int> stack = new MyStack<int>();
            StackActions expected = StackActions.Clear;
            StackActions result = StackActions.Peek;
            stack.StackChangedEvent += (o, e) => { result = e.StackAction; };

            stack.Clear();

            Assert.AreEqual(expected, result, message: "event called with wrong parameter StackAction in eventArgs");
        }

        [Test]
        public void StackChangedEvent_ExecuteTryPeek_EventFiredWithEventArgTryPeek()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 3, 4, 4});
            StackActions expected = StackActions.TryPeek;
            StackActions result = StackActions.Clear;
            stack.StackChangedEvent += (o, e) => { result = e.StackAction; };

            int ourVar;
            stack.TryPeek(out ourVar);

            Assert.AreEqual(expected, result, message: "event called with wrong parameter StackAction in eventArgs");
        }

        [Test]
        public void StackChangedEvent_ExecuteTryPop_EventFiredWithEventArgTryPop()
        {
            MyStack<int> stack = new MyStack<int>(new int[] { 1, 4, 6 });
            StackActions expected = StackActions.TryPop;
            StackActions result = StackActions.Clear;
            stack.StackChangedEvent += (o, e) => { result = e.StackAction; };

            int ourVar;
            stack.TryPop(out ourVar);

            Assert.AreEqual(expected, result, message: "event called with wrong parameter StackAction in eventArgs");
        }

        [Test]
        public void StackChangedEvent_ExecuteTrimExcess_EventFiredWithEventArgTrimExcess()
        {
            MyStack<int> stack = new MyStack<int>();
            StackActions expected = StackActions.TrimExcess;
            StackActions result = StackActions.Clear;
            stack.StackChangedEvent += (o, e) => { result = e.StackAction; };

            stack.TrimExcess();

            Assert.AreEqual(expected, result, message: "event called with wrong parameter StackAction in eventArgs");
        }
    }
}
