namespace CSharpLearning
{
    class SelectableVariables
    {
        static void DoSomething(int p1, byte p2 =255,bool p3 = false)
        {
            System.Console.WriteLine($"p1:{p1},p2:{p2},p3:{p3}");
        }

        public static void Demonstrate()
        {
            DoSomething(10000, 123, true);
            DoSomething(22222, 244);
            DoSomething(2222);
        }
    }
}
