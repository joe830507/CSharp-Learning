using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace CSharpLearning
{
    public class ConcurrentBagEx : IDemonstrate
    {
        public void Demonstrate()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            Task t1 = Task.Run(() =>
            {
                for (int k = 45; k < 51; k++)
                {
                    System.Console.WriteLine("k:" + k);
                    bag.Add(k);
                }
            });
            System.Console.WriteLine("doing something...");
            Task t2 = t1.ContinueWith((task) =>
            {
                while (!bag.IsEmpty)
                {
                    if (bag.TryTake(out int item))
                    {
                        System.Console.WriteLine("item:" + item);
                    }
                }
            });
            Task.WaitAll(t1, t2);
            System.Console.WriteLine("Keep working...");
        }
    }
}
