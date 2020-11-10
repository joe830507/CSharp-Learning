namespace CSharpLearning
{
    public class StructExample
    {
        public static void Demonstrate()
        {
            IStruct si = new StructImpl();
            int result = si.Add(10, 5);
            System.Console.WriteLine($"The result is {result}");
        }
    }
}
