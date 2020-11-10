namespace CSharpLearning
{
    public class DbCheckTask : CheckTask
    {
        public new void Run(int count)
        {
            System.Console.WriteLine($"parallel task:{count}");
        }
    }
}
