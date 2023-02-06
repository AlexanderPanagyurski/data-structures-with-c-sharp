namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] array;
        private int startIndex;
        private int lastIndex;

        public CircularQueue(int capacity = 4)
        {
            array = new T[capacity];
        }

        public int Count { get; private set; }

        public T Dequeue()
        {
            CheckIfEmpty();
            var oldHead = array[startIndex];
            array[startIndex] = default(T);
            startIndex = (startIndex + 1) % array.Length;
            Count--;
            return oldHead;
        }

        private void CheckIfEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        public void Enqueue(T item)
        {
            if (Count == array.Length)
            {
                Grow();
                startIndex = 0;
                lastIndex = Count;
            }
            array[lastIndex] = item;
            lastIndex = (lastIndex + 1) % array.Length;
            Count++;
        }

        private void Grow()
        {
            array = GrowArray();
        }

        private T[] GrowArray()
        {
            T[] newArray = new T[array.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                newArray[i] = array[(startIndex + i) % array.Length];
            }
            return newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[(startIndex + i) % array.Length];
            }
        }

        public T Peek()
        {
            CheckIfEmpty();
            return array[startIndex];
        }

        public T[] ToArray()
        {
            T[] arrayCopy = new T[Count];

            for (int i = 0; i < arrayCopy.Length; i++)
            {
                arrayCopy[i] = array[(startIndex + i) % array.Length];
            }
            return arrayCopy;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
