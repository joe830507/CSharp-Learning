using System.Collections;

namespace CSharpLearning
{
    public class YieldReturnEx : IDemonstrate
    {
        public void Demonstrate()
        {
            foreach (var item in Test1())
            {
                System.Console.WriteLine(item);
            }

            foreach (var item in Test2())
            {
                System.Console.WriteLine(item);
            }
        }

        static IEnumerable Test1()
        {
            yield return 0;
            yield return 1;
            yield return 2;
        }

        static IEnumerable Test2()
        {
            yield return "abcd";
            yield return "opqrs";
            yield return "@#$%";
        }
    }
}
