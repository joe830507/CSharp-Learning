using System.Collections.Generic;
using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example216 : IDemonstration
    {
        IEnumerable<long> empty = Enumerable.Empty<long>();
        public void display()
        {
            try
            {
                long x = empty.First();
                System.Console.WriteLine($"First element:{x}");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"error:{ex.Message}");
            }
            long y = empty.FirstOrDefault();
            System.Console.WriteLine($"First element:{y}");
        }
    }
}
