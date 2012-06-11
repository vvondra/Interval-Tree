using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntervalTree
{
    /// <summary>
    /// Tree capable of adding arbitrary intervals and performing search queries on them
    /// </summary>
    public partial class IntervalTree<T> : IEnumerable<Interval<T>> where T : struct, IComparable<T>
    {

        IntervalNode<T> Root
        {
            get;
            set;
        }

        #region Tree searching
        /// <summary>
        /// Search interval tree for a given point
        /// </summary>
        /// <param name="val">value to be searched for</param>
        /// <returns>list of intervals which contain the value</returns>
        public List<Interval<T>> Search(T val)
        {
            var result = new List<Interval<T>>();
            SearchSubtree(Root, val, result);
            return result;
        }

        /// <summary>
        /// Search interval tree for intervals overlapping with given
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public List<Interval<T>> Search(Interval<T> i)
        {
            var result = new List<Interval<T>>();
            SearchSubtree(Root, i, result);
            return result;
        }

        private void SearchSubtree(IntervalNode<T> node, Interval<T> i, List<Interval<T>> result) {
            if (node == null) {
                return;
            }

            if (node.Left != null) {
                SearchSubtree(node.Left, i, result);
            }

            if (i.Overlaps(node.Interval)) {
                result.Add(node.Interval);
            }

            // Interval start is greater than largest endpoint in this subtree
            if (node.Right != null && i.Start.CompareTo(node.MaxEnd) <= 0) {
                SearchSubtree(node.Right, i, result);
            }
        }

        private IntervalNode<T> FindInterval(IntervalNode<T> tree, Interval<T> i)
        {
            if (tree.Interval.CompareTo(i) == 0) {
                return tree;
            }

            if (tree.Interval.CompareTo(i) > 0 && tree.Left != null) {
                return FindInterval(tree.Left, i);
            }

            if (tree.Interval.CompareTo(i) < 0 && tree.Right != null) {
                return FindInterval(tree.Right, i);
            }

            return null;
            
        }

        /// <summary>
        /// Recursively descends down the tree and adds valids results to the resultset
        /// </summary>
        /// <param name="node">subtree to be searched</param>
        /// <param name="val">value to be searched for</param>
        /// <param name="result">current resultset</param>
        private void SearchSubtree(IntervalNode<T> node, T val, List<Interval<T>> result)
        {
            if (node == null) {
                return;
            }

            // Value is higher than any interval in this subtree
            if (val.CompareTo(node.MaxEnd) > 0) {
                return;
            }

            if (node.Left != null) {
                SearchSubtree(node.Left, val, result);
            }

            if (node.Interval.Contains(val)) {
                result.Add(node.Interval);
            }

            if (val.CompareTo(node.Interval.Start) < 0) {
                return;
            }

            if (node.Right != null) {
                SearchSubtree(node.Right, val, result);
            }
        }

        #endregion search

        /// <summary>
        /// Insert new interval to interval tree
        /// </summary>
        /// <param name="interval">interval to add</param>
        public void Add(Interval<T> interval)
        {
            var node = new IntervalNode<T>(interval);
            if (Root == null) {
                node.Color = NodeColor.BLACK;
                Root = node;
            } else {
                InsertInterval(interval, Root);
            }
        }

        #region Tree insertion internals

        /// <summary>
        /// Recursively descends to the correct spot for interval insertion in the tree
        /// When a free spot is found for the node, it is attached and tree state is validated
        /// </summary>
        /// <param name="interval">interval to be added</param>
        /// <param name="currentNode">subtree accessed in recursion</param>
        private void InsertInterval(Interval<T> interval, IntervalNode<T> currentNode)
        {
            IntervalNode<T> addedNode = null;
            if (interval.CompareTo(currentNode.Interval) < 0) {
                if (currentNode.Left == null) {
                    addedNode = new IntervalNode<T>(interval);
                    addedNode.Color = NodeColor.RED;
                    currentNode.Left = addedNode;
                    addedNode.Parent = currentNode;
                } else {
                    InsertInterval(interval, currentNode.Left);
                    return;
                }
            } else if (interval.CompareTo(currentNode.Interval) > 0) {
                if (currentNode.Right == null) {
                    addedNode = new IntervalNode<T>(interval);
                    addedNode.Color = NodeColor.RED;
                    currentNode.Right = addedNode;
                    addedNode.Parent = currentNode;
                } else {
                    InsertInterval(interval, currentNode.Right);
                    return;
                }
            } else {
                return;
            }

            addedNode.Parent.RecalculateMaxEnd();

            ApplyTreeConstraints(addedNode);

            Root.Color = NodeColor.BLACK;
        }

        /// <summary>
        /// Validates and applies RB-tree constaints to node 
        /// </summary>
        /// <param name="node">node to be validated and fixed</param>
        private void ApplyTreeConstraints(IntervalNode<T> node)
        {
            if (node.Parent == null) {
                return;
            }

            if (node.Parent.Color == NodeColor.BLACK) {
                return;
            }

            var uncle = node.Uncle;

            if (uncle != null && uncle.Color == NodeColor.RED) {
                node.Parent.Color = uncle.Color = NodeColor.BLACK;

                var gparent = node.GrandParent;
                if (gparent != null && !gparent.IsRoot) {
                    gparent.Color = NodeColor.RED;
                    ApplyTreeConstraints(gparent);
                }
            } else {
                if (node.ParentDirection == NodeDirection.LEFT && node.Parent.ParentDirection == NodeDirection.RIGHT) {
                    RotateLeft(node.Parent);
                    node = node.Left;
                } else if (node.ParentDirection == NodeDirection.RIGHT && node.Parent.ParentDirection == NodeDirection.LEFT) {
                    RotateRight(node.Parent);
                    node = node.Right;
                }

                node.Parent.Color = NodeColor.BLACK;

                if (node.GrandParent == null) {
                    return;
                }
                node.GrandParent.Color = NodeColor.RED;

                if (node.ParentDirection == NodeDirection.RIGHT) {
                    RotateRight(node.GrandParent);
                } else {
                    RotateLeft(node.GrandParent);
                }
            }

        }

        #endregion Tree insertion internals

        /// <summary>
        /// Removes interval from tree (if present in tree)
        /// </summary>
        /// <param name="?"></param>
        public void Remove(Interval<T> interval) {
            RemoveNode(FindInterval(Root, interval));
        }

        private void RemoveNode(IntervalNode<T> node)
        {
            if (node == null) {
                return;
            }

            IntervalNode<T> temp = node;
            if (node.Right != null && node.Left != null) {
                // Trick when deleting node with both children, switch it with closest in order node
                // swap values and delete the bottom node converting it to other cases

                temp = node.GetSuccessor();
                node.Interval = temp.Interval;

                node.RecalculateMaxEnd();
                while (node.Parent != null) {
                    node = node.Parent;
                    node.RecalculateMaxEnd();
                }
            }
            node = temp;
            temp = node.Left != null ? node.Left : node.Right;

            // we will replace node with temp and delete node
            temp.Parent = node.Parent;
            if (node.IsRoot) {
                Root = temp; // Set new root
            } else {

                // Reattach node to parent
                if (node.ParentDirection == NodeDirection.RIGHT) {
                    node.Parent.Left = temp;
                } else {
                    node.Parent.Right = temp;
                }

                IntervalNode<T> maxAux = node.Parent;
                maxAux.RecalculateMaxEnd();
                while (maxAux.Parent != null) {
                    maxAux = maxAux.Parent;
                    maxAux.RecalculateMaxEnd();
                }
            }

            if (node.Color == NodeColor.BLACK) {
                RenewConstraintsAfterDelete(node);
            }
             
        }

        /// <summary>
        /// Ensures constraints still apply after node deletion
        /// 
        ///  - made with the help of algorithm from Cormen et Al. Introduction to Algorithms 2nd ed.
        /// </summary>
        /// <param name="node"></param>
        private void RenewConstraintsAfterDelete(IntervalNode<T> node)
        {
            // Need to bubble up and fix
            while (node != Root && node.Color == NodeColor.BLACK) {
                if (node.ParentDirection == NodeDirection.LEFT) {
                    IntervalNode<T> aux = node.Parent.Right;
                    if (aux.Color == NodeColor.RED) {
                        aux.Color = NodeColor.BLACK;
                        node.Parent.Color = NodeColor.RED;
                        RotateLeft(node.Parent);
                        aux = node.Parent.Right;
                    }

                    if (aux.Left.Color == NodeColor.BLACK && aux.Right.Color == NodeColor.BLACK) {
                        aux.Color = NodeColor.RED;
                        node = node.Parent;
                    } else {
                        if (aux.Right.Color == NodeColor.BLACK) {
                            aux.Left.Color = NodeColor.BLACK;
                            aux.Color = NodeColor.RED;
                            RotateRight(aux);
                            aux = node.Parent.Right;
                        }

                        aux.Color = node.Parent.Color;
                        node.Parent.Color = NodeColor.BLACK;
                        aux.Right.Color = NodeColor.BLACK;
                        RotateLeft(node.Parent);
                        node = Root;
                    }
                } else {
                    IntervalNode<T> aux = node.Parent.Left;
                    if (aux.Color == NodeColor.RED) {
                        aux.Color = NodeColor.BLACK;
                        node.Parent.Color = NodeColor.RED;
                        RotateRight(node.Parent);
                        aux = node.Parent.Left;
                    }

                    if (aux.Left.Color == NodeColor.BLACK && aux.Right.Color == NodeColor.BLACK) {
                        aux.Color = NodeColor.RED;
                        node = node.Parent;
                    } else {
                        if (aux.Left.Color == NodeColor.BLACK) {
                            aux.Right.Color = NodeColor.BLACK;
                            aux.Color = NodeColor.RED;
                            RotateLeft(aux);
                            aux = node.Parent.Left;
                        }

                        aux.Color = node.Parent.Color;
                        node.Parent.Color = NodeColor.BLACK;
                        aux.Left.Color = NodeColor.BLACK;
                        RotateRight(node.Parent);
                        node = Root;
                    }
                }
            }

            node.Color = NodeColor.BLACK;
        }
        /*
        private void RemoveNodeAndRebalanceTree(IntervalNode<T> node)
        {
            // Case with no children
            if (node.IsLeaf) {
                var sibling = node.Sibling;

                // Reset parent pointer to node
                if (node.ParentDirection == NodeDirection.LEFT) {
                    node.Parent.Right = null;
                } else if (node.ParentDirection == NodeDirection.RIGHT) {
                    node.Parent.Left = null;
                }

                node.Parent = null;

                // Only removal of a black node could break the tree constraints
                if (node.Color == NodeColor.BLACK) {

                    if (sibling != null) {

                        // Node and sibling were both leaves, just move the black node up one level
                        if (sibling.IsLeaf) {
                            sibling.Color = NodeColor.RED;
                            sibling.Parent.Color = NodeColor.BLACK;
                        } else if (sibling.Right != null && sibling.Left == null) {
                            
                            // sibling has a right child
                            if (sibling.CompareTo(node) > 0) {
                                // sibling was on the right
                                sibling.Right.Color = NodeColor.BLACK;
                                sibling.Color = sibling.Parent.Color;
                                sibling.Parent.Color = NodeColor.BLACK;
                                RotateLeft(sibling.Parent);
                            } else {
                                // sibling was on the left
                                RotateLeft(sibling);
                                sibling.Color = NodeColor.BLACK;
                                sibling.Parent.Color = sibling.GrandParent.Color;
                                sibling.GrandParent.Color = NodeColor.BLACK;
                                RotateRight(sibling.GrandParent);
                            }
                        } else if (sibling.Left != null && sibling.Right == null) {

                            // sibling has a left child
                            if (sibling.CompareTo(node) > 0) {
                                // sibling was on the right
                                RotateRight(sibling);
                                sibling.Color = NodeColor.BLACK;
                                sibling.Parent.Color = sibling.GrandParent.Color;
                                sibling.GrandParent.Color = NodeColor.BLACK;
                                RotateLeft(sibling.GrandParent);
                            } else {
                                // sibling was on the left
                                sibling.Left.Color = NodeColor.BLACK;
                                sibling.Color = sibling.Parent.Color;
                                sibling.Parent.Color = NodeColor.BLACK;
                                RotateRight(sibling.Parent);
                            }
                        } else if (sibling.Left != null && sibling.Right != null) {
                            // sibling has both children

                            if (sibling.Color == NodeColor.BLACK) {
                                if (sibling.CompareTo(node) > 0) {
                                    // sibling was on the right
                                    sibling.Right.Color = NodeColor.BLACK;
                                    sibling.Color = sibling.Parent.Color;
                                    sibling.Parent.Color = NodeColor.BLACK;
                                    RotateLeft(sibling.Parent);
                                } else {
                                    // sibling was on the left
                                    sibling.Left.Color = NodeColor.BLACK;
                                    sibling.Color = sibling.Parent.Color;
                                    sibling.Parent.Color = NodeColor.BLACK;
                                    RotateRight(sibling.Parent);
                                }
                            } else {
                                // Most complex case - black removed and sibling is red with two black children




                            }
                        }
                    }
                }
            }
        }
        */
        /// <summary>
        /// General right rotation
        /// </summary>
        /// <param name="node">Top of rotated subtree</param>
        private void RotateRight(IntervalNode<T> node)
        {
            var pivot = node.Left;
            NodeDirection dir = node.ParentDirection;
            var parent = node.Parent;
            var tempTree = pivot.Right;
            pivot.Right = node;
            node.Parent = pivot;
            node.Left = tempTree;
            if (tempTree != null) {
                tempTree.Parent = node;
            }

            if (dir == NodeDirection.LEFT) {
                parent.Right = pivot;
            } else if (dir == NodeDirection.RIGHT) {
                parent.Left = pivot;
            } else {
                Root = pivot;
            }

            pivot.Parent = parent;

            node.RecalculateMaxEnd();
            pivot.RecalculateMaxEnd();

        }

        /// <summary>
        /// General left rotation
        /// </summary>
        /// <param name="node">top of rotated subtree</param>
        private void RotateLeft(IntervalNode<T> node)
        {
            var pivot = node.Right;
            NodeDirection dir = node.ParentDirection;
            var parent = node.Parent;
            var tempTree = pivot.Left;
            pivot.Left = node;
            node.Parent = pivot;
            node.Right = tempTree;
            if (tempTree != null) {
                tempTree.Parent = node;
            }

            if (dir == NodeDirection.LEFT) {
                parent.Right = pivot;
            } else if (dir == NodeDirection.RIGHT) {
                parent.Left = pivot;
            } else {
                Root = pivot;
            }

            pivot.Parent = parent;

            node.RecalculateMaxEnd();
            pivot.RecalculateMaxEnd();
        }

        #region Enumerators
        private IEnumerable<Interval<T>> InOrderWalk(IntervalNode<T> node)
        {
            if (node.Left != null) {
                foreach (Interval<T> val in InOrderWalk(node.Left)) {
                    yield return val;
                }
            }

            yield return node.Interval;

            if (node.Right != null) {
                foreach (Interval<T> val in InOrderWalk(node.Right)) {
                    yield return val;
                }
            }
        }

        public IEnumerator<Interval<T>> GetEnumerator()
        {
            foreach (Interval<T> val in InOrderWalk(Root)) {
                yield return val;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
