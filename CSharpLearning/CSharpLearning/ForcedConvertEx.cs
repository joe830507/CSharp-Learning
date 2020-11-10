namespace CSharpLearning
{
    public class ForcedConvertEx : IDemonstrate
    {
        public void Demonstrate()
        {
            double a = 5.1235d;
            int b = (int)a;
            System.Console.WriteLine($"{a,-15}{b,-15}");
            double c = 12.23125d;
            int d = (int)c;
            System.Console.WriteLine($"{c,-15}{d,-15}");
        }
    }
}
