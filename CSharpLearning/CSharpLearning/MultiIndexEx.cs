namespace CSharpLearning
{
    public class MultiIndexEx : IDemonstrate
    {
        public void Demonstrate()
        {
            MultiIndex mi = new MultiIndex();
            long r = mi[800, 20000];
            System.Console.WriteLine(r);
        }
    }
}
