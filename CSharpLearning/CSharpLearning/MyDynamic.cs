using System;
using System.Collections.Generic;
using System.Dynamic;

namespace CSharpLearning
{
    public class MyDynamic : DynamicObject
    {
        private IDictionary<string, object> data = new Dictionary<string, object>();
        public string WorkDescription { get; set; }
        public string WorkName { get; set; }
        public bool IsStarted { get; set; }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            Console.WriteLine(binder.Name);
            return data.TryGetValue(binder.Name.ToLower(), out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            return data.TryAdd(binder.Name.ToLower(), value);
        }

    }
}
