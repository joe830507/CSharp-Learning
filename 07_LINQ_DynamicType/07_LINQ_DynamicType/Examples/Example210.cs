using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example210 : IDemonstration
    {
        string[] arr =
        {
            "effect","teach","table","purpose","transport"
        };
        public void display()
        {
            int len = arr.Sum(x => x.Length);
            System.Console.WriteLine($"Length of texts:{len}");
        }
    }
}
