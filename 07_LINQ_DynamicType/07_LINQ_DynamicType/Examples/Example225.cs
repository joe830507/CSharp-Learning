using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example225 : IDemonstration
    {
        Course[] courses =
        {
            new Course{ID = 301,Name = "HTML 5"},
            new Course{ID = 302,Name = "C++"},
            new Course{ID = 303,Name = "ASP.NET Core"},
            new Course{ID = 304,Name = "PHP"},
            new Course{ID = 305,Name = "Javascript"},
        };
        Student[] students =
        {
            new Student {Name = "A", CourseID = 304},
            new Student {Name = "B", CourseID = 303},
            new Student {Name = "C", CourseID = 303},
            new Student {Name = "D", CourseID = 302},
            new Student {Name = "E", CourseID = 302},
        };
        public void display()
        {
            var qr = from s in students
                     join c in courses on s.CourseID equals c.ID
                     select (StudentName: s.Name, CourseName: c.Name);
            foreach (var x in qr)
            {
                System.Console.WriteLine($"{x.StudentName} - <{x.CourseName}>");
            }
        }

        public class Course
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        public class Student
        {
            public string Name { get; set; }
            public int CourseID { get; set; }
        }
    }
}
