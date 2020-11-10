using System;

namespace CSharpLearning
{
    public class MyEnumeratorEx : IDemonstrate
    {
        public void Demonstrate()
        {
            MyEnumerator me = new MyEnumerator();
            while (me.MoveNext())
            {
                Console.WriteLine(me.Current);
            }
        }
    }
}
