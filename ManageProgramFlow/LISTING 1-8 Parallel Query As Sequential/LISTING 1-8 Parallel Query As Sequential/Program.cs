using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_1_8_Parallel_Query_As_Sequential
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

           // Console.WriteLine($"------");

            var result = (from person in people.AsParallel()
                          where person.City == "Seattle"
                          orderby (person.Name)
                          select new
                          {
                              Name = person.Name
                          }).AsSequential().Take(4);

            foreach (var person in result)
            {
                Console.WriteLine(person.Name);
            }

            Console.WriteLine("----------------ForAll--------");
            //ForAll
            var result2 = from person in
                 people.AsParallel()
                         where person.City == "Seattle"
                         select person;
            result2.ForAll(person => Console.WriteLine(person.Name));

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();

        }
    }
}
