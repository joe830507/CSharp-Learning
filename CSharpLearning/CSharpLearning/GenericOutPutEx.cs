namespace CSharpLearning
{
    public class GenericOutPutEx : IDemonstrate
    {
        public void Demonstrate()
        {
            ITest1<FootBall> t1 = new Test1<Ball>();
            ITest2<Ball> t2 = new Test2<FootBall>();
        }
    }
}
