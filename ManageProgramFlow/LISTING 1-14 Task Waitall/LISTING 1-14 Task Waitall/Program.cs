using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_14_Task_Waitall
{
    class Program
    {
        public static void DoWork(int i)
        {
            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Task {i} starting");
            Thread.Sleep(2000);
            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Task {i} finished");
        }

        static void Main(string[] args)
        {
            int taskCount = 10;
            Task[] Tasks = new Task[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                int taskNum = i;
                Tasks[i] = Task.Run(() => DoWork(taskNum));
            }
            Task.WaitAll(Tasks);
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();

        }
    }
}
