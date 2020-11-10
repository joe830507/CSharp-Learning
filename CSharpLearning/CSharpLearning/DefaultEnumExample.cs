namespace CSharpLearning
{
    public class DefaultEnumExample : IDemonstrate
    {
        public void Demonstrate()
        {
            DefaultEnum y = DefaultEnum.ItemA;
            System.Console.WriteLine($"{y} = {(int)y}");
            y = DefaultEnum.ItemB;
            System.Console.WriteLine($"{y} = {(int)y}");
            y = DefaultEnum.ItemD;
            System.Console.WriteLine($"{y} = {(int)y}");
        }
    }
}
