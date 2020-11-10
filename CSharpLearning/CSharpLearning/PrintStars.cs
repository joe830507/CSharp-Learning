using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLearning
{
        class PrintStars
        {
            public static void printStars()
            {
                List<string> list = new List<string>();
                for (int i = 1; i <= 8; i++)
                {
                    String s1 = "";
                    int v = 0;
                    while (v < i)
                    {
                        s1 += "*";
                        v++;
                }

                s1 = s1.PadRight(8);
                    string s2 = new string(s1.Reverse().ToArray());
                    list.Add(s1 + s2);
                    list.Reverse();
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                    list.Reverse();
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
    }
}
