namespace CSharpLearning
{
    public class DbCheckTaskExample
    {
        public static void Demonstrate()
        {
            CheckTask ct = new CheckTask();
            ct.Run(15);
            DbCheckTask db = new DbCheckTask();
            db.Run(5);
        }
    }
}
