namespace CSharpLearning
{
    public class PlusOperator
    {
        public int Val1 { get; set; }
        public int Val2 { get; set; }

        public static int operator +(PlusOperator a, PlusOperator b)
        {
            return a.Val1 + b.Val1 + a.Val2 + b.Val2;
        }
    }
}
