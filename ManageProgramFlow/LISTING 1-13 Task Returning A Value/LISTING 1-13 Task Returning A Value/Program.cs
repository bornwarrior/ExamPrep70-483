using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_13_Task_Returning_A_Value
{
    class Program
    {
        public static int CalculateResult()
        {
            Console.WriteLine("Work Starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work Finished");
            return 99;
        }
        static void Main(string[] args)
        {
            Task<int> task = Task.Run(() =>
            {
                return CalculateResult();
            });

            Console.WriteLine(task.Result);
            Console.WriteLine("Finished processing. Press a key to end");
            Console.ReadKey();
        }
    }
}
