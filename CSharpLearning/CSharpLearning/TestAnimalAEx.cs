namespace CSharpLearning
{
    public class TestAnimalAEx : IDemonstrate
    {
        public void Demonstrate()
        {
            IAnimalA<AnimalA> t = new TestAnimalA<AnimalA>();
            t.DoWork(new Fox());
            t.DoWork(new Meerkat());
            t.DoWork(new Quail());
            t.DoWork(new Chicken());
        }
    }

}
