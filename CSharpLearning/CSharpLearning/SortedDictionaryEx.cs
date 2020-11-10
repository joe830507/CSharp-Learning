using System.Collections.Generic;

namespace CSharpLearning
{
    public class SortedDictionaryEx : IDemonstrate
    {
        public void Demonstrate()
        {
            SortedDictionary<int, string> dic = new SortedDictionary<int, string>();
            dic[20] = "hook";
            dic[5] = "book";
            dic[32] = "look";
            dic[3] = "disk";
            dic[12] = "list";
            dic[7] = "foot";
            foreach (var p in dic)
            {
                System.Console.WriteLine("{0} - {1}\n", p.Key, p.Value);
            }
        }
    }
}
