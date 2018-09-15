using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_18_Creating_Threads
{
    class Program
    {
        static void ThreadHello()
        {
            Console.WriteLine($"Hello from the thread Id: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Main Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            Thread thread = new Thread(ThreadHello);
            thread.Start();
        }
    }
}
