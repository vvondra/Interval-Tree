Introduction
------------

This is an implementation of augmented Interval Trees stored in a balanced red and black tree. Most of the implementation is explained in detail in [Introduction to Algorithms by T. Cormen et al.][book]

The source has been compiled both on .NET and Mono.

[book]: http://books.google.cz/books?id=NLngYyWFl_YC&lpg=PP1&dq=isbn%3A0262032937&pg=PP1#v=onepage&q&f=false

Functionality
-------------

The tree knows how to store intervals of any IComparable type. Both insertion and deletion are implemented. Querying is possible for all intervals containing a point or all intervals overlapping with an interval.

### Insertion

Insertion finds an empty spot for the element (it will do nothing if it already is in the tree), attaches the interval and rebalances the tree.

Insertion is O(lg n). Descending to a free spot costs a maximum of lg N steps (from the balanced nature of the red-black tree). `RenewConstraintsAfterInsert` called to rebalance the tree runs in O(1) as only local rotation and recoloring is performed, in the worst case it may bubble up to the root, which gives a total of O(lg n). Together, O(lg n + lg n) is still O(lg n).

In addition to an ordinary BST, during insertion, the `MaxEnd` (holding the maximum interval endpoint value of the node's subtree) property of nodes must be updated. This can be easily accomplished in O(1), since all operations are local and properties of the respective node subtrees are maintained constant.


### Deletion




