using System;

namespace CSharpLearning
{
    public class GenericObj<T>
    {
        public void Work(T obj)
        {
            Console.WriteLine($"{obj.GetType().FullName,-20}:{obj}");
        }
    }
}
