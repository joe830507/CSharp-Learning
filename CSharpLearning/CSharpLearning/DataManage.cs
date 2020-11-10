using System;
using System.Collections.Generic;

namespace CSharpLearning
{
    public class DataManage
    {
        IDictionary<int, string> _dicData;

        public DataManage(Func<IDictionary<int, string>> data)
        {
            _dicData = data();
        }

        public void DisplayData()
        {
            Console.WriteLine("---Data list---");
            foreach (var kp in _dicData)
            {
                Console.WriteLine($"{kp.Key,4}\t{kp.Value}");
            }
        }

        public static void Demonstrate()
        {
            DataManage dm = new DataManage(() => new Dictionary<int, string> { 
                [1] = "window",
                [2] = "house",
                [3] = "kite",
                [4] = "noodles",
                [5] = "claim"
            });
            dm.DisplayData();
        }
    }
}
