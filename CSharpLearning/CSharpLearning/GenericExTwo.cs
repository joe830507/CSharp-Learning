namespace CSharpLearning
{
    public class GenericExTwo : IGenericEx<int, double>, IDemonstrate
    {
        public void Demonstrate()
        {
            Output(2, 23982.22212d);
        }

        public void Output(int p, double q)
        {
            System.Console.WriteLine("{0} - {1}", p.GetType(), p);
            System.Console.WriteLine("{0} - {1}", q.GetType(), q);
        }
    }
}
