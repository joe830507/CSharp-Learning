using System;
using System.Reflection;

namespace CSharpLearning
{
    public class TypeofUsageEx : IDemonstrate
    {
        public void Demonstrate()
        {
            Type t = typeof(Person);
            Console.WriteLine(t.FullName);
            Console.WriteLine($"is abstract:{t.IsAbstract}");
            Console.WriteLine($"is public:{t.IsPublic}");
            PropertyInfo[] props = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("--------list--------");
            foreach (var p in props)
            {
                Console.WriteLine($"{p.Name,-15}{p.PropertyType.Name,-15}");
            }
        }
    }
}
