using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example224 : IDemonstration
    {
        Employee[] emps =
        {
            new Employee{Name = "A",Department="DepartC"},
            new Employee{Name = "B",Department="DepartA"},
            new Employee{Name = "C",Department="DepartB"},
            new Employee{Name = "D",Department="DepartA"},
            new Employee{Name = "E",Department="DepartD"},
            new Employee{Name = "F",Department="DepartG"},
            new Employee{Name = "G",Department="DepartB"},
            new Employee{Name = "H",Department="DepartC"}
        };
        public void display()
        {
            var q = from e in emps
                    group e by e.Department;
            foreach (var g in q)
            {
                System.Console.WriteLine("{0}:", g.Key);
                foreach (var emp in g)
                {
                    System.Console.WriteLine("    {0}", emp.Name);
                }
                System.Console.WriteLine();
            }
        }

        public class Employee
        {
            public string Name { get; set; }
            public string Department { get; set; }
        }
    }
}
