namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currentTop=_top;
            while (currentTop != null)
            {
                if (currentTop.Value.Equals(item))
                {
                    return true;
                }
                currentTop = currentTop.Next;
            }
            return false;
        }

        public T Peek()
        {
            CheckIfEmpty();
            return _top.Value;
        }

        public T Pop()
        {
            CheckIfEmpty();
            var oldTop = _top;
            _top = _top.Next;
            Count--;
            return oldTop.Value;
        }

        public void Push(T item)
        {
            var newTop = new Node<T>(item);

            newTop.Next = _top;
            _top = newTop;
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentTop = _top;
            while (currentTop?.Next != null)
            {
                yield return currentTop.Value;
                currentTop = currentTop.Next;
            }
        }


        private void CheckIfEmpty()
        {
            if (_top is null)
            {
                throw new InvalidOperationException();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}