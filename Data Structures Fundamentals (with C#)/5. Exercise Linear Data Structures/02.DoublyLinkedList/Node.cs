namespace Problem02.DoublyLinkedList
{
    public class Node<T>
    {
        public Node(T value, Node<T> next = null)
        {
            Value = value;
            Next = next;
        }

        public T Value { get; set; }

        public Node<T> Previous { get; set; }

        public Node<T> Next { get; set; }
    }
}
