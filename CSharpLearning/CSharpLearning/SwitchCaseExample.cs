using System;
using System.Collections;

namespace CSharpLearning
{
    class SwitchCaseExample
    {
        public static void show(object instance)
        {
            switch (instance)
            {
                case null:
                    System.Console.WriteLine("Nothing");
                    break;
                case Array arr when arr.Length == 0:
                    Console.WriteLine("This is a empty array.");
                    break;
                case Array arr :
                    Console.WriteLine($"This array includes {arr.Length} elements.");
                    break;                
                case IList list when list.Count == 0:
                    Console.WriteLine("This is a empty array.");
                    break;
                case IList list:
                    Console.WriteLine($"This list includes {list.Count} items.");
                    break;
                default:
                    System.Console.WriteLine("Default");
                    break;
            }
        }
    }
}
