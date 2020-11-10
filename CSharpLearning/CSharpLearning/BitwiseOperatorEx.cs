using System;

namespace CSharpLearning
{
    public class BitwiseOperatorEx : IDemonstrate
    {
        public void Demonstrate()
        {
            int x = 305;
            int y = 1060;
            System.Console.WriteLine(Convert.ToString(x, 2).PadLeft(24, '0'));
            System.Console.WriteLine(Convert.ToString(x << 3, 2).PadLeft(24, '0'));
            System.Console.WriteLine(Convert.ToString(y, 2).PadLeft(24, '0'));
            System.Console.WriteLine(Convert.ToString(y >> 4, 2).PadLeft(24, '0'));
        }
    }
}
