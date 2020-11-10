namespace CSharpLearning
{
    public class AbstractExample : IDemonstrate
    {
        public void Demonstrate()
        {
            Animal cat = new Cat();
            Animal rabbit = new Rabbit();
            Animal dog = new Dog();

            System.Console.WriteLine(cat.Name);
            System.Console.WriteLine(rabbit.Name);
            System.Console.WriteLine(dog.Name);
        }
    }
}
