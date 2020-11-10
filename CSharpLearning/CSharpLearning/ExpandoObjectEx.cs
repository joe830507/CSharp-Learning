using System;
using System.Collections.Generic;
using System.Dynamic;

namespace CSharpLearning
{
    public partial class ExpandoObjectEx : IDemonstrate
    {
        public void Demonstrate()
        {
            SimulateToCallDelegateInstance();
        }

        public void CreateDynamicInstance()
        {
            dynamic dx = new ExpandoObject();
            dx.Message = "Hello";
            dx.Time = new DateTime(2009, 2, 1, 23, 54, 16);
            Console.WriteLine($"Message = {dx.Message}\n Time = {dx.Time}");
        }
        public void FetchExpandoObjectInDictionary()
        {
            dynamic d = new ExpandoObject();
            d.AppName = "Sample";
            d.ver = "1.0.3";
            d.Desc = "test application";
            d.Release = 5;
            IDictionary<string, object> dic = d;
            foreach (var i in dic)
            {
                Console.WriteLine($"{i.Key} : {i.Value}");
            }
        }
        public void InitMyDynamic()
        {
            dynamic d = new MyDynamic();
            d.WorkName = "Procedure";
            d.WorkDescription = "It needs long time to work.";
            d.IsStarted = false;
            d.WorkType = 15;
            d.StartTime = new DateTime(2018, 8, 3);

            Console.WriteLine($"Work Name:{d.WorkName}");
            Console.WriteLine($"Start Time:{d.StartTime}");
            Console.WriteLine($"Work Type:{d.WorkType}");
        }
        public void SimulateToCallDelegateInstance()
        {
            dynamic d = new MyCustDynamic();
            int r = d(2, 10, 15, 7);
            Console.WriteLine(r);
        }
    }
}
