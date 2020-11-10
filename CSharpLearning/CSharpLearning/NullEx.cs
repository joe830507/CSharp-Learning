namespace CSharpLearning
{
    public class NullEx : IDemonstrate
    {
        public void Demonstrate()
        {
            NullObj obj = new NullObj();
            obj?.Work();
            System.Console.WriteLine(obj?.Num);
            obj = null;
            obj?.Work();
            System.Console.WriteLine(obj?.Num);
        }
    }
}
