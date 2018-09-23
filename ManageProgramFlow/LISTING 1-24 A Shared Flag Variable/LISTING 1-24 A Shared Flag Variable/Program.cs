using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_24_A_Shared_Flag_Variable
{
    class Program
    {
        static bool tickRunning; //flag variable

        static void Main(string[] args)
        {
            tickRunning = true;

            Thread tickThread = new Thread(() =>
           {
               while (tickRunning)
               {
                   Console.WriteLine("Tick");
                   Thread.Sleep(1000);
               }
           });

            tickThread.Start();
            Console.WriteLine("Press a key to stop the clock");
            Console.ReadKey();
            tickRunning = false;
            Console.WriteLine("Press a key to read");
            Console.ReadKey();
                
         }


    }
}
