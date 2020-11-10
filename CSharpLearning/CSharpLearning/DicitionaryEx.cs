using System;
using System.Collections.Generic;

namespace CSharpLearning
{
    public class DicitionaryEx : IDemonstrate
    {
        public void Demonstrate()
        {
            Dictionary<string, string> dic1 = new Dictionary<string, string>();
            dic1["k1"] = "val_1";
            dic1["k2"] = "val_2";
            dic1["k3"] = "val_3";
            Dictionary<int, long> dic2 = new Dictionary<int, long>();
            dic2.Add(1, 1560000);
            dic2.Add(2, 1570000);
            dic2.Add(3, 1580000);
            Dictionary<decimal, DateTime> dic3 = new Dictionary<decimal, DateTime>
            {
                [12M] = new DateTime(2017, 9, 1),
                [13M] = new DateTime(2017, 10, 1),
                [14M] = new DateTime(2017, 11, 1)
            };
            foreach (var i in dic1)
            {
                Console.WriteLine("{0} - {1}", i.Key, i.Value);
            }
            foreach (var i in dic2)
            {
                Console.WriteLine("{0} - {1}", i.Key, i.Value);
            }
            foreach (var i in dic3)
            {
                Console.WriteLine("{0} - {1}", i.Key, i.Value);
            }
        }
    }
}
