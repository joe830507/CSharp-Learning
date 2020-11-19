using System;
using System.Reflection;

namespace CSharpLearning
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            IDemonstrate id = new ReflectionAndComposition();
            id.Demonstrate();
        }
    }

    namespace CoolComponents
    {
        public class CoolEngin { }
        public struct FaultData { }
        public class FastBuilder { }
    }

    public class ReflectionAndComposition : IDemonstrate
    {
        public void Demonstrate()
        {
            checkType();
        }
        public void checkType()
        {
            Assembly ass = Assembly.LoadFrom("CSharpLearning.dll");
            Type[] types = ass.GetTypes();
            foreach (var t in types)
            {
                Console.WriteLine("{0} -", t.FullName);
                if (t.IsClass)
                    Console.WriteLine("Reference type:");
                else if (t.IsValueType)
                    Console.WriteLine("figure type:");
                else
                    Console.WriteLine("other type");
                Console.WriteLine("\n");
            }
        }
    }
}
