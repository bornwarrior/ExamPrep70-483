using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LISTING_1_27_Thread_context
{
    class Program
    {
        static void DisplayThread(Thread t)
        {
            Console.WriteLine($"Name: {t.Name}");
            Console.WriteLine($"Culture: {t.CurrentCulture}");
            Console.WriteLine($"Priority: {t.Priority}");
            Console.WriteLine($"Execution Context: {t.ExecutionContext}");
            Console.WriteLine($"IsBackground? :{t.IsBackground}");
            Console.WriteLine($"IsPool?: {t.IsThreadPoolThread}");
        }
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main Thread";
            DisplayThread(Thread.CurrentThread);
        }
    }
}
