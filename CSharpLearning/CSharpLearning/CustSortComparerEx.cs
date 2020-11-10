using System;
using System.Collections.Generic;

namespace CSharpLearning
{
    public class CustSortComparerEx : IDemonstrate
    {
        public void Demonstrate()
        {
            SortedDictionary<string, DateTime> dic = new SortedDictionary<string, DateTime>(new CustSortComparer());
            dic["ab"] = new DateTime(2018, 1, 1);
            dic["hijklmn"] = new DateTime(2018, 1, 3);
            dic["opqr"] = new DateTime(2018, 1, 5);
            dic["s"] = new DateTime(2018, 1, 7);
            dic["stuvwxyz"] = new DateTime(2018, 1, 9);

            foreach (var dp in dic)
            {
                Console.WriteLine($"{dp.Key,-10} - {dp.Value}\n");
            }
        }
    }
}
