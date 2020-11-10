namespace CSharpLearning
{
    public class TestEx : IDemonstrate
    {
        public void Demonstrate()
        {
            Test<int> test1 = new Test<int>();
            test1.Start(100);
            Test<byte> test2 = new Test<byte>();
            test2.Start(100);
        }
    }
}
