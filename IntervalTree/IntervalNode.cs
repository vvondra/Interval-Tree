using System;
using System.Text;

namespace IntervalTree
{

    /// <summary>
    /// Node of interval Tree
    /// </summary>
    /// <typeparam name="T">type of interval bounds</typeparam>
    internal class IntervalNode<T> : IComparable<IntervalNode<T>> where T: struct, IComparable<T>
    {

        public IntervalNode<T> Left { get; set; }
        public IntervalNode<T> Right { get; set; }
        public IntervalNode<T> Parent { get; set; }

        /// <summary>
        /// Maximum "end" value of interval in node subtree
        /// </summary>
        public T MaxEnd { get; set; }

        /// <summary>
        /// The interval this node holds
        /// </summary>
        public Interval<T> Interval;

        private NodeColor color;
        /// <summary>
        /// Color of the node used for R-B implementation
        /// </summary>
        public NodeColor Color {
            get { return color; }
            set {
                this.color = value;
            }
            
        }

        public IntervalNode(Interval<T> interval)
        {
            MaxEnd = interval.End;
            Interval = interval;
            Color = NodeColor.RED;
        }

        /// <summary>
        /// Indicates wheter the node has a parent
        /// </summary>
        public bool IsRoot
        {
            get { return Parent == null; }
        }

        /// <summary>
        /// Indicator whether the node has children
        /// </summary>
        public bool IsLeaf
        {
            get { return Right == null && Left == null; }
        }

        /// <summary>
        /// The direction of the parent, from the child point-of-view
        /// </summary>
        public NodeDirection ParentDirection
        {
            get
            {
                if (Parent == null) {
                    return NodeDirection.NONE;
                }

                return Parent.Left == this ? NodeDirection.RIGHT : NodeDirection.LEFT;
            }
        }

        public IntervalNode<T> GetSuccessor()
        {
            if (Right == null) {
                return null;
            }

            var node = Right;
            while (node.Left != null) {
                node = node.Left;
            }

            return node;
        }

        public int CompareTo(IntervalNode<T> other)
        {
            return Interval.CompareTo(other.Interval);
        }

        /// <summary>
        /// Refreshes the MaxEnd value after node manipulation
        /// 
        /// This is a local operation only
        /// </summary>
        public void RecalculateMaxEnd()
        {
            T max = Interval.End;

            if (Right != null) {
                if (Right.Interval.End.CompareTo(max) > 0) {
                    max = Right.Interval.End;
                }
            }

            if (Left != null) {
                if (Left.Interval.End.CompareTo(max) > 0) {
                    max = Left.Interval.End;
                }
            }

            MaxEnd = max;
        }

        /// <summary>
        /// Return grandparent node
        /// </summary>
        /// <returns>grandparent node or null if none</returns>
        public IntervalNode<T> GrandParent
        {
            get
            {
                if (Parent != null) {
                    return Parent.Parent;
                }
                return null;
            }
        }

        /// <summary>
        /// Returns sibling of parent node
        /// </summary>
        /// <returns>sibling of parent node or null if none</returns>
        public IntervalNode<T> Uncle
        {
            get
            {
                var gparent = GrandParent;
                if (gparent == null) {
                    return null;
                }

                if (Parent == gparent.Left) {
                    return gparent.Right;
                }

                return gparent.Left;
            }
        }

        /// <summary>
        /// Returns sibling node
        /// </summary>
        /// <returns>sibling node or null if none</returns>
        public IntervalNode<T> Sibling
        {
            get
            {
                if (Parent != null) {
                    if (Parent.Right == this) {
                        return Parent.Left;
                    }

                    return Parent.Right;
                }

                return null;
            }
        }
    }

    internal enum NodeColor
    {
        RED,
        BLACK
    }

    internal enum NodeDirection
    {
        LEFT,
        RIGHT,
        NONE
    }
}
