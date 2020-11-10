namespace CSharpLearning
{
    class Test2
    {
        private int _local;

        public Test2(int init)
        {
            _local = init;
        }

        public void DisplayValue()
        {
            System.Console.WriteLine($"Current value:{_local}");
        }

        public ref int Value => ref _local;
    }
}
