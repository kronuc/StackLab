using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackLab.Stack
{
    public class MyStack<T> : IEnumerable<T>,IReadOnlyCollection<T>, ICollection, IEnumerable
    {
        private StackNode<T> _stackHead;
        public int Count { get; private set; }
        public int Carpasity { get; private set; }
        public bool IsSynchronized { get; set; }
        public object SyncRoot { get; set; }
        public event EventHandler<StackChagedEventArgs<T>> StackChangedEvent;


        public MyStack(Array array)
        {
            foreach (T item in array)
            {
                this.Push(item, false);
            }
        }

        public MyStack()
        {
        }

        public void CopyTo(Array array, int index)
        {
            StackNode<T> current = _stackHead;
            for( int i = 0; i < index || i < Count; i++)
            {
                array.SetValue(current.Value, i);
                current = current.Next;
            }
        }

        public Array ToArray()
        {
            T[] array = new T[Count];
            CopyTo(array, Count);
            return array;
        }

        public void Push(T value)
        {
            Push(value, true);
        }
        private void Push(T value, bool doNotification)
        {
            if (_stackHead == null || _stackHead.Previous == null)
            {
                _stackHead = new StackNode<T>(value, _stackHead);
                Carpasity++;
            }
            else
            {
                _stackHead = _stackHead.Previous;
                _stackHead.Value = value;
            }
            Count++;
            if (doNotification)
            {
                StackChagedEventArgs<T> eventArgs = new StackChagedEventArgs<T>()
                {
                    Value = value,
                    StackAction = StackActions.Push
                };
                StackChangedEvent?.Invoke(this, eventArgs);
            }
        }


        public T Pop()
        {
            return Pop(true);
        }
        private T Pop(bool doNotification)
        {
            T result = default;
            if (Count != 0)
            {
                result = _stackHead.Value;
                _stackHead.Value = default;
                _stackHead = _stackHead.Next;
                Count--;
            }
            else
            {
                throw new StackNoElementException("can`t pop element from empty stack");
            }
            if (doNotification)
            {
                StackChagedEventArgs<T> eventArgs = new StackChagedEventArgs<T>()
                {
                    Value = result,
                    StackAction = StackActions.Pop
                };
                StackChangedEvent?.Invoke(this, eventArgs);
            }
            return result;
        }

        public void Clear()
        {
            _stackHead = null;
            StackChagedEventArgs<T> eventArgs = new StackChagedEventArgs<T>()
            {
                StackAction = StackActions.Clear
            };
            Count = 0;
            StackChangedEvent?.Invoke(this, eventArgs);
        }

        public T Peek()
        {
            return Peek(true);
        }
        private T Peek(bool doNotification)
        {
            T result = default;
            if (Count != 0)
            {
                result = _stackHead.Value;
            }
            else
            {
                throw new StackNoElementException("can`t peek element from empty stack");
            }
            if (doNotification)
            {
                StackChagedEventArgs<T> eventArgs = new StackChagedEventArgs<T>()
                {
                    Value = result,
                    StackAction = StackActions.Peek
                };
                StackChangedEvent?.Invoke(this, eventArgs);
            }
            return _stackHead.Value;
        }

        public void TrimExcess()
        {
            if (Count/Carpasity < 0.9)
            {
                Carpasity = Count;
                _stackHead.Previous = null;
            }
            StackChagedEventArgs<T> eventArgs = new StackChagedEventArgs<T>()
            {
                StackAction = StackActions.TrimExcess
            };
            StackChangedEvent?.Invoke(this, eventArgs);

        }

        public bool TryPeek(out T result)
        {
            return TryPeek(out result, true);
        }

        private bool TryPeek(out T result, bool doNotification)
        {
            T resultValue = default;
            if (Count != 0)
            {
                resultValue = _stackHead.Value;
            }
            if (doNotification)
            {
                StackChagedEventArgs<T> eventArgs = new StackChagedEventArgs<T>()
                {
                    Value = resultValue,
                    StackAction = StackActions.TryPeek
                };
                StackChangedEvent?.Invoke(this, eventArgs);
            }
            result = resultValue;
            return (Count != 0);
        }

        public bool TryPop(out T result)
        {
            return TryPop(out result, true);
        }

        private bool TryPop(out T result, bool doNotification)
        {
            T resultValue = default;
            bool isSuccess;
            if (Count != 0)
            {
                resultValue = _stackHead.Value;
                _stackHead.Value = default;
                _stackHead = _stackHead.Next;
                Count--;
                isSuccess = true;
            }
            else
            {
                resultValue = default;
                isSuccess = false;
            }

            if (doNotification)
            {
                StackChagedEventArgs<T> eventArgs = new StackChagedEventArgs<T>()
                {
                    Value = resultValue,
                    StackAction = StackActions.TryPop
                };
                StackChangedEvent?.Invoke(this, eventArgs);
            }

            result = resultValue;
            return isSuccess;
        }

        public IEnumerator GetEnumerator()
        {
            StackNode<T> current = _stackHead;
            T value = default;
            for (int i = 0; i < Count; i++)
            {
                value = current.Value;
                current = current.Next;
                yield return value;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            StackNode<T> current = _stackHead;
            T value = default;
            for (int i = 0; i < Count; i++)
            {
                value = current.Value;
                current = current.Next;
                yield return value;
            }
        }
    }
}
