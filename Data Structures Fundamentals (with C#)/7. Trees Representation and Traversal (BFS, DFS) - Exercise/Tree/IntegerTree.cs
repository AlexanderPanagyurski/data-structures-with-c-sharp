namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            var result = new List<List<int>>();

            var currentPath = new LinkedList<int>();
            currentPath.AddFirst(sum);

            int currentSum = this.Key;
            Dfs(this, result, currentPath, ref currentSum, sum);

            return result;
        }

        private void Dfs(
            Tree<int> subTree,
            List<List<int>> result,
            LinkedList<int> currentPath,
            ref int currentSum,
            int sum)
        {
            foreach (var child in this.Children)
            {
                currentSum += child.Key;
                currentPath.AddLast(child.Key);
                Dfs(child, result, currentPath, ref currentSum, sum);
            }
            if (currentSum == sum)
            {
                result.Add(new List<int>(currentPath));
            }
            currentSum -= subTree.Key;
            currentPath.RemoveLast();
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            var result = Bfs(this, sum);

            return result;
        }

        private List<Tree<int>> Bfs(Tree<int> subTree, int sum)
        {
            var queue = new Queue<Tree<int>>();
            var result=new List<Tree<int>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currentSubTree = queue.Dequeue();

                int currentSubTreeSum = currentSubTree.Key;

                foreach (var child in currentSubTree.Children)
                {
                    currentSubTreeSum += child.Key;
                    queue.Enqueue(child);
                }

                if (currentSubTreeSum == sum)
                {
                    result.Add(currentSubTree);
                }
            }

            return result;
        }
    }
}
