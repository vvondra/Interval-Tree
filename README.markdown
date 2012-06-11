Introduction
------------

This is an implementation of augmented Interval Trees stored in a balanced red and black tree. Most of the implementation is explained in detail in [Introduction to Algorithms by T. Cormen et al.][book]

The source has been compiled both on .NET and Mono.

[book]: http://books.google.cz/books?id=NLngYyWFl_YC&lpg=PP1&dq=isbn%3A0262032937&pg=PP1#v=onepage&q&f=false

Functionality
-------------

The tree knows how to store intervals of any IComparable type. Both insertion and deletion are implemented. Querying is possible for all intervals containing a point or all intervals overlapping with an interval.


Implementation
--------------

### Memory

Each interval is stored in one node which takes a constant amount of memory, and no redundant nodes are needed, thus the memory complexity is O(n).

### Leaf pointers

The leaves of an interval tree are formally NULL nodes, some implementations choose to create dummy nodes instead of leaving null pointers in the real tree leaves. This implementation uses the concept of a sentinel node - a common node to which all null pointers point. The Left, Right and Parent nodes of the Sentinel node is itself.

This makes it easier to implement the rest of the features, since it can be manipulated as an ordinary node and yet maintains the behaviour that a null pointer would have.

### Insertion

Insertion finds an empty spot for the element (it will do nothing if it already is in the tree), attaches the interval and rebalances the tree.

Insertion is O(lg n). Descending to a free spot costs a maximum of lg N steps (from the balanced nature of the red-black tree). `RenewConstraintsAfterInsert` called to rebalance the tree runs in O(1) as only local rotation and recoloring is performed, in the worst case it may bubble up to the root, which gives a total of O(lg n). Together, O(lg n + lg n) is still O(lg n).

In addition to an ordinary BST, during insertion, the `MaxEnd` (holding the maximum interval endpoint value of the node's subtree) property of nodes must be updated. This can be easily accomplished in O(1), since all operations are local and properties of the respective node subtrees are maintained constant.


### Deletion

Similarly, deletion also runs in O(lg n). O(lg n) is the time necessary to find the value to be deleted. There are three possible cases:

 - the node has both children - the successor (minimum node of right subtree) is taken and replaces the node, the node, now in the place of the successor, must have only one child, converting it to the the next case:
 - the node has one child or none - we take the existing child (or the left one if one) and replace the node with it

Deletion then runs exactly as in an ordinary R-B tree. The only difference is the maintaining of the `MaxEnd` property, but that is taken care of in the rotation procedures common with Insertion.

Rebalancing starts with the replaced node (taking O(1) time, as all rotations are local) and may bubble up to the root, taking O(lg n) time.

By examining all the possible scenarios, during both operations, all the tree constraints are maintained ensuring the necessary time complexities for traversing the tree.

### Querying for a single point

As a point can be present in all of the intervals in the tree, worst case querying is O(N). To reduce the amount of tests and traversing, two scenarios can be cut off - when the value is larger than the `MaxEnd` value of the node (then it cannot be in the whole subtree) or if its smaller than the start point of the interval of a node, then it cannot be in the right subtree.




