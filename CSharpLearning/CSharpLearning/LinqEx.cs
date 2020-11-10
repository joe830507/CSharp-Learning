using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpLearning
{
    public class LinqEx : IDemonstrate
    {
        public void Demonstrate()
        {
            AddLiteralToPrefix();
        }

        public void SelectAndFrom()
        {
            int[] arr = { 12, 15, 35, 32, 45, 77, 80, 63 };
            var res = from n in arr
                      where (n % 5) == 0
                      select n;
            System.Console.WriteLine(string.Join(',', res));
        }
        public void OrderBy()
        {
            double[] srcs = {
                17.5d,42.33d,100d,130d,256d,312.14d,96.656d
            };
            var q = from x in srcs
                    let s = Math.Sqrt(x)
                    orderby s descending
                    select (x, s);
            foreach (var n in q)
            {
                Console.WriteLine("{0,-10} -> {1,-16}", n.x, n.s);
            }
        }
        public void ReturnContent()
        {
            DateTime[] dts =
            {
                new DateTime(2016,6,12),
                new DateTime(2018,4,13),
                new DateTime(2001,9,21)
            };
            var q1 = from d in dts
                     select d.ToShortDateString();
            foreach (var d in q1)
            {
                Console.WriteLine(d.ToString());
            }
            APerson[] parr =
            {
                new APerson{ ID = 1, Name = "Hu", Age = 23 },
                new APerson{ ID = 2, Name = "Allan", Age = 30 },
                new APerson{ ID = 3, Name = "Larry", Age = 31 }
            };
            var q2 = from p in parr
                     select new
                     {
                         PersonID = p.ID,
                         PersonName = p.Name
                     };
            foreach (var p in q2)
            {
                Console.WriteLine("{0} - {1}", p.PersonID, p.PersonName);
            }
            string s = "abcdef";
            var q3 = from c in s
                     let index = s.IndexOf(c)
                     select (Index: index, Char: c);
            foreach (var i in q3)
            {
                Console.WriteLine($"{i.Index} - {i.Char}");
            }
        }
        public void Grouping()
        {
            AEmployee[] emps =
            {
                new AEmployee{ Name= "Huang",Department = "A" },
                new AEmployee{ Name= "James",Department = "B" },
                new AEmployee{ Name= "Joe",Department ="C" },
                new AEmployee{ Name= "Larry",Department ="D" },
                new AEmployee{ Name= "Henry",Department ="E" },
                new AEmployee{ Name= "Julia",Department ="A" },
                new AEmployee{ Name= "Lily",Department ="B" },
                new AEmployee{ Name= "Yulia",Department ="A" },
                new AEmployee{ Name= "Lulu",Department ="C" }
            };
            var q = from e in emps
                    group e by e.Department;
            foreach (var g in q)
            {
                Console.WriteLine("{0}", g.Key);
                foreach (var emp in g)
                {
                    Console.WriteLine("   {0}", emp.Name);
                }
                Console.WriteLine();
            }
        }
        public void JoinQuery()
        {
            Course[] courses =
            {
                new Course{ ID = 301, Name = "HTML 5" },
                new Course{ ID = 302, Name = "C++" },
                new Course{ ID = 303, Name = "ASP.NET Core" },
                new Course{ ID = 304, Name = "PHP" },
                new Course{ ID = 305, Name = "Javascript" }
            };

            AStudent[] students =
            {
                new AStudent{ Name = "Li", CourseID = 304 },
                new AStudent{ Name = "Luuu", CourseID = 303 },
                new AStudent{ Name = "Laaaa", CourseID = 303 },
                new AStudent{ Name = "Lwwww", CourseID = 302 },
                new AStudent{ Name = "Ltttt", CourseID = 302 },
            };

            var qr = from s in students
                     join c in courses on s.CourseID equals c.ID
                     select (StudentName: s.Name, CourseName: c.Name);
            foreach (var x in qr)
            {
                Console.WriteLine($"{x.StudentName} : {x.CourseName}");
            }
        }
        public void PutResultInTryCatch()
        {
            int[] arrsrc = { 1, 4, 8, 32 };
            var q = from x in arrsrc
                    select x / 0;

            try
            {
                foreach (var i in q)
                {
                    Console.WriteLine(i);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DefaultIfEmpty()
        {
            OrderDetails d1 = new OrderDetails
            {
                Amount = 10,
                Price = 2.5M,
                Code = "T-70770"
            };
            OrderDetails d2 = new OrderDetails
            {
                Amount = 12,
                Price = 3.2M,
                Code = "T-70778"
            };

            AOrder o1 = new AOrder
            {
                ID = 1,
                Date = new DateTime(2018, 3, 1),
                State = true,
                Details = d1
            };
            AOrder o2 = new AOrder
            {
                ID = 2,
                Date = new DateTime(2018, 3, 13),
                State = false,
                Details = d2
            };
            AOrder o3 = new AOrder
            {
                ID = 3,
                Date = new DateTime(2018, 3, 18),
                State = true,
                Details = null
            };
            List<AOrder> orders = new List<AOrder> { o1, o2, o3 };
            List<OrderDetails> details = new List<OrderDetails> { d1, d2 };
            var q = from o in orders
                    join d in details on o.Details equals d into g
                    from x in g.DefaultIfEmpty(new OrderDetails { Amount = 0, Price = 0.00M, Code = "Unknown" })
                    select (OrderID: o.ID, Amount: x.Amount, Code: x.Code);
            foreach (var i in q)
            {
                Console.WriteLine("{0,-11}{1,-10}{2,-20}", i.OrderID, i.Amount, i.Code);
            }
        }
        public void ConvertToXMLFile()
        {
            Account[] accs =
            {
                new Account
                {
                    UserID = 1,
                    UserName = "user 1",
                    Password = "123",
                    IsAdmin = false
                },
                new Account
                {
                    UserID = 2,
                    UserName = "user 2",
                    Password = "678",
                    IsAdmin = false
                },
                new Account
                {
                    UserID = 3,
                    UserName = "user 3",
                    Password = "hjk",
                    IsAdmin = true
                }
            };
            var elements = from a in accs
                           select new XElement("account",
                           new XAttribute("user_id", a.UserID),
                           new XAttribute("user_name", a.UserName),
                           new XAttribute("password", a.Password),
                           new XAttribute("is_admin", a.IsAdmin)
                           );
            XElement root = new XElement("accounts", elements);
            Console.WriteLine(root);
            XDocument doc = new XDocument(root);
        }
        public void Resort()
        {
            string[] arrsrc =
            {
                "at","act","market","false","also","alt","bee","back","book",
                "build","face","full","fish","food","find","meet","make","moo",
                "muklek"
            };
            var q = from s in arrsrc
                    group s by s[0].ToString().ToUpper() into g
                    orderby g.Key
                    let nq = (from w in g
                              orderby w
                              select w)
                    select (Key: g.Key, Items: nq);
            foreach (var t in q)
            {
                Console.WriteLine(t.Key);
                foreach (var sub in t.Items)
                {
                    Console.WriteLine("  {0}", sub);
                }
            }
        }
        public void DictionaryToStringArray()
        {
            IDictionary<string, int> dic = new Dictionary<string, int>
            {
                ["item 1"] = 342,
                ["item 2"] = 700,
                ["item 3"] = 800
            };
            var q = from p in dic
                    select $"{p.Key} : {p.Value}";
            foreach (var i in q)
            {
                Console.WriteLine(i);
            }
        }
        public void ChangeXMLContent()
        {
            XElement testel =
                new XElement("Productions",
                    new XElement("Product",
                        new XElement("id", 1201),
                        new XElement("desc", "Product A"),
                        new XElement("mode", 7)),
                    new XElement("Product",
                        new XElement("id", 1202),
                        new XElement("desc", "Product B"),
                        new XElement("mode", 3))
                );
            var q = from x in testel.Elements()
                    where (int)x.Element("mode") == 3
                    select x;
            if (q.Count() > 0)
            {
                XElement e = q.First();
                e.Element("desc").Value = "Product G";
            }
        }
        public void ParallelLINQ()
        {
            ConcurrentQueue<ARectangle> testList = new ConcurrentQueue<ARectangle>();
            Parallel.For(20, 30000000, n =>
            {
                testList.Enqueue(new ARectangle
                {
                    Width = n,
                    Height = n
                });
            });
            Stopwatch watch = new Stopwatch();
            watch.Restart();
            var q1 = from x in testList
                     select x.Width * x.Height;
            watch.Stop();
            Console.WriteLine("It takes:{0} ms", watch.ElapsedMilliseconds);
            watch.Restart();
            var q2 = from x in testList.AsParallel()
                     select x.Width * x.Height;
            watch.Stop();
            Console.WriteLine("It takes:{0} ms", watch.ElapsedMilliseconds);
        }
        public void XMLToTuple()
        {
            XElement xml = new XElement(
                            "Items",
                                new XElement("Item", new XAttribute("Val1", 100), new XAttribute("Val2", 250)),
                                new XElement("Item", new XAttribute("Val1", 7500), new XAttribute("Val2", 900)),
                                new XElement("Item", new XAttribute("Val1", 2003), new XAttribute("Val2", 6230))
                            );
            var q = from el in xml.Elements("Item")
                    let v1 = Convert.ToInt32(el.Attribute("Val1").Value)
                    let v2 = Convert.ToInt32(el.Attribute("Val2").Value)
                    select (Value_1: v1, Value_2: v2);
            foreach (var t in q)
            {
                Console.WriteLine($"Value 1 : {t.Value_1}\nValue 2 : {t.Value_2}\n");
            }
        }
        public void CreateFileWithNamespace()
        {
            XNamespace ns = "http://demo.org";
            XElement n1 = new XElement(ns + "Group",
                            new XElement(ns + "Name", "Jack"),
                            new XElement(ns + "Level", 3)
                          );
            XElement n2 = new XElement(ns + "Group",
                new XElement(ns + "Name", "Tom"),
                new XElement(ns + "Level", 2)
              );
            XElement n3 = new XElement(ns + "Group",
                new XElement(ns + "Name", "Jim"),
                new XElement(ns + "Level", 7)
              );
            XElement root = new XElement(ns + "Groups", n1, n2, n3);
            Console.WriteLine(root);
        }
        public void AddLiteralToPrefix()
        {
            XNamespace ns1 = "demo1.org";
            XNamespace ns2 = "demo2.org";
            Object[] xels = {
                new XAttribute(XNamespace.Xmlns + "na", ns1),
                new XAttribute(XNamespace.Xmlns + "nb", ns2),
                new XElement(ns1 + "Layout1", "Border"),
                new XElement(ns2 + "Layout2", "Canvas")
            };
            XElement xml = new XElement(ns1 + "Root", xels);
            Console.WriteLine(xml);
        }
    }

}
