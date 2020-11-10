using System;

namespace CSharpLearning
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public class MyDemoAttribute : Attribute
    {
        public string Description { get; set; }
    }
}
