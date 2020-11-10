using System;

namespace CSharpLearning
{
    public class GenericEnum
    {
        public static (string, int) CallTest<T>(T p) where T : Enum
        {
            string name = Enum.GetName(p.GetType(), p);
            int value = Convert.ToInt32(p);
            return (name, value);
        }
    }
}
