namespace CSharpLearning
{
    public class OneWork : IRunner1, IRunner2
    {
        public void EndWork()
        {
            System.Console.WriteLine("end operation.");
        }

        public void StartWork()
        {
            System.Console.WriteLine("start operation.");
        }
    }
}
