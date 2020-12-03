using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example209 : IDemonstration
    {
        public void display()
        {
            List<WorkItem> works = new List<WorkItem>();
            works.Add(new WorkItem
            {
                ID = 1,
                Desc = "Process A",
                StartTime = new DateTime(2018, 5, 10, 8, 32, 16),
                EndTime = new DateTime(2018, 5, 13, 14, 20, 0)
            });
            works.Add(new WorkItem
            {
                ID = 2,
                Desc = "Process B",
                StartTime = new DateTime(2018, 5, 12, 7, 26, 15),
                EndTime = new DateTime(2018, 5, 12, 18, 24, 15)
            });
            works.Add(new WorkItem
            {
                ID = 3,
                Desc = "Process C",
                StartTime = new DateTime(2018, 5, 17, 9, 45, 0),
                EndTime = new DateTime(2018, 5, 19, 20, 36, 4)
            });
            works.Add(new WorkItem
            {
                ID = 4,
                Desc = "Process D",
                StartTime = new DateTime(2018, 6, 1, 11, 0, 0),
                EndTime = new DateTime(2018, 6, 4, 16, 34, 0)
            });
            works.Add(new WorkItem
            {
                ID = 5,
                Desc = "Process E",
                StartTime = new DateTime(2018, 7, 3, 7, 49, 0),
                EndTime = new DateTime(2018, 7, 5, 18, 17, 0)
            });
            var max = works.Max(w => w.EndTime - w.StartTime);
            Console.WriteLine("Longest period:{0:%d} days, {0:%h} hours, {0:%m} mins, {0:%s} secs", max);
        }

        public class WorkItem
        {
            public int ID { get; set; }
            public string Desc { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
        }
    }
}
