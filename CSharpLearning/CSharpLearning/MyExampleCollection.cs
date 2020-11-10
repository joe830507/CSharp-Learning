using System.Collections;

namespace CSharpLearning
{
    public class MyExampleCollection : IEnumerable,IDemonstrate
    {
        string[] arrSync = { "red", "blue", "green", "gray" };

        public void Demonstrate()
        {
            foreach (var item in this) 
            {
                System.Console.WriteLine(item);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator2(arrSync);
        }
    }
}
