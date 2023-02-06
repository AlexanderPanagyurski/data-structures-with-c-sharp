namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private T value;
        private Tree<T> parent;
        private IList<Tree<T>> children;

        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentNode = FindNodeWithBfs(parentKey);

            if (parentNode == null)
            {
                throw new ArgumentNullException();
            }
            parentNode.children.Add(child);
        }

        private Tree<T> FindNodeWithBfs(T parent)
        {
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();

                if (subTree.value.Equals(parent))
                {
                    return subTree;
                }
                foreach (var child in subTree.children)
                {
                    queue.Enqueue(child);
                }
            }
            return null;
        }

        public IEnumerable<T> OrderBfs()
        {
            var queue = new Queue<Tree<T>>();
            var result = new List<T>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();
                result.Add(subTree.value);

                foreach (var child in subTree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            var result = new List<T>();

            RecurisveDfs(result, this);

            return result.ToArray();
        }

        private void RecurisveDfs(List<T> result, Tree<T> subTree)
        {
            foreach (var child in subTree.children)
            {
                RecurisveDfs(result, child);
            }
            result.Add(subTree.value);
        }

        private void DfsWithStack(Stack<T> result)
        {
            var stack = new Stack<Tree<T>>();

            stack.Push(this);

            while (stack.Count > 0)
            {
                var subTree = stack.Pop();
                result.Push(subTree.value);

                foreach (var child in subTree.children)
                {

                    stack.Push(child);
                }
            }
        }

        public void RemoveNode(T nodeKey)
        {
            var nodeToDelete = FindNodeWithBfs(nodeKey);

            if (nodeToDelete == null)
            {
                throw new ArgumentNullException();
            }

            var nodeToDeleteParent = nodeToDelete.parent;

            if (nodeToDeleteParent == null)
            {
                throw new ArgumentException();
            }

            nodeToDeleteParent.children.Remove(nodeToDelete);
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = FindNodeWithBfs(firstKey);
            var secondNode = FindNodeWithBfs(secondKey);

            if (firstNode == null || secondNode == null)
            {
                throw new ArgumentNullException();
            }

            var firstNodeParent = firstNode.parent;
            var secondNodeParent = secondNode.parent;

            if (firstNodeParent == null || secondNodeParent == null)
            {
                throw new ArgumentException();
            }

            var indexOfFistNode = firstNodeParent.children.IndexOf(firstNode);
            var indexOfSecondNode = secondNodeParent.children.IndexOf(secondNode);

            firstNodeParent.children[indexOfFistNode] = secondNode;
            secondNodeParent.children[indexOfSecondNode] = firstNode;
        }
    }
}
