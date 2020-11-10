using System.Collections.Generic;

namespace CSharpLearning
{
    public class ListEx : IDemonstrate
    {
        public void Demonstrate()
        {
            List<int> list = new List<int>();
            int[] a = { 1, 2, 3, 4, 5 };
            list.Add(6);
            list.Add(7);
            list.AddRange(a);
            string r1 = string.Join(",", list.ToArray());
            System.Console.WriteLine(r1);
            List<int> list1 = new List<int>(list);
            list1.Add(11);
            list1.Add(12);
            string r2 = string.Join(",", list1.ToArray());
            System.Console.WriteLine(r2);
        }
    }
}
