using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace LISTING_1_20_Threads_And_Lambda
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Thread thread = new Thread(() =>
            {
                Console.WriteLine($"Hello from the thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
            });

            thread.Start();
            Console.WriteLine($"Main Press any key to end {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadKey();
        }
    }
}
