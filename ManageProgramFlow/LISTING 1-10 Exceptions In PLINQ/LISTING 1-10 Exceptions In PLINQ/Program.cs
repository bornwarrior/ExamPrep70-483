using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_1_10_Exceptions_In_PLINQ
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
                new Person("Larry",""),
                new Person("Gordon","Hull"),
                new Person("Henry","Seattle"),
                new Person("Issac","Seattle"),
                new Person("James","London")
             };

            try
            {

                var result = from person in
                        people.AsParallel()
                             where CheckCity(person.City)
                             select person;

                result.ForAll(person => Console.WriteLine(person.Name));
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerExceptions.Count + " exceptions.");
            }

            //var result = from person in
            //       people.AsParallel()
            //             where CheckCity(person.City)
            //             select person;

            //result.ForAll(person => Console.WriteLine(person.Name));

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }

        private static bool CheckCity(string city)
        {
            if (String.IsNullOrWhiteSpace(city))
                throw new ArgumentException(city);

            return city == "Seattle";
        }
    }
}
