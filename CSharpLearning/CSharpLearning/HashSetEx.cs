using System.Collections.Generic;

namespace CSharpLearning
{
    public class HashSetEx : IDemonstrate
    {
        public void Demonstrate()
        {
            HashSet<int> sets = new HashSet<int>();
            bool b1 = sets.Add(100);
            bool b2 = sets.Add(200);
            bool b3 = sets.Add(100);
            System.Console.WriteLine("{0} - {1} - {2}", b1, b2, b3);
        }
    }
}
