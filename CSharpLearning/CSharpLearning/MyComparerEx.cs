using System.Collections.Generic;

namespace CSharpLearning
{
    public class MyComparerEx : IDemonstrate
    {
        public void Demonstrate()
        {
            SortedSet<int> list = new SortedSet<int>(new MyComparer());
            list.Add(15);
            list.Add(2);
            list.Add(25);
            list.Add(13);
            list.Add(7);
            foreach (var num in list)
            {
                System.Console.WriteLine(num);
            }
        }
    }
}
