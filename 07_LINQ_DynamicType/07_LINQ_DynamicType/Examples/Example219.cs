using System.Collections.Generic;
using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example219 : IDemonstration
    {
        Production[] prds =
        {
            new Production
            {
                PID = 4007,
                Name = "P1",
                Size = 123.45f,
                Quantity = 65
            },
            new Production
            {
                PID = 4008,
                Name = "P2",
                Size = 77.01f,
                Quantity = 100
            },
            new Production
            {
                PID = 4012,
                Name = "P3",
                Size = 45.13f,
                Quantity = 25
            }
        };
        public void display()
        {
            IDictionary<int, string> dic = prds.ToDictionary(p => p.PID, p => p.Name);
            System.Console.WriteLine("Dictinoary:");
            foreach (var kp in dic)
            {
                System.Console.WriteLine("{0} - {1}", kp.Key, kp.Value);
            }
        }

        public class Production
        {
            public int PID { get; set; }
            public string Name { get; set; }
            public float Size { get; set; }
            public int Quantity { get; set; }
        }
    }
}
