using System.Collections.Generic;
using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example211 : IDemonstration
    {
        public void display()
        {
            List<int> list1 = new List<int>
            {
                20,21,22
            };
            List<int> list2 = new List<int>
            {
                23,24
            };
            var result = list1.Concat(list2);
            System.Console.WriteLine("Merged List:");
            System.Console.WriteLine(string.Join(",", result));
        }
    }
}
