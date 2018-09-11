﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_2_ParallelForEach
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = Enumerable.Range(0, 500);
            Parallel.ForEach(items, item => { WorkOnItem(item); });

            Console.WriteLine("Finished processing. Press and a key to end");
            Console.ReadKey();
        }

        private static void WorkOnItem(object item)
        {
            Console.WriteLine($"Started working on: {item}");
            Thread.Sleep(100);
            Console.WriteLine($"Finished working on: {item}");
        }

    }
}
