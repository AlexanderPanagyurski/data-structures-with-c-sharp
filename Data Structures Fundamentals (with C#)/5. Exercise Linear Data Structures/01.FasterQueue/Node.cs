﻿using System;
namespace Problem01.CircularQueue
{
    public class Node<T>
    {
        public Node(T value, Node<T> next = null)
        {
            Value = value;
            Next = next;
        }

        public T Value { get; set; }

        public Node<T> Next { get; set; }
    }
}
