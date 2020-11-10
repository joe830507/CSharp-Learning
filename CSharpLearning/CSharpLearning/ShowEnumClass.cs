using System;

namespace CSharpLearning
{
    public class ShowEnumClass : IDemonstrate
    {
        public void Demonstrate()
        {
            string[] days = Enum.GetNames(typeof(DayOfWeek));
            foreach (var day in days)
            {
                Console.WriteLine(day);
            }
        }
    }
}
