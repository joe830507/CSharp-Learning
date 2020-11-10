using System;

namespace CSharpLearning
{
    public class ArrayFindIndex : IDemonstrate
    {
        public void Demonstrate()
        {
            string[] strArr = {
                "page",
                "wood",
                "test",
                "make",
                "yoyoyo"
            };
            int a = Array.FindIndex(strArr, i =>
            {
                if (i.Contains("a"))
                    return true;
                return false;
            });
            int b = Array.FindLastIndex(strArr, i =>
            {
                if (i.Contains("a"))
                    return true;
                return false;
            });
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
