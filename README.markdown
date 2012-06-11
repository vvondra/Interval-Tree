Introduction
------------

This is an implementation of augmented Interval Trees stored in a balanced red and black tree. Most of the implementation is explained in detail in [Introduction to Algorithms by T. Cormen et al.][book]

The source has been compiled both on .NET and Mono.

[book]: http://books.google.cz/books?id=NLngYyWFl_YC&lpg=PP1&dq=isbn%3A0262032937&pg=PP1#v=onepage&q&f=false

Functionality
-------------

The tree knows how to store intervals of any IComparable type. Both insertion and deletion are implemented. Querying is possible for all intervals containing a point or all intervals overlapping with an interval.


