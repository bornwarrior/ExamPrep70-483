using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1._1Parallel_Invoke
{
    class Program
    {
        static void Task1()
        {
            Console.WriteLine($"Task 1 starting [{Thread.CurrentThread.ManagedThreadId}]");
            Thread.Sleep(2000);
            Console.WriteLine($"Task 1 ending [{Thread.CurrentThread.ManagedThreadId}]");
        }

        static void Task2()
        {
            Console.WriteLine($"Task 2 starting [{Thread.CurrentThread.ManagedThreadId}]");
            Thread.Sleep(1000);
            Console.WriteLine($"Task 2 Ending [{Thread.CurrentThread.ManagedThreadId}]");
        }
        static void Main(string[] args)
        {
            Parallel.Invoke(() => Task1(), () => Task2());
            Console.WriteLine($"Main Finished procesing. Press a key to end [{Thread.CurrentThread.ManagedThreadId}]");
            Console.ReadKey();
        }
    }
}
