namespace CSharpLearning
{
    public class SelfDefinitedIndexObjEx : IDemonstrate
    {
        public void Demonstrate()
        {
            SelfDefinitedIndexObj obj = new SelfDefinitedIndexObj();
            obj[0] = 209;
            obj[1] = 39;
            obj[5] = 122;
            obj[9] = 60;
            obj.PrintAll();
        }
    }
}
