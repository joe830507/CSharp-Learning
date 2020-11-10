using System;

namespace CSharpLearning
{
    class ActionAndFunc
    {
        static void TestA(string name,int age)
        {
            System.Console.WriteLine($"What's your name? I'm {name}.");
            System.Console.WriteLine($"How old are you? I'm {age} years old.");
        }

        static void TestB(string name)
        {
            System.Console.WriteLine($"Hello {name}");
        }

        static int TestC(DateTime d)
        {
            return d.Year;
        }

        static long TestD(int start,int end)
        {
            long r = 1l;
            int cur = start;
            while(cur <= start)
            {
                r *= cur;
                cur++;
            }
            return r;
        }

        public static void Demonstrate()
        {
            Action<string, int> d1 = TestA;
            d1("Bob", 28);
            Action<string> d2 = TestB;
            d2("Joe");
            Func<DateTime, int> d3 = TestC;
            Console.WriteLine($"This year is {d3(DateTime.Now)}");
            Func<int, int, long> d4 = TestD;
            long res = d4(2, 4);
            Console.WriteLine($"The result is {res}");
        }
    }
}
