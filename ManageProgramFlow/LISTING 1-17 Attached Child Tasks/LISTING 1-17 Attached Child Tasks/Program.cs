using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_17_Attached_Child_Tasks
{
    class Program
    {
        public static void DoChild(object state)
        {
            Console.WriteLine($"Child {state} starting [{Thread.CurrentThread.ManagedThreadId}]");
            Thread.Sleep(2000);
            Console.WriteLine($"Child {state} finished [{Thread.CurrentThread.ManagedThreadId}]");
        }
        static void Main(string[] args)
        {
            var parent = Task.Factory.StartNew(() =>
           {
               Console.WriteLine($"Parent Starts [{Thread.CurrentThread.ManagedThreadId}]");

               for (int i = 0; i < 10; i++)
               {
                   int taskNo = i;
                   Task.Factory.StartNew(
                       (x) => DoChild(x), //lambda expresson
                                taskNo, // state object
                                TaskCreationOptions.AttachedToParent);
               }
               Console.WriteLine($"Parent Done[{Thread.CurrentThread.ManagedThreadId}]");
           });

            parent.Wait();

            Console.WriteLine($"Parent finished. Press a key to end.[{Thread.CurrentThread.ManagedThreadId}]");
            Console.ReadKey();

        }
    }
}
