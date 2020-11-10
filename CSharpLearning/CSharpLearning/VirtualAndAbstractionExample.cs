namespace CSharpLearning
{
    public class VirtualAndAbstractionExample : VirtualAndAbstraction
    {
        public override void Output()
        {
            System.Console.WriteLine("Subclass is called.");
            base.Output();
        }

    }
}
