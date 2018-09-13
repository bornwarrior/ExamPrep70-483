using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_11_Create_a_task
{
    class Program
    {
        public static void DoWork()
        {
            Console.WriteLine($"Work Starting ID: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
            Console.WriteLine($"Work Finshed ID: {Thread.CurrentThread.ManagedThreadId}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Main Running ID: {Thread.CurrentThread.ManagedThreadId}");
            Task newTask = new Task(() => DoWork());
            newTask.Start();
            Console.WriteLine($"Main Thread Continue.. ID: {Thread.CurrentThread.ManagedThreadId}");
            newTask.Wait();
            Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId}");

            Task newTask2 = Task.Run(() => DoWork());
            newTask2.Wait();
        }
    }
}
