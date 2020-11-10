using System;

namespace CSharpLearning
{
    public class DateTimeOperationEx : IDemonstrate
    {
        public void Demonstrate()
        {
            DateTime d1 = new DateTime(2018, 4, 1);
            DateTime d2 = d1.AddDays(6);
            DateTime d3 = d1.AddDays(-3);
            Console.WriteLine(d1);
            Console.WriteLine(d2);
            Console.WriteLine(d3);

            string ds = " 2018 年 5 月 20 日 23:14:20 ";
            DateTime dt = DateTime.Parse(ds);
            string msg = $"{nameof(DateTime.Year),-10} = {dt.Year}\n";
            msg += $"{nameof(DateTime.Month),-10} = {dt.Month}\n";
            msg += $"{nameof(DateTime.Day),-10} = {dt.Day}\n";
            msg += $"{nameof(DateTime.Hour),-10} = {dt.Hour}\n";
            msg += $"{nameof(DateTime.Minute),-10} = {dt.Minute}\n";
            msg += $"{nameof(DateTime.Second),-10} = {dt.Second}\n";
            Console.WriteLine(msg);
        }
    }
}
