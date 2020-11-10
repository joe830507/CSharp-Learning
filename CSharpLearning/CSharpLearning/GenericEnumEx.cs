using System;

namespace CSharpLearning
{
    public class GenericEnumEx : IDemonstrate
    {
        public void Demonstrate()
        {
            (string name, int value) res = GenericEnum.CallTest(Oper.Open);
            Console.WriteLine("{0} - {1}", res.name, res.value);
        }
    }
}
