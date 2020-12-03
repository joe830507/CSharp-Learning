using System.Collections.Generic;
using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example217 : IDemonstration
    {
        List<int> list = new List<int> { 15 };
        public void display()
        {
            int x = list.Single();
            System.Console.WriteLine("Only element:{0}", x);
        }
    }
}
