using System;

namespace CSharpLearning
{
    public class TupleEx : IDemonstrate
    {
        public void Demonstrate()
        {
            var k = Tuple.Create<byte, string>(255, "full");
            Console.WriteLine(k.Item1.GetType());
            Console.WriteLine(k.Item2.GetType());
            Tuple<string, string, string> t1 = new Tuple<string, string, string>("make", "it", "easy");
            Console.WriteLine("Three Tuple:");
            string msg = $"{nameof(t1.Item1)}:{t1.Item1.GetType().Name} = {nameof(t1.Item2)}:{t1.Item2.GetType().Name}";
            Console.WriteLine(msg);

            Tuple<int, uint> t2 = new Tuple<int, uint>(70000, 950000);
            msg = $"{nameof(t2.Item1)}:{t2.Item1.GetType().Name} = {nameof(t2.Item2)}:{t2.Item2.GetType().Name}";
            Console.WriteLine(msg);
        }
    }
}
