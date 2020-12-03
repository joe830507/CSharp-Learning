using System.Linq;
using System.Text;

namespace _07_LINQ_DynamicType
{
    public class Example220 : IDemonstration
    {
        Student[] stus =
        {
            new Student
            {
                ID = 201,
                Name = "A",
                Course = "C#"
            },
            new Student
            {
                ID = 202,
                Name = "B",
                Course = "C++"
            },
            new Student
            {
                ID = 203,
                Name = "C",
                Course = "Java"
            },
            new Student
            {
                ID = 204,
                Name = "D",
                Course = "C#"
            },
            new Student
            {
                ID = 205,
                Name = "E",
                Course = "Python"
            },
            new Student
            {
                ID = 206,
                Name = "F",
                Course = "Golang"
            },
            new Student
            {
                ID = 207,
                Name = "G",
                Course = "Java"
            },
            new Student
            {
                ID = 208,
                Name = "H",
                Course = "C++"
            }
        };
        public void display()
        {
            var result = stus.GroupBy(s => s.Course,
                (gKey, gItems) => (GroupKey: gKey, ItemCount: gItems.Count(), Items: gItems));
            System.Console.WriteLine("Information:\n");
            StringBuilder sb = new StringBuilder();
            foreach (var g in result)
            {
                sb.AppendFormat("Course:{0}\n", g.GroupKey);
                sb.AppendFormat("Number:{0}\n", g.ItemCount);
                sb.AppendLine("List:");
                foreach (var s in g.Items)
                {
                    sb.AppendFormat("    {0} - {1}\n", s.ID, s.Name);
                }
                sb.AppendLine();
            }
            System.Console.WriteLine(sb);
        }

        public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Course { get; set; }
        }
    }
}
