namespace CSharpLearning
{
    public class EnumExample : IDemonstrate
    {
        public void Demonstrate()
        {
            Options a = Options.OneWay;
            Options b = Options.TwoWay;
            Options c = Options.MixWay;
            System.Console.WriteLine($"{a},{(int)a}");
            System.Console.WriteLine($"{b},{(int)b}");
            System.Console.WriteLine($"{c},{(int)c}");
        }
    }
}
