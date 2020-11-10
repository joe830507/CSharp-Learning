namespace CSharpLearning
{
    public class ReturnValueAttrEx : IDemonstrate
    {
        
        public void Demonstrate()
        {
            SaySomething();
        }

        [return: ReturnValue]
        string SaySomething() => "Hello";
    }
}
