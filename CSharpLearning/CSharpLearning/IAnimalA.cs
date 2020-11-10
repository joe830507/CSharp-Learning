namespace CSharpLearning
{
    public interface IAnimalA<in T>
    {
        void DoWork(T pr);
    }

}
