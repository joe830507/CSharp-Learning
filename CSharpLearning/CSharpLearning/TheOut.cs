namespace CSharpLearning
{
    public class TheOut
    {
        public TheNest NestObj { get; set; }

        public void CallNest()
        {
            NestObj?.CallMe();
        }
        public class TheNest
        {
            public void CallMe() => System.Console.WriteLine("Accessing the instance of nest structure.");
        }
    }

}
