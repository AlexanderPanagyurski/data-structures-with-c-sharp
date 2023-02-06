namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                child.Parent = this;
                this.children.Add(child);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string AsString()
        {
            var sb = new StringBuilder();

            this.DfsAsString(sb, this, 0);

            return sb.ToString().Trim();
        }


        public IEnumerable<T> GetInternalKeys() =>
            BfsTraverseKeys(tree => tree.children.Count > 0 && tree.Parent != null)
            .Select(tree => tree.Key).ToArray();

        public IEnumerable<T> GetLeafKeys() =>
            BfsTraverseKeys(tree => tree.children.Count == 0)
            .Select(tree => tree.Key).ToArray();

        public T GetDeepestKey()
        {
            var deepestNodes = BfsTraverseKeys(tree => tree.children.Count == 0);
            var deepestNode = default(T);
            var maxDepth = 0;
            var currentDepth = 0;

            foreach (var node in deepestNodes)
            {
                var currentNode = node;

                while (currentNode != null)
                {
                    currentDepth++;
                    currentNode = currentNode.Parent;
                }
                if (currentDepth > maxDepth)
                {
                    maxDepth = currentDepth;
                    deepestNode = node.Key;
                }
                currentDepth = 0;
            }
            return deepestNode;
        }

        public IEnumerable<T> GetLongestPath()
        {
            var deepestNodes = this.BfsTraverseKeys(tree => tree.children.Count == 0);
            var deepestNode = default(Tree<T>);
            var path = new Stack<T>();
            var maxDepth = 0;
            var currentDepth = 0;

            foreach (var node in deepestNodes)
            {
                var currentNode = node;

                while (currentNode != null)
                {
                    currentDepth++;
                    currentNode = currentNode.Parent;
                }
                if (currentDepth > maxDepth)
                {
                    maxDepth = currentDepth;
                    deepestNode = node;
                }
                currentDepth = 0;
            }

            while (deepestNode != null)
            {
                path.Push(deepestNode.Key);
                deepestNode = deepestNode.Parent;
            }

            return path.ToArray();
        }

        private void DfsAsString(StringBuilder sb, Tree<T> tree, int indent)
        {
            sb.Append(' ', indent)
              .AppendLine(tree.Key.ToString());

            foreach (var child in tree.children)
            {
                this.DfsAsString(sb, child, indent + 2);
            }
        }

        private IEnumerable<Tree<T>> BfsTraverseKeys(Predicate<Tree<T>> predicate)
        {
            var queue = new Queue<Tree<T>>();
            var result = new List<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();

                if (predicate.Invoke(subTree))
                {
                    result.Add(subTree);
                }

                foreach (var child in subTree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }
    }
}
