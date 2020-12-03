using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example226 : IDemonstration
    {
        int[] arrsrc = { 1, 4, 8, 32 };
        public void display()
        {
            var q = from x in arrsrc
                    select x / 0;
            try
            {
                foreach (var i in q)
                {
                    System.Console.WriteLine(i);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("ErrorMessage:{0}", ex.Message);
            }
        }
    }
}
