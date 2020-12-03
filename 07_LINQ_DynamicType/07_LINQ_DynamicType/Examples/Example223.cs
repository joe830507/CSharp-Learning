using System;
using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example223 : IDemonstration
    {
        DateTime[] dts =
        {
            new DateTime(2016,6,12),
            new DateTime(2018,4,13),
            new DateTime(2001,9,21)
        };

        Person[] parr =
        {
            new Person{ID = 1,Name = "A",Age = 23},
            new Person{ID = 2,Name = "B",Age = 30},
            new Person{ID = 3,Name = "C",Age = 31}
        };
        public void display()
        {
            var q1 = from d in dts
                     select d.ToShortDateString();
            foreach (var d in q1)
            {
                Console.WriteLine(d);
            }
            Console.WriteLine();
            var q2 = from p in parr
                     select new
                     {
                         PersonID = p.ID,
                         PersonName = p.Name
                     };
            foreach (var p in q2)
            {
                Console.WriteLine($"ID:{p.PersonID}, Name:{p.PersonName}");
            }
            Console.WriteLine();
            string s = "abcdef";
            var q3 = from c in s
                     let index = s.IndexOf(c)
                     select (Index: index, Char: c);
            foreach (var i in q3)
            {
                Console.WriteLine($"{i.Index} - '{i.Char}'");
            }
        }

        public class Person
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
