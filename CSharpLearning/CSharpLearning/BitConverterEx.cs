using System;

namespace CSharpLearning
{
    public class BitConverterEx : IDemonstrate
    {
        public void Demonstrate()
        {
            byte[] buffer = { 3, 12, 5, 92, 7, 61, 18, 53, 135 };
            string str = BitConverter.ToString(buffer);
            Console.WriteLine(str);
        }
    }
}
