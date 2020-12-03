using System.Collections.Generic;
using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example230 : IDemonstration
    {
        IDictionary<string, int> dic = new Dictionary<string, int>
        {
            ["item 1"] = 342,
            ["item 2"] = 700,
            ["item 3"] = 800
        };
        public void display()
        {
            var q = from p in dic
                    select $"{p.Key} : {p.Value}";
            foreach (var i in q)
            {
                System.Console.WriteLine(i);
            }
        }
    }
}
