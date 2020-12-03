using System.Collections.Generic;
using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example214 : IDemonstration
    {
        int[] arr = { 100, 150, 150, 32, 35, 35, 35 };
        public void display()
        {
            IEnumerable<int> result = arr.Distinct();
            System.Console.WriteLine("All elements:{0}", string.Join(",", arr));
            System.Console.WriteLine("after removing duplicate elements:{0}", string.Join(",", result));
        }
    }
}
