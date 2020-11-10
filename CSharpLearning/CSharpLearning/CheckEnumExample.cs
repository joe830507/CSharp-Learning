using System;

namespace CSharpLearning
{
    public class CheckEnumExample : IDemonstrate
    {
        public void Demonstrate()
        {
            CheckEnum c = CheckEnum.Mode1 | CheckEnum.Mode2;
            bool b = c.HasFlag(CheckEnum.Mode2);
            Console.WriteLine(b);
            b = c.HasFlag(CheckEnum.Mode3);
            Console.WriteLine(b);
            c = CheckEnum.Mode1 | CheckEnum.Mode2 | CheckEnum.Mode3;
            b = (c & CheckEnum.Mode3) == CheckEnum.Mode3;
            Console.WriteLine(b);
        }
    }
}
