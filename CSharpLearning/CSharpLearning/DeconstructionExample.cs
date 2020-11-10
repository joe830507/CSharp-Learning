namespace CSharpLearning
{
    class DeconstructionExample : IDemonstrate
    {
        public DeconstructionExample()
        {
            System.Console.WriteLine("DeconstructionExample is called.");
        }

        ~DeconstructionExample()
        {
            System.Console.WriteLine("DeconstructionExample is dropped.");
        }

        public void Demonstrate()
        {
            System.Console.WriteLine("Nothing.");
        }
    }
}
