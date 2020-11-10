using System;

namespace CSharpLearning
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class DoubleRangeAttribute : Attribute
    {
        public Double Largest { get; }
        public DoubleRangeAttribute(Double largest)
        {
            Largest = largest;
        }
    }
}
