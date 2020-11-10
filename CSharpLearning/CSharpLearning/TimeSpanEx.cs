using System;

namespace CSharpLearning
{
    public class TimeSpanEx : IDemonstrate
    {
        public void Demonstrate()
        {
            TimeSpan ts = new TimeSpan(24, 0, 0);
            Console.WriteLine(ts.TotalSeconds);
            TimeSpan threedays = new TimeSpan(3, 0, 0, 0);
            Console.WriteLine(threedays.TotalSeconds);
        }
    }
}
