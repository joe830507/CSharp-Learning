using System;
using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example222 : IDemonstration
    {
        double[] srcs =
        {
            17.5,42.33,100,130,256,312.14,96.656
        };
        public void display()
        {
            var q = from x in srcs
                    let s = Math.Sqrt(x)
                    orderby s descending
                    select (x, s);
            foreach (var n in q)
            {
                Console.WriteLine("{0,-10} -> {1,-16}", n.x, n.s);
            }
        }
    }
}
