namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List()
            : this(DEFAULT_CAPACITY)
        {
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            _items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                IsOutBounds(index);
                return _items[index];
            }
            set
            {
                IsOutBounds(index);
                _items[index] = value;
            }
        }


        public int Count { get; private set; }

        public void Add(T item)
        {
            GrowIfNecessary();
            _items[Count++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            IsOutBounds(index);
            for (int i = Count; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }
            _items[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            var isRemoved = false;
            if (this.Contains(item))
            {
                isRemoved = true;
                var index = IndexOf(item);
                RemoveAt(index);
            }
            return isRemoved;
        }

        public void RemoveAt(int index)
        {
            IsOutBounds(index);
            for (int i = index; i < _items.Length - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _items[_items.Length - 1] = default;
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _items[i];
            }
        }

        private void GrowIfNecessary()
        {
            if (Count == _items.Length)
            {
                var arrayCopy = new T[_items.Length * 2];
                for (int i = 0; i < _items.Length; i++)
                {
                    arrayCopy[i] = _items[i];
                }
                _items = arrayCopy;
            }
        }

        private void IsOutBounds(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}