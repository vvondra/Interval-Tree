using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntervalTree;

namespace ZapocetADSI_Interval
{
    class Program
    {
        static void Main(string[] args)
        {

            InsertionComplexityTest(100000, 1000);
            /*
            var tree = new IntervalTree<long>();

            int[] starts = new int[] { 16, 8, 25, 0, 26, 17, 15, 6, 19, 5};
            int[] ends = new int[] { 21, 9, 30, 3, 26, 19, 23, 10, 20, 8 };
            
            int j = 0;
           // for (int j = 0; j < 10; j++) {
                for (int i = 0; i < starts.Length; i++) {
                    tree.Add(new Interval<long>(starts[i] + j, ends[i] + j));

                    foreach (Interval<long> hi in tree) {
                        Console.Write(hi.ToString() + " ");
                    }
                    Console.WriteLine();
                }
         //   }

                tree.Remove(new Interval<long>(6, 10));
                foreach (Interval<long> hi in tree) {
                    Console.Write(hi.ToString() + " ");
                }
            */
            Console.WriteLine();
            
        }

        static void InsertionComplexityTest(int n, int steps)
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

                sw.Restart();
                // Delete half of the inserted
                for (int k = 0; k < i; k++) {
                    int index = randGen.Next(0, i);
                    var xafu = new Interval<int>(vals[index], ends[index]);
                    tree.Remove(xafu);
                    //Console.WriteLine("Just delted {0}", xafu);
                }
                sw.Stop();

                Console.WriteLine("Delete\t{0}\t    {1}", i, sw.ElapsedMilliseconds);
                Console.WriteLine("Memory after delete\t{0}", GC.GetTotalMemory(true));
                Console.Error.WriteLine("\nTesting {0}", i);
            }
        }
    }
}
