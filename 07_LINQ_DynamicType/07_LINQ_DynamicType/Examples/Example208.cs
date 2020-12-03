using System;
using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example208 : IDemonstration
    {
        int[] arrsrc = { 100, 58, 8, 91, 560, 27, 42 };
        public void display()
        {
            int max = arrsrc.Max();
            int min = arrsrc.Min();
            Console.WriteLine("All elements:{0}", string.Join(",", arrsrc));
            Console.WriteLine("Max:{0},Min:{1}", max, min);
        }
    }
}
