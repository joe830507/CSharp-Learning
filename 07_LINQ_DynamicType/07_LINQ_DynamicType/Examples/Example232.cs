using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _07_LINQ_DynamicType
{
    public class Example232 : IDemonstration
    {
        public void display()
        {
            ConcurrentQueue<Rectangle> testList = new ConcurrentQueue<Rectangle>();
            Parallel.For(20, 300000000, n =>
            {
                testList.Enqueue(new Rectangle
                {
                    Width = n,
                    Height = n
                });
            });
            Stopwatch watch = new Stopwatch();
            watch.Restart();
            var q1 = from x in testList
                     select x.Width * x.Height;
            watch.Stop();
            System.Console.WriteLine("Normal mode, it takes:{0} ms", watch.ElapsedMilliseconds);
            watch.Restart();
            var q2 = from x in testList.AsParallel()
                     select x.Width * x.Height;
            watch.Stop();
            System.Console.WriteLine("Parallel mode, it takes:{0} ms", watch.ElapsedMilliseconds);
        }

        public struct Rectangle
        {
            public double Width;
            public double Height;
        }
    }
}
