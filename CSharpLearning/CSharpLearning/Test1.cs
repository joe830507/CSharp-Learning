namespace CSharpLearning
{
    class Test1
    {
        private int _local;

        public Test1(int init)
        {
            _local = init;
        }

        public void DisplayValue()
        {
            System.Console.WriteLine($"Current value:{_local}");
        }

        public int Value => _local;
    }
}
