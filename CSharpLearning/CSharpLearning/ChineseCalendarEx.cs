using System;
using System.Globalization;

namespace CSharpLearning
{
    public class ChineseCalendarEx : IDemonstrate
    {
        public void Demonstrate()
        {
            ChineseLunisolarCalendar cncld = new ChineseLunisolarCalendar();
            DateTime d1 = new DateTime(2017, 12, 18);
            DateTime d2 = new DateTime(2018, 3, 20);
            DateTime d3 = new DateTime(2018, 5, 15);
            Console.WriteLine($"{d1:d},|{cncld.GetYear(d1)},{cncld.GetMonth(d1)},{cncld.GetDayOfMonth(d1)}");
            Console.WriteLine($"{d2:d},|{cncld.GetYear(d2)},{cncld.GetMonth(d2)},{cncld.GetDayOfMonth(d2)}");
            Console.WriteLine($"{d3:d},|{cncld.GetYear(d3)},{cncld.GetMonth(d3)},{cncld.GetDayOfMonth(d3)}");
        }
    }
}
