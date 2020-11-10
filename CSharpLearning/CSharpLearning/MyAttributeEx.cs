using System;
using System.Reflection;

namespace CSharpLearning
{
    public class MyAttributeEx : IDemonstrate
    {
        public void Demonstrate()
        {
            MyAttributeImpl mai = new MyAttributeImpl { RawName = "h0213f" };
            bool b = CheckTest(mai, nameof(MyAttributeImpl.RawName));
            if (b)
                Console.WriteLine("validate successfully.");
            else
                Console.WriteLine("failed to validate.");
        }

        public static bool CheckTest(MyAttributeImpl m, string property)
        {
            Type type = m.GetType();
            PropertyInfo prop = type.GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop == null)
                return false;
            MyAttribute att = prop.GetCustomAttribute<MyAttribute>();
            string value = prop.GetValue(m) as string;
            if (string.IsNullOrEmpty(value))
                return false;
            if (value.StartsWith(att.StartChar) == false)
                return false;
            if (value.Length > att.MaxLen)
                return false;
            return true;
        }
    }
}
