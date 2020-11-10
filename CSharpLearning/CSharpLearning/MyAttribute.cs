using System;

namespace CSharpLearning
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyAttribute : Attribute
    {
        public char StartChar { get; set; }
        public int MaxLen { get; set; }
    }
}
