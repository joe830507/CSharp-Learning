using System.Collections.Generic;

namespace CSharpLearning
{
    public class StackEx : IDemonstrate
    {
        public void Demonstrate()
        {
            Stack<int> st = new Stack<int>();
            st.Push(3);
            st.Push(2);
            st.Push(1);

            while (st.Count > 0)
            {
                System.Console.WriteLine(st.Pop());
            }

            while (st.TryPop(out int x))
            {
                System.Console.WriteLine(x);
            }
        }
    }
}
