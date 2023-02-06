namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> last;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item);

            if (Count == 0)
            {
                head = newNode;
                last = newNode;
                Count++;
                return;
            }
            head.Previous = newNode;
            newNode.Next = head;
            head = newNode;
            Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item);

            if (Count == 0)
            {
                head = newNode;
                last = newNode;
            }
            last.Next = newNode;
            newNode.Previous = last;
            last = newNode;
            Count++;
        }

        public T GetFirst()
        {
            CheckIfEmpty();
            return head.Value;
        }

        private void CheckIfEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        public T GetLast()
        {
            CheckIfEmpty();
            return last.Value;
        }

        public T RemoveFirst()
        {
            CheckIfEmpty();

            var oldHead = head;

            oldHead.Previous = null;
            head = head.Next;
            Count--;

            return oldHead.Value;
        }

        public T RemoveLast()
        {
            CheckIfEmpty();

            var oldLast = last;

            last = last?.Previous;
            if (last!=null)
            {
                last.Next = null;
            }
            Count--;

            return oldLast.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = head;

            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}