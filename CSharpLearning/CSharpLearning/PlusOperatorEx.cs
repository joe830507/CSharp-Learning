namespace CSharpLearning
{
    public class PlusOperatorEx : IDemonstrate
    {
        public void Demonstrate()
        {
            PlusOperator p1 = new PlusOperator { Val1 = 4, Val2 = 9 };
            PlusOperator p2 = new PlusOperator { Val1 = 3, Val2 = 1 };
            System.Console.WriteLine($"Total:{p1 + p2}");
        }
    }
}
