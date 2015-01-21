using System.Collections;
using System.Collections.Generic;
using System.Linq;
using IntervalTree;
using NUnit.Framework;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace Tests.IntervalTree.IntervalTreeSpecs
{
    [TestFixture]
    public class If_the_user_searches_for_overlapping_entries_in_an_interval_tree : Spec {
        private static IEnumerable<Interval<int>> TestEntries() {
            yield return new Interval<int>(1400, 1500);
            yield return new Interval<int>(0100, 0130);
            yield return new Interval<int>(1700, 1800);
            yield return new Interval<int>(0230, 0240);
            yield return new Interval<int>(0530, 0540);
            yield return new Interval<int>(2330, 2400);
            yield return new Interval<int>(0700, 0800);
            yield return new Interval<int>(0900, 1000);
            yield return new Interval<int>(0000, 0100);
            yield return new Interval<int>(0540, 0700);
            yield return new Interval<int>(1800, 2130);
            yield return new Interval<int>(2130, 2131);
            yield return new Interval<int>(0200, 0230);
        }
        
        private static IEnumerable TestCases {
            get {
                yield return new TestCaseData(new Interval<int>(2000,2300)).Returns(2);
                yield return new TestCaseData(new Interval<int>(0000, 0100)).Returns(2);
                yield return new TestCaseData(new Interval<int>(0000, 0000)).Returns(1);
                yield return new TestCaseData(new Interval<int>(0100, 0100)).Returns(2);
                yield return new TestCaseData(new Interval<int>(1000, 1100)).Returns(1);
                yield return new TestCaseData(new Interval<int>(1030, 1400)).Returns(1);
                yield return new TestCaseData(new Interval<int>(0150, 0155)).Returns(0);
                yield return new TestCaseData(new Interval<int>(2132, 2133)).Returns(0);
                yield return new TestCaseData(new Interval<int>(1030, 1350)).Returns(0);
                yield return new TestCaseData(new Interval<int>(0000, 2359)).Returns(13);
            }
        }

        [Test, TestCaseSource("TestCases")]
        public int Shall_the_result_be_correct_for_an_interval_that_has_been_built_in_order(Interval<int> value) {
            var tree = CreateTree(TestEntries().OrderBy(interval => interval.Start));
            return tree
                .Search(value)
                .Count();
        }

        [Test, TestCaseSource("TestCases")]
        public int Shall_the_result_be_correct_for_an_interval_that_has_been_built_in_reverse_order(Interval<int> value) {
            var tree = CreateTree(TestEntries().OrderBy(interval => interval.Start).Reverse());
            return tree
                .Search(value)
                .Count();
        }

        [Test, TestCaseSource("TestCases")]
        public int Shall_the_result_be_correct_for_an_interval_that_has_been_built_in_unsorted_order(Interval<int> value) {
            var tree = CreateTree(TestEntries());
            return tree
                .Search(value)
                .Count();
        }

        private static IntervalTree<int> CreateTree(IEnumerable<Interval<int>> entries) {
            var tree = new IntervalTree<int>();

            foreach(var interval in entries) {
                tree.Add(interval);
            }

            return tree;
        }
    }
}