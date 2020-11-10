using System;
using System.Diagnostics;

namespace CSharpLearning
{
    public class SpanEx : IDemonstrate
    {
        public void Demonstrate()
        {
            string str = "我家裡養了20隻貓";
            Stopwatch sw1 = Stopwatch.StartNew();
            for (int x = 0; x < 10000000; x++)
            {
                int v = int.Parse(str.Substring(5, 2));
            }
            sw1.Stop();
            System.Console.WriteLine("Normal way,it takes:{0} ms", sw1.ElapsedMilliseconds);
            System.Console.WriteLine("--------------");
            Stopwatch sw2 = Stopwatch.StartNew();
            ReadOnlySpan<char> span = str.ToCharArray();
            for (int x = 0; x < 10000000; x++)
            {
                int v = 0;
                var subspan = span.Slice(5, 2);
                for (int i = 0; i < subspan.Length; i++)
                {
                    char ch = subspan[i];
                    v = (ch - '0') + v * 10;
                }
            }
            sw2.Stop();
            System.Console.WriteLine("Normal way,it takes:{0} ms", sw2.ElapsedMilliseconds);
            System.Console.WriteLine("--------------");
        }
    }
}
