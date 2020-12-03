using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example221 : IDemonstration
    {
        int[] arr = { 12, 15, 35, 32, 45, 77, 80, 63 };
        public void display()
        {
            var res = from n in arr
                      where (n % 5) == 0
                      select n;
            System.Console.WriteLine("Elements can be divided by 5:");
            foreach (var x in res)
            {
                System.Console.WriteLine(" {0}", x);
            }
        }
    }
}
