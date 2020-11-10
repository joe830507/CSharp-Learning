using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpLearning
{
    public class CommonExtensions : IDemonstrate
    {
        public void Demonstrate()
        {
            GroupBy();
        }

        public void Add()
        {
            List<WorkItem> works = new List<WorkItem>();
            works.Add(new WorkItem
            {
                ID = 1,
                Desc = "Serial A",
                StartTime = new DateTime(2018, 5, 10, 8, 32, 16),
                EndTime = new DateTime(2018, 5, 13, 14, 20, 0)
            });
            works.Add(new WorkItem
            {
                ID = 2,
                Desc = "Serial B",
                StartTime = new DateTime(2018, 5, 12, 7, 26, 15),
                EndTime = new DateTime(2018, 5, 12, 18, 24, 15)
            });
            works.Add(new WorkItem
            {
                ID = 3,
                Desc = "Serial C",
                StartTime = new DateTime(2018, 5, 17, 9, 45, 0),
                EndTime = new DateTime(2018, 5, 19, 20, 36, 4)
            });
            works.Add(new WorkItem
            {
                ID = 4,
                Desc = "Serial D",
                StartTime = new DateTime(2018, 6, 1, 11, 0, 0),
                EndTime = new DateTime(2018, 6, 4, 16, 34, 0)
            });
            var max = works.Max(w => w.EndTime - w.StartTime);
            Console.WriteLine("{0:%d} Days,{0:%h} hours,{0:%m} mins,{0:%s} seconds", max);
        }
        public void Sum()
        {
            string[] arr = { "effect", "teach", "table", "purpose", "transport" };
            int len = arr.Sum(x => x.Length);
            Console.WriteLine(len);
        }
        public void Contact()
        {
            List<int> list1 = new List<int> { 20, 21, 22 };
            List<int> list2 = new List<int> { 23, 24 };
            var reuslt = list1.Concat(list2);
            Console.WriteLine(string.Join(',', reuslt));
        }
        public void Count()
        {
            RectangleSt[] rects = {
                new RectangleSt { Width = 16.002f, Height = 7f },
                new RectangleSt { Width = 2.5f, Height = 4.77f },
                new RectangleSt { Width = 1.5f, Height = 3.5f },
                new RectangleSt { Width = 6.9f, Height = 12.3f },
                new RectangleSt { Width = 0.8f, Height = 10.22f },
                new RectangleSt { Width = 9.4f, Height = 21.3f },
                new RectangleSt { Width = 6.5f, Height = 32.8f },
            };
            int count = rects.Count(r => (r.Width * r.Height) > 100f);
            Console.WriteLine(count);
        }
        public void OrderByDescending()
        {
            List<Employee> emps = new List<Employee> {
                new Employee {Eid = 1,Ename = "James",Eage = 28 },
                new Employee {Eid = 2,Ename = "Duedly",Eage = 35 },
                new Employee {Eid = 3,Ename = "Larry",Eage = 22 },
                new Employee {Eid = 4,Ename = "Mike",Eage = 28 },
                new Employee {Eid = 5,Ename = "Michael",Eage = 50 },
            };
            var result = emps.OrderByDescending(e => e.Eage);
            foreach (var e in result)
            {
                Console.WriteLine("{0},{1},{2}", e.Eid, e.Ename, e.Eage);
            }
        }
        public void Distinct()
        {
            int[] nums = { 100, 200, 100, 2, 3, 5, 5, 23, 12, 438 };
            var result = nums.Distinct();
            result = result.OrderBy(e => e);
            Console.WriteLine(string.Join(',', result));
        }
        public void Except()
        {
            uint[] list1 = { 1, 2, 3, 4, 5, 6 };
            uint[] list2 = { 1, 2, 7, 4, 8, 6 };
            IEnumerable<uint> result1 = list1.Except(list2);
            IEnumerable<uint> result2 = list2.Except(list1);
            Console.WriteLine(string.Join(' ', result1));
            Console.WriteLine(string.Join(' ', result2));
        }
        public void FirstAndFirstOrDefault()
        {
            IEnumerable<long> empty = Enumerable.Empty<long>();
            try
            {
                long x = empty.First();
                Console.WriteLine("X:First element:{0}", x);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            long y = empty.FirstOrDefault();
            Console.WriteLine("Y:First element:{0}", y);
        }
        public void Single()
        {
            List<int> list = new List<int> { 15 };
            // It can be only used when the length of list is 1.
            // If the length is bigger than one, some error will take place.
            int x = list.Single();
            Console.WriteLine(x);
        }
        public void Where()
        {
            ContactWhere[] contacts = {
                new ContactWhere{
                ContactId = 6501,
                ContactName = "Hooo",
                ContactEmail = "sss@test.org",
                ContactPhoneNo="23293012"
                },
                new ContactWhere{
                ContactId = 6502,
                ContactName = "James",
                ContactEmail = "123@test.org",
                ContactPhoneNo="13693012"
                },
                new ContactWhere{
                ContactId = 6503,
                ContactName = "Jordan",
                ContactEmail = "asdasd@test.org",
                ContactPhoneNo="13593012"
                },
                new ContactWhere{
                ContactId = 6504,
                ContactName = "Rururu",
                ContactEmail = "wecxa@test.org",
                ContactPhoneNo="13693012"
                },
                new ContactWhere{
                ContactId = 6505,
                ContactName = "Ssadwq",
                ContactEmail = "asdwe@test.org",
                ContactPhoneNo="1232693012"
                }
            };
            var result = contacts.Where(c => c.ContactPhoneNo.StartsWith("136") || c.ContactPhoneNo.StartsWith("135"));
            foreach (var c in result)
            {
                Console.WriteLine(c.ContactName);
            }
        }
        public void ToDictionary()
        {
            Production2[] prds = {
                new Production2{
                    PID = 4007,
                    Name = "Product1",
                    Size = 123.45f,
                    Quantity = 65
                },
                new Production2{
                    PID = 4008,
                    Name = "Product2",
                    Size = 423.45f,
                    Quantity = 222
                },
                new Production2{
                    PID = 4009,
                    Name = "Product3",
                    Size = 723.45f,
                    Quantity = 111
                },
            };
            IDictionary<int, string> dic = prds.ToDictionary(p => p.PID, p => p.Name);
            foreach (var kp in dic)
            {
                Console.WriteLine("{0} - {1}", kp.Key, kp.Value);
            }
        }
        public void GroupBy()
        {
            Student[] stus = {
                new Student{
                    ID = 201,
                    Name = "Wang",
                    Course = "C"
                },
                new Student{
                    ID = 202,
                    Name = "Joe",
                    Course = "C++"
                },
                new Student{
                    ID = 203,
                    Name = "Mary",
                    Course = "C++"
                },
                new Student{
                    ID = 204,
                    Name = "Weng",
                    Course = "C#"
                },
                new Student{
                    ID = 205,
                    Name = "Lu",
                    Course = "C"
                },
                new Student{
                    ID = 206,
                    Name = "Harden",
                    Course = "C"
                },
                new Student{
                    ID = 207,
                    Name = "Su",
                    Course = "C#"
                },
                new Student{
                    ID = 208,
                    Name = "Lin",
                    Course = "Delphi"
                }
            };
            var result = stus.GroupBy(s => s.Course,
                    (gKey, gItems) =>
                    (
                        GroupKey: gKey,
                        ItemCount: gItems.Count(),
                        Items: gItems
                     )
                );
            StringBuilder sb = new StringBuilder();
            foreach (var g in result)
            {
                sb.AppendFormat("Course:{0}\n", g.GroupKey);
                sb.AppendFormat(" People:{0}\n", g.ItemCount);
                sb.AppendLine(" list:");
                foreach (var s in g.Items)
                {
                    sb.AppendFormat("  {0} - {1}\n", s.ID, s.Name);
                }
            }
            Console.WriteLine(sb);
        }
    }
}
