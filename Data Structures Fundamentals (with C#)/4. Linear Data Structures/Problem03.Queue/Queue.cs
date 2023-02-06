namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> _last;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            while (_head != null)
            {
                if (_head.Value.Equals(item))
                {
                    return true;
                }
                _head = _head.Next;
            }
            return false;
        }

        public T Dequeue()
        {
            CheckIfEmpty();
            var oldHead = _head;
            _head=_head.Next;
            Count--;
            return oldHead.Value;
        }

        public void Enqueue(T item)
        {
            var newLast = new Node<T>(item);
            if (_head == null)
            {
                _head = newLast;
                _last = newLast;
            }
            _last.Next = newLast;
            _last = newLast;
            Count++;
        }

        public T Peek()
        {
            CheckIfEmpty();
            return _head.Value;
        }


        public IEnumerator<T> GetEnumerator()
        {
            while (_head != null)
            {
                yield return _head.Value;
                _head = _head.Next;
            }
        }
        private void CheckIfEmpty()
        {
            if (_head == null || _last == null)
            {
                throw new InvalidOperationException();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}