using Microsoft.Msagl.Drawing;
using System;
using System.Collections;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    class MyTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public void Add(T value)
        {
            root = Add(root, value);
        }

        private TreeNode<T> Add(TreeNode<T> node, T value, TreeNode<T> parent = null)
        {
            if (node == null)
            {
                node = new TreeNode<T>(value, parent);
            }
            else if (node.Value.CompareTo(value) > 0)
            {
                node.Left = Add(node.Left, value, node);
            }
            else if (node.Value.CompareTo(value) < 0)
            {
                node.Right = Add(node.Right, value, node);
            }
            return node;
        }

        private string ListToString(List<T> list)
        {
            string text = string.Empty;
            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0)
                {
                    text += " ";
                }
                text += list[i].ToString();
            }
            return text;
        }

        public TreeNode<T> Find(T value)
        {
            return Find(root, value);
        }

        private TreeNode<T> Find(TreeNode<T> node, T value)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.Value.CompareTo(value) > 0)
            {
                return Find(node.Left, value);
            }
            else if (node.Value.CompareTo(value) < 0)
            {
                return Find(node.Right, value);
            }
            else
            {
                return node;
            }
        }

        public string CLR()
        {
            List<T> list = new List<T>();
            list = CLR(root, list);
            return ListToString(list);
        }

        public string LCR()
        {
            List<T> list = new List<T>();
            list = LCR(root, list);
            return ListToString(list);
        }

        public Graph Show()
        {
            Graph graph = new Graph();
            graph = CRL(root, graph);
            return graph;
        }

        public string RCL()
        {
            List<T> list = new List<T>();
            list = RCL(root, list);
            return ListToString(list);
        }

        public string Across()
        {
            List<T> list = new List<T>();
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                TreeNode<T> node = queue.Dequeue();
                if (node != null)
                {
                    list.Add(node.Value);
                    queue.Enqueue(node.Left);
                    queue.Enqueue(node.Right);
                }
            }
            return ListToString(list);
        }

        private List<T> CLR(TreeNode<T> node, List<T> list)
        {
            if (node != null)
            {
                list.Add(node.Value);
                list = CLR(node.Left, list);
                list = CLR(node.Right, list);
            }
            return list;
        }

        public Graph CRL(TreeNode<T> node, Graph graph, string label = "")
        {
            if (node != null)
            {
                if (node.Parent == null)
                {
                    graph.AddNode(node.Value.ToString());
                }
                else
                {
                    Edge edge = graph.AddEdge(node.Parent.Value.ToString(), label, node.Value.ToString());
                    edge.Attr.ArrowheadAtTarget = ArrowStyle.Normal;
                }
                graph = CRL(node.Right, graph, "R");
                graph = CRL(node.Left, graph, "L");
            }
            return graph;
        }

        private List<T> LCR(TreeNode<T> node, List<T> list)
        {
            if (node != null)
            {
                list = LCR(node.Left, list);
                list.Add(node.Value);
                list = LCR(node.Right, list);
            }
            return list;
        }

        private List<T> RCL(TreeNode<T> node, List<T> list)
        {
            if (node != null)
            {
                list = RCL(node.Right, list);
                list.Add(node.Value);
                list = RCL(node.Left, list);
            }
            return list;
        }

        public void Delete(T value)
        {
            TreeNode<T> node = Find(value);
            if (node != null)
            {
                if (node.Left == null || node.Right == null)
                {
                    TreeNode<T> child = null;
                    if (node.Left != null)
                    {
                        child = node.Left;
                    }
                    else if (node.Right != null)
                    {
                        child = node.Right;
                    }
                    if (node.Parent == null)
                    {
                        root = child;
                    }
                    else
                    {
                        if (node.Parent.Left == node)
                        {
                            node.Parent.Left = child;
                        }
                        else
                        {
                            node.Parent.Right = child;
                        }
                    }
                }
                else
                {
                    TreeNode<T> mostLeft = node.Right;
                    TreeNode<T> mostLeftParent = node;
                    while (mostLeft.Left != null)
                    {
                        mostLeftParent = mostLeft;
                        mostLeft = mostLeft.Left;
                    }
                    node.Value = mostLeft.Value;
                    if (mostLeftParent.Left == mostLeft)
                    {
                        mostLeftParent.Left = null;
                    }
                    else
                    {
                        mostLeftParent.Right = null;
                    }
                }
            }
        }

        private List<T> ToList()
        {
            return LCR(root, new List<T>());
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
