using System.Collections.Generic;
using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example213 : IDemonstration
    {
        List<Employee> emps = new List<Employee>
        {
            new Employee{Eid = 1,Ename = "A",Eage = 28},
            new Employee{Eid = 2,Ename = "B",Eage = 42},
            new Employee{Eid = 3,Ename = "C",Eage = 27},
            new Employee{Eid = 4,Ename = "D",Eage = 45},
            new Employee{Eid = 5,Ename = "E",Eage = 36},
            new Employee{Eid = 6,Ename = "F",Eage = 46},
            new Employee{Eid = 7,Ename = "G",Eage = 51}
        };
        public void display()
        {
            var result = emps.OrderByDescending(e => e.Eage);
            System.Console.WriteLine("Employees' age is ordered desc:");
            foreach (var emp in result)
            {
                System.Console.WriteLine($"Eid:{emp.Eid},Ename:{emp.Ename},Eage:{emp.Eage}");
            }
        }

        public class Employee
        {
            public int Eid { get; set; }
            public string Ename { get; set; }
            public int Eage { get; set; }
        }
    }
}
