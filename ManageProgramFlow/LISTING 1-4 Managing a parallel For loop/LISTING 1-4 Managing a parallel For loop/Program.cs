using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_4_Managing_a_parallel_For_loop
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = Enumerable.Range(0, 500).ToArray();

            ParallelLoopResult result = Parallel.For(0, items.Count(), 
            (int i, ParallelLoopState loopState) =>
            {
                if (i == 200)
                    loopState.Stop(); //break allow previous iterations to complete

                WorkOnItem(items[i]);
            });
        }

        private static void WorkOnItem(object item)
        {
            Console.WriteLine($"Start working on {item} [{Thread.CurrentThread.ManagedThreadId}]");
            Thread.Sleep(100);
            Console.WriteLine($"Finished working on {item} [{Thread.CurrentThread.ManagedThreadId}]");
        }
    }
}
