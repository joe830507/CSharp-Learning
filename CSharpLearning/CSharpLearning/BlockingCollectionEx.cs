using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace CSharpLearning
{
    public class BlockingCollectionEx : IDemonstrate
    {
        public void Demonstrate()
        {
            using (BlockingCollection<int> bc = new BlockingCollection<int>())
            {
                Task t1 = Task.Run(async () =>
                {
                    for (int k = 0; k < 5; k++)
                    {
                        int item = k + 1;
                        System.Console.WriteLine("item:" + item);
                        bc.Add(item);
                        await Task.Delay(650);
                        System.Console.WriteLine("++++++++");
                    }
                    System.Console.WriteLine("CompleteAdding...");
                    bc.CompleteAdding();
                });

                Task t2 = Task.Run(() =>
                {
                    while (true)
                    {
                        //When BlockingCollection add item, this loop will take the latest item immediately.
                        //So string '++++++++' will be printed after 'taken item: x'
                        if (bc.TryTake(out int item))
                        {
                            System.Console.WriteLine("taken item:" + item);
                        }
                        if (bc.IsCompleted) break;
                    }
                });
                Task.WaitAll(t1, t2);
                t1.Dispose();
                t2.Dispose();
            }
        }
    }
}
