namespace CSharpLearning
{
    public class SampleEx : IDemonstrate
    {
        public void Demonstrate()
        {
            Sample s = new Sample();
            s.DoSomething('z');
            s.DoSomething((byte)5);
            s.DoSomething(6.3333d);
            s.DoSomething(777);

            GenericA xa = s.GetSomething<GenericA>();
            GenericB xb = s.GetSomething<GenericB>();
        }
    }
}
