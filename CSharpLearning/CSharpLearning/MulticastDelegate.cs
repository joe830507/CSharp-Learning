namespace CSharpLearning
{
    class MulticastDelegate
    {
        delegate void MyFunction();

        static void Output1()
        {
            System.Console.WriteLine("First Function");
        }

        static void Output2()
        {
            System.Console.WriteLine("Second Function");
        }

        public static void Demonstrate()
        {
            MyFunction del = null;
            del += Output1;
            del += Output2;
            del();
        }
    }
}
