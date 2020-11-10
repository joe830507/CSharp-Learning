using System;

namespace CSharpLearning
{
    class PassValueByVariable
    {
        static int Add(int a, int b)
        {
            return a + b;
        }

        public static void GetTotal()
        {
            int z = Add(a: 2, b: 5);
            // set values to variables
            Console.WriteLine(z);
        }
    }
}
