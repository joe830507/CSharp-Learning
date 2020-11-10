namespace CSharpLearning
{
    public class EnumerableEx : IDemonstrate
    {
        public void Demonstrate()
        {
            Numbers nb = new Numbers();
            foreach (var item in nb)
            {
                System.Console.WriteLine(" {0:G}", item);
            }
        }
    }
}
