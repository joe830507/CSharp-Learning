using System.Collections;

namespace CSharpLearning
{
    public class ArrayListEx : IDemonstrate
    {
        public void Demonstrate()
        {
            ArrayList list = new ArrayList();
            list.Add(5580);
            list.Add(7899878L);
            list.Add('v');
            list.RemoveAt(0);
            list.Add("test");
            list.Add((uint)36000);
            foreach (var o in list)
            {
                System.Console.WriteLine(o);
            }
        }
    }
}
