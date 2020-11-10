using System;

namespace CSharpLearning
{
    public class WorkItemEx : IDemonstrate
    {
        public void Demonstrate()
        {
            WorkItem[] items = new WorkItem[]
            {
                new WorkItem{
                    ID = 1,
                    Title = "123",
                    StartTime = DateTime.Today.AddHours(-5),
                    EndTime = DateTime.Today.AddHours(2)
                },
                new WorkItem{
                    ID = 1,
                    Title = "456",
                    StartTime = DateTime.Today.AddDays(1),
                    EndTime = DateTime.Today.AddDays(2)
                },
                new WorkItem{
                    ID = 1,
                    Title = "789",
                    StartTime = DateTime.Today.AddHours(-11),
                    EndTime = DateTime.Today.AddHours(5)
                },
                new WorkItem{
                    ID = 1,
                    Title = "821",
                    StartTime = DateTime.Today.AddDays(2),
                    EndTime = DateTime.Today.AddDays(5)
                }
            };

            WorkItem wi = Array.Find(items, i =>
            {
                DateTime today = DateTime.Today;
                if (i.StartTime.CompareTo(today) > 0)
                    return true;
                return false;
            });
            WorkItem[] wiArr = Array.FindAll(items, i =>
            {
                DateTime today = DateTime.Today;
                if (i.StartTime.CompareTo(today) > 0)
                    return true;
                return false;
            });
            foreach (var wii in wiArr)
            {
                Console.WriteLine(wii.Title);
            }
        }
    }
}
