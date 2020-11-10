namespace CSharpLearning
{
    public class TestAnimalA<T> : IAnimalA<T> where T : AnimalA
    {
        public void DoWork(T pr)
        {
            pr.CheckIn();
        }
    }

}
