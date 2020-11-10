namespace CSharpLearning
{
    class DelegateExample
    {
        delegate double DoSomething(int x, double y);

        static double RunHere(int a,double b)
        {
            return a + b;
        }

        public static void Demonstrate()
        {
            DoSomething dele = new DoSomething(RunHere);
            DoSomething dele2 = RunHere;
            double res1 = dele(2, 2.55);
            double res2 = dele2(99, 9.25);
            System.Console.WriteLine($"res1:{res1},res2:{res2}");
        }
    }
}
