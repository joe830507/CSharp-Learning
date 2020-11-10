using System;
using System.Reflection;
using System.Text;

namespace CSharpLearning
{
    public class ValueTupleEx : IDemonstrate
    {
        public void Demonstrate()
        {
            ValueTuple<short, uint, ulong, string> t1 = ValueTuple.Create<short, uint, ulong, string>(160, 300, 50000000UL, "head");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Four Tuple:");
            sb.AppendFormat("{0}:{1} = {2}\n", nameof(t1.Item1), t1.Item1.GetType().Name, t1.Item1);
            sb.AppendFormat("{0}:{1} = {2}\n", nameof(t1.Item2), t1.Item2.GetType().Name, t1.Item2);
            sb.AppendFormat("{0}:{1} = {2}\n", nameof(t1.Item3), t1.Item3.GetType().Name, t1.Item3);
            sb.AppendFormat("{0}:{1} = {2}\n", nameof(t1.Item4), t1.Item4.GetType().Name, t1.Item4);
            ValueTuple<bool, byte> t2 = ValueTuple.Create<bool, byte>(false, 100);
            sb.AppendLine("\n\nTwo Tuple:");
            sb.AppendFormat("{0}:{1} = {2}\n", nameof(t2.Item1), t2.Item1.GetType().Name, t2.Item1);
            sb.AppendFormat("{0}:{1} = {2}\n", nameof(t2.Item2), t2.Item2.GetType().Name, t2.Item2);
            t2.Item2 = 210;
            sb.AppendFormat("Modified,{0} = {1}", nameof(t2.Item2), t2.Item2);
            Console.WriteLine(sb);

            (string, string, byte) x = ("subject", "body", 26);
            Console.WriteLine("{0}:{1}:{2}", x.Item1, x.Item2, x.Item3);
            var y = (new DateTime(2017, 1, 1), new DateTime(2018, 1, 1));
            Console.WriteLine("item1:{0:d},item={1:d}", y.Item1, y.Item2);
            (double x, double y) d = (0.000025d, 3.115d);
            Console.WriteLine("x * y = {0}", d.x * d.y);
            Type t = d.GetType();
            FieldInfo[] fds = t.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("type:{0}", t.Name);
            string infos = string.Empty;
            foreach (var f in fds)
            {
                infos += $"{f.Name}:{f.FieldType.Name}\n";
            }
            Console.WriteLine("Result:\n{0}", infos);
            (long BookId, string BookName, string Author) = (10000031L, "Sample Book", "Tommy");
            Console.WriteLine($"No.{BookId}\nName:{BookName}\nAuthor:{Author}");
            Order o = new Order()
            {
                OID = 6012001,
                CustomName = "XXX Company",
                ContactName = "Mr.Lu",
                Amount = 1700.34f,
                PhoneNo = "12021329381203"
            };
            var (id, cust, contact, amount, phone) = o;
            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n", id, cust, contact, amount, phone);
            var k = GetData();
            Console.WriteLine("Item1 = {0}, Item2 = {1}, Item3 = {2}", k.Item1, k.Item2, k.Item3);
            var (Mark1, Count, Mark2) = GetData();
            Console.WriteLine("Item1 = {0}, Item2 = {1}, Item3 = {2}", Mark1, Count, Mark2);
            var nums = GetNumbers();
            Console.WriteLine($"{nameof(nums.Number1)} = {nums.Number1},{nameof(nums.Number2)} = {nums.Number2}");
        }

        (string, int, string) GetData()
        {
            return ("Test 1", 35, "Test 2");
        }

        (int Number1, int Number2) GetNumbers()
        {
            Random rand = new Random();
            return (rand.Next(0, 1000), rand.Next(0, 1000));
        }
    }
}
