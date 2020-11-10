namespace CSharpLearning
{
    public partial class Program
    {
        public class SelfDefinitionConversionEx : IDemonstrate
        {
            public void Demonstrate()
            {
                RectArea ra = new RectArea(12, 15);
                int v = ra;
                System.Console.WriteLine(v);
            }
        }
    }
}
