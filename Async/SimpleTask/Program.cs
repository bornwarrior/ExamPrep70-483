using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTask
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Repititions = 10000;

            //hot async task control will return 
            //and go to for
            Task task = Task.Run(() =>
              {
                  for (int i = 0; i < Repititions; i++)
                  {
                      Console.Write("-");
                  }
              });

            for (int count = 0; count < Repititions; count++)
            {
                Console.Write("+");
            }

            task.Wait();

            Console.ReadKey();
        }

    }
}
