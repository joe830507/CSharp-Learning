namespace CSharpLearning
{
    public class ConstructorExample
    {
        public static void Demonstrate()
        {
            ConstructorB b = new ConstructorB();
            System.Console.WriteLine($"Value 1 = {b.a}");
            System.Console.WriteLine($"Value 2 = {b.b}");
        }
    }
}
