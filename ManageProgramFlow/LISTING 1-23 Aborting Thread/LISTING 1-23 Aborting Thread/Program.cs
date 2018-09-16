using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LISTING_1_23_Aborting_Thread
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread tickThread = new Thread(() =>
           {
               while (true)
               {
                   Console.WriteLine("Tick");
                   Thread.Sleep(1000);
               }
           });

            tickThread.Start();
            Console.WriteLine("Press a key to stop the clock");
            Console.ReadKey();
            tickThread.Abort();
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }
    }
}
