using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LISTING_1_26_ThreadLocal
{
    class Program
    {
        public static ThreadLocal<Random> RandomGenerator =
            new ThreadLocal<Random>(() =>
           {
               return new Random(2);
           });

        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
           {
               for (int i = 0; i < 5; i++)
               {
                   Console.WriteLine($"t1[{Thread.CurrentThread.ManagedThreadId}]:{RandomGenerator.Value.Next(10)}");

               }
           });

            Thread t2 = new Thread(() =>
           {
               for (int i = 0; i < 5; i++)
               {
                   Console.WriteLine($"t2[{Thread.CurrentThread.ManagedThreadId}] :{RandomGenerator.Value.Next(10)}");
               }
           });

            t1.Start();
            t2.Start();
            Console.ReadKey();
        }
    }
}
