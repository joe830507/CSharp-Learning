namespace CSharpLearning
{
    public class NestClassExample : IDemonstrate
    {
        public void Demonstrate()
        {
            TheOut to = new TheOut();
            TheOut.TheNest tt = new TheOut.TheNest();
            to.NestObj = tt;
            to.CallNest();
        }
    }
}
