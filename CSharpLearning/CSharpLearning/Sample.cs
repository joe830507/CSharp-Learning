namespace CSharpLearning
{
    public class Sample
    {
        public void DoSomething<T>(T p) where T : struct => System.Console.WriteLine("{0} - {1}", p.GetType().Name, p);

        public T GetSomething<T>() where T : class, new() => new T();
    }
}
