using System;

namespace CSharpLearning
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CustomAttribute : Attribute
    {
        public string Ver { get; set; }
    }
}
