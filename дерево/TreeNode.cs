using System;

namespace WindowsFormsApp1
{
    class TreeNode<T> where T : IComparable<T>
    {
        public TreeNode(T value, TreeNode<T> parent)
        {
            Value = value;
            Parent = parent;
        }

        public T Value { get; set; }

        public TreeNode<T> Left { get; set; }

        public TreeNode<T> Parent { get; }

        public TreeNode<T> Right { get; set; }
    }
}
