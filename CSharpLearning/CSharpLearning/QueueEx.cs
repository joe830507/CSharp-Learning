using System.Collections.Generic;

namespace CSharpLearning
{
    public class QueueEx : IDemonstrate
    {
        public void Demonstrate()
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(3);
            q.Enqueue(2);
            q.Enqueue(1);
            while (q.TryDequeue(out int x))
            {
                System.Console.WriteLine(x);
            }
            System.Console.WriteLine("--------------------------");
            //comparison
            Stack<int> s = new Stack<int>();
            s.Push(3);
            s.Push(2);
            s.Push(1);
            while (s.TryPop(out int x))
            {
                System.Console.WriteLine(x);
            }
        }
    }
}
