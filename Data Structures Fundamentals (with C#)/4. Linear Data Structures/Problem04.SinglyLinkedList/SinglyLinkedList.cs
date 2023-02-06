namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _last;


        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newhead = new Node<T>(item);
            if (_head == null)
            {
                _last = newhead;
            }
            newhead.Next = _head;
            _head = newhead;
            Count++;
        }

        public void AddLast(T item)
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

        public T GetFirst()
        {
            CheckIfEmpty();
            return _head.Value;
        }

        public T GetLast()
        {
            CheckIfEmpty();
            return _last.Value;
        }

        public T RemoveFirst()
        {
            CheckIfEmpty();
            var oldHead = _head;
            _head = _head.Next;
            Count--;
            return oldHead.Value;
        }

        private void CheckIfEmpty()
        {
            if (_head == null || _last == null)
            {
                throw new InvalidOperationException();
            }
        }

        public T RemoveLast()
        {
            CheckIfEmpty();
            var currentHead = _head;
            Node<T> oldLast = _last;
            while (currentHead.Next != null)
            {
                if (currentHead.Next.Next == null)
                {
                    _last = currentHead;
                    _last.Next = null;
                    break;
                }
                currentHead = currentHead.Next;
            }
            Count--;
            return oldLast.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentHead = _head;
            while (currentHead != null)
            {
                yield return currentHead.Value;
                currentHead = currentHead.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}