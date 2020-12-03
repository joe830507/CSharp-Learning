using System.Collections.Generic;
using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example215 : IDemonstration
    {
        uint[] list1 = { 1, 2, 3, 4, 5, 6 };
        uint[] list2 = { 1, 2, 7, 4, 8, 6 };

        public void display()
        {
            IEnumerable<uint> result1 = list1.Except(list2);
            IEnumerable<uint> result2 = list2.Except(list1);
            System.Console.WriteLine($"List 1:{string.Join(" ", list1)}");
            System.Console.WriteLine($"List 2:{string.Join(" ", list2)}");
            System.Console.WriteLine($"Result 1:{string.Join(" ", result1)}");
            System.Console.WriteLine($"Result 2:{string.Join(" ", result2)}");
        }
    }
}
