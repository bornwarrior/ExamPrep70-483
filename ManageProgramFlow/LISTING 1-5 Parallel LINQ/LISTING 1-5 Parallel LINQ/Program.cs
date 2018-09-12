using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_1_5_Parallel_LINQ
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public string City { get; set; }

            public Person(string name, string city)
            {
                Name = name;
                City = city;
            }
            public Person()
            {

            }
        }
        static void Main(string[] args)
        {
            Person[] people = new Person[]
            {
                new Person {Name = "Alan", City = "Hull"},
                new Person {Name = "Berly", City = "Seattle"},
                new Person {Name = "Charles", City = "London"},
                new Person("Eddy", "Paris"),
                new Person("Fred","Berline"),
                new Person("Gordon","Hull"),
                new Person("Henry","Seattle"),
                new Person("Issac","Seattle"),
                new Person("James","London")                
            };

            Console.WriteLine();
            //it examins the query and decide if execuing using a
            //parellel verson
            var result = from person in people.AsParallel()
                         where person.City == "Seattle"
                         select person;

            foreach (var person in result)
            {
                Console.WriteLine(person.Name);
            }

            Console.WriteLine();
            //force parellelisam
            result = from person in people.AsParallel().
               WithDegreeOfParallelism(4).
               WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                     where person.City == "Seattle"
                     select person;

            foreach (var person in result)
            {
                Console.WriteLine(person.Name);
            }

            //Preseve the original order
            Console.WriteLine();
            Console.WriteLine("Forcing the order...");
            var result1 = from peson in people.AsParallel().AsOrdered()
                     where peson.City == "Seattle"
                     select peson;

            foreach (var person in result)
            {
                Console.WriteLine(person.Name);
            }

            Console.WriteLine("Finished Processing. Press a key to end.");
            Console.ReadKey();

        }
    }
}
