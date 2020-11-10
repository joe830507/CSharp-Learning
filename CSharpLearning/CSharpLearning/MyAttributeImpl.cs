namespace CSharpLearning
{
    public class MyAttributeImpl
    {
        [My(StartChar = 'k', MaxLen = 7)]
        public string RawName { get; set; }
    }
}
