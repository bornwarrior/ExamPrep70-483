using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_3_ParallelFor
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = Enumerable.Range(0, 500).ToArray();
            Parallel.For(0, items.Length, i =>
             {
                 WorkOnItem(items[i]);
             });
            Console.WriteLine("Main Finished Processing. Press a key to end.");
            Console.ReadKey();
        }

        private static void WorkOnItem(object item)
        {
            Console.WriteLine($"Start working on {item} [{Thread.CurrentThread.ManagedThreadId}]");
            Thread.Sleep(100);
            Console.WriteLine($"Finished working on {item} [{Thread.CurrentThread.ManagedThreadId}]");
        }
    }
}
