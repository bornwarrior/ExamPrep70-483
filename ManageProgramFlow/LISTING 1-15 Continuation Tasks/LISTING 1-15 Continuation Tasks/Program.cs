using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_15_Continuation_Tasks
{
    class Program
    {
        public static void HelloTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Hello");
        }
        public static void WorldTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("World");
        }
        static void Main(string[] args)
        {
            Task task = Task.Run(() => HelloTask());
            task.ContinueWith((prevTask) => WorldTask());

            Task task2 = Task.Run(() => WorldTask2());

            task2.ContinueWith((prevTask) => HelloTask(), TaskContinuationOptions.
                                OnlyOnRanToCompletion);
            task2.ContinueWith((prevTask) => ExceptionTask(), TaskContinuationOptions.OnlyOnFaulted);

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }

        private static void WorldTask2()
        {
            Console.WriteLine("World2");
            throw new NotImplementedException();
        }

        private static void ExceptionTask()
        {
            Console.WriteLine("World2Got Excetpoin");
        }
    }
}
