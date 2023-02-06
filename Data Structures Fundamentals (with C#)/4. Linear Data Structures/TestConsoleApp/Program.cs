using Problem02.Stack;
using Problem04.SinglyLinkedList;
using System;

namespace TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SinglyLinkedList<int> list = new SinglyLinkedList<int>();

            //for (int i = 0; i < 10; i++)
            //{
            //    list.AddFirst(i);
            //}
            //for (int i = 0; i < 5; i++)
            //{
            //   list.RemoveLast();
            //}

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(stack.Contains(i));
            }
        }
    }
}
