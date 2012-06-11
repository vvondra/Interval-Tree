using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntervalTree;
using System.Diagnostics;
namespace ZapocetADSI_Interval
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 1 && args[0] == "example") {
                ConsoleTest();
            } else {
                BasicTests();
            }
        }

        static void ConsoleTest()
        {
            string line;
            var tree = new IntervalTree<int>();

            Console.WriteLine("Enter intervals as \"p q\" to add to tree, each on a new line, end with 0:");
            line = Console.ReadLine();
            while (line != "0") {
                string[] bits = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (bits.Length != 2) {
                    break;
                }

                int start, end;
                if (Int32.TryParse(bits[0], out start) && Int32.TryParse(bits[1], out end)) {
                    tree.Add(new Interval<int>(start, end));
                } else {
                    break;
                }

                line = Console.ReadLine();
            }
            foreach (var n in tree) {
                Console.Write("{0} ", n);
            }
            
            Console.WriteLine();

            Console.WriteLine("Enter intervals as \"p q\" to delete from tree, each on a new line, end with 0:");
            line = Console.ReadLine();
            while (line != "0") {
                string[] bits = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (bits.Length != 2) {
                    break;
                }

                int start, end;
                if (Int32.TryParse(bits[0], out start) && Int32.TryParse(bits[1], out end)) {
                    tree.Remove(new Interval<int>(start, end));
                } else {
                    break;
                }

                line = Console.ReadLine();
            }
            foreach (var n in tree) {
                Console.Write("{0} ", n);
            }
            Console.WriteLine();
            Console.WriteLine("Enter intervals as \"p q\", first overlapping interval will be found, end with 0:");
            line = Console.ReadLine();
            while (line != "0") {
                string[] bits = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (bits.Length != 2) {
                    break;
                }

                int start, end;
                if (Int32.TryParse(bits[0], out start) && Int32.TryParse(bits[1], out end)) {
                    try {
                        Console.WriteLine(tree.SearchFirstOverlapping(new Interval<int>(start, end)));
                    } catch (KeyNotFoundException e) {
                        Console.WriteLine("Not found");
                    }
                } else {
                    break;
                }

                line = Console.ReadLine();
            }

            Console.ReadLine();

        }

        static void BasicTests()
        {
            var tree = createCormenTree();

            Debug.Assert(new Interval<long>(0, 3).Equals(tree.SearchFirstOverlapping(new Interval<long>(2, 4))));

            Debug.Assert(
                    tree.Search(18).Count == 3 // <17, 19>, <16, 21>, <15, 23>
            );

            Debug.Assert(
                    tree.Search(12).Count == 0
            );

            Debug.Assert(
                    tree.Search(-5).Count == 0
            );

            foreach (var n in tree) {
                Console.Write("{0} ", n);
            }
            Console.WriteLine();

            // Remove root (two children)
            tree.Remove(new Interval<long>(16, 21));
            foreach (var n in tree) {
                Console.Write("{0} ", n);
            }
            Console.WriteLine();

            // Remove root (leaf)
            tree.Remove(new Interval<long>(26, 26));
            foreach (var n in tree) {
                Console.Write("{0} ", n);
            }
            Console.WriteLine();

            System.Threading.Thread.Sleep(3000);

            // Test a lot of random numbers for tree consinstency and speed
            LargeDatasetTest(60000, 1000);
        }

        /// <summary>
        /// Tree from Introduction to algorithms
        /// </summary>
        /// <returns></returns>
        static IntervalTree<long> createCormenTree()
        {
            var tree = new IntervalTree<long>();

            int[] starts = new int[] { 16, 8, 25, 0, 26, 17, 15, 6, 19, 5 };
            int[] ends = new int[] { 21, 9, 30, 3, 26, 19, 23, 10, 20, 8 };

            for (int i = 0; i < starts.Length; i++) {
                tree.Add(new Interval<long>(starts[i], ends[i]));
            }

            return tree;
        }

        static void LargeDatasetTest(int n, int steps)
        {
            Random randGen = new Random();
            int[] vals = new int[n];
            int[] ends = new int[n];
            for (int i = 0; i < n; i++) {
                vals[i] = randGen.Next(1, n - 1);
                ends[i] = randGen.Next(vals[i], n);
            }

            for (int i = 0; i < n; i += steps) {
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();

                var tree = new IntervalTree<int>();
                for (int j = 0; j < i; j++) {
                    tree.Add(new Interval<int>(vals[j], ends[j]));
                }

                Console.WriteLine("Insert\t{0}\t    {1}", i, sw.ElapsedMilliseconds);
                Console.WriteLine("Memory after insert\t{0}", GC.GetTotalMemory(true));

                sw.Reset();
                sw.Start();
                // Delete half of the inserted
                for (int k = 0; k < i; k++) {
                    int index = randGen.Next(0, i);
                    var xafu = new Interval<int>(vals[index], ends[index]);
                    tree.Remove(xafu);
                    //Console.WriteLine("Just delted {0}", xafu);
                }
                sw.Stop();

                Console.WriteLine("Delete\t{0}\t    {1}", i, sw.ElapsedMilliseconds);

                // Does not seem to track memory correctly on Mono (as if no GC)
                // On Windows, memory footprint is cca. 50% after delete, as expected
                Console.WriteLine("Memory after delete\t{0}", GC.GetTotalMemory(true));
                Console.Error.WriteLine("\nTesting {0}", i);
            }
        }
    }
}
