using System.Collections.Generic;

namespace CSharpLearning
{
    public class LinkedListEx : IDemonstrate
    {
        public void Demonstrate()
        {
            LinkedList<string> list = new LinkedList<string>();
            var node = list.AddFirst("A");
            node = list.AddAfter(node, "B");
            node = list.AddAfter(node, "C");
            node = list.AddAfter(node, "D");
            list.AddBefore(node, "E");

            LinkedList<byte> list2 = new LinkedList<byte>();
            list2.AddLast(1);
            list2.AddLast(2);
            list2.AddLast(3);
            list2.AddLast(4);

            var foundnode = list2.Find(3);
            var thirdnode = foundnode.Next;
            list2.Remove(foundnode);
            list2.AddAfter(thirdnode, foundnode.Value);
            foreach (var item in list)
            {
                System.Console.WriteLine(item);
            }
            foreach (var item in list2)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
