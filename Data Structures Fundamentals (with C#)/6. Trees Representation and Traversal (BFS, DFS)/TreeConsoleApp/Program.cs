using System;
using Tree;

namespace TreeConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var subTree = new Tree<int>(2,
                                new Tree<int>(6),
                                new Tree<int>(7),
                                new Tree<int>(5)
                        );

            var tree = new Tree<int>(9,
                            subTree,
                            new Tree<int>(10),
                            new Tree<int>(11),
                            new Tree<int>(16,
                                new Tree<int>(1),
                                new Tree<int>(4,
                                    new Tree<int>(17)),
                                new Tree<int>(3,
                                    new Tree<int>(14))
                            ),
                            new Tree<int>(12)
                        );

            //9, 2, 10, 11, 16, 12, 6, 7, 5, 1, 4, 3, 17 14
            Console.WriteLine(string.Join(", ", tree.OrderBfs()));
        }
    }
}
