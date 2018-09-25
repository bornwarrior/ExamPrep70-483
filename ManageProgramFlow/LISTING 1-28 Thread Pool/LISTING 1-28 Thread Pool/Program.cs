using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LISTING_1_28_Thread_Pool
{
    class Program
    {
        static void DoWork(object state)
        {
            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]Doing work: {state}");
            Thread.Sleep(500);
            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]Work Finished {state}");
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 50; i++)
            {
                int stateNumber = i;
                ThreadPool.QueueUserWorkItem(satate => DoWork(stateNumber));
            }
            Console.ReadKey();
        }
    }
}
