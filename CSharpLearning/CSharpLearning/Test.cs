using System;

namespace CSharpLearning
{
    public class Test<T> where T : struct
    {
        public void Start(T x)
        {
            string CheckType(Type t) => t.IsValueType ? "Yes" : "No";
            Type type = x.GetType();
            Console.WriteLine($"{type.Name} {CheckType(type)}.");
        }
    }
}
