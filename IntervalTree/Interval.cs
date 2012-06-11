using System;

namespace IntervalTree
{
    /// <summary>
    /// Representation of bounded interval
    /// </summary>
    /// <typeparam name="T">type of interval bounds</typeparam>
    public struct Interval<T> : IComparable<Interval<T>> where T: struct, IComparable<T>
    {
        public T Start
        {
            get;
            set;
        }

        public T End
        {
            get;
            set;
        }

        public Interval(T start, T end)
            : this()
        {
            Start = start;
            End = end;

            if (Start.CompareTo(End) > 0) {
                throw new ArgumentException("Start cannot be larger than End of interval");
            }
        }

        /// <summary>
        /// Tests if interval contains given interval
        /// </summary>
        public bool Contains(Interval<T> interval)
        {
            return Start.CompareTo(interval.Start) <= 0 && End.CompareTo(interval.End) >= 0;
        }

        /// <summary>
        /// Tests if interval contains given value
        /// </summary>
        public bool Contains(T val)
        {
            return Start.CompareTo(val) <= 0 && End.CompareTo(val) >= 0;
        }

        public bool Overlaps(Interval<T> interval)
        {
            return Start.CompareTo(interval.End) <= 0 && End.CompareTo(interval.Start) >= 0;
        }

        /// <summary>
        /// Porovná dva intervaly
        /// 
        /// Lineární uspořádání je def. 1) pořadím počátků 2) pořadím konců
        /// </summary>
        /// <param name="i">interval k porovnání</param>
        /// <returns></returns>
        public int CompareTo(Interval<T> i)
        {
            if (Start.CompareTo(i.Start) < 0) {
                return -1;
            } else if (Start.CompareTo(i.Start) > 0) {
                return 1;
            } else if (End.CompareTo(i.End) < 0) {
                return 1;
            } else if (End.CompareTo(i.End) > 0) {
                return -1;
            }

            // Identical interval
            return 0;
        }

        public override string ToString()
        {
            return String.Format("<{0}, {1}>", Start.ToString(), End.ToString());
        }
    }
}
