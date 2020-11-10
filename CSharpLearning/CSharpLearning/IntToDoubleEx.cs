namespace CSharpLearning
{
    public class IntToDoubleEx : IDemonstrate
    {
        public void Demonstrate()
        {
            int a = 22, b = 66, c = 129;
            double x = a, y = b, z = c;
            System.Console.WriteLine($"{x,-15:0.000},{y,-15:0.000},{z,-15:0.000}");
        }
    }
}
