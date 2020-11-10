using System;

namespace CSharpLearning
{
    public class GenericObjEx : IDemonstrate
    {
        public void Demonstrate()
        {
            GenericObj<string> o1 = new GenericObj<string>();
            o1.Work("Hello");
            GenericObj<DateTime> o2 = new GenericObj<DateTime>();
            o2.Work(DateTime.Now);
            GenericObj<decimal> o3 = new GenericObj<decimal>();
            o3.Work(213.2134M);
            GenericObj<float> o4 = new GenericObj<float>();
            o4.Work(3.21234f);
            GenericObj<byte> o5 = new GenericObj<byte>();
            o5.Work(233);
            GenericObj<uint> o6 = new GenericObj<uint>();
            o6.Work(232452);
        }
    }
}
