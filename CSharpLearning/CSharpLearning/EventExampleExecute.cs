namespace CSharpLearning
{
    class EventExampleExecute
    {
        private int c = 0;

        public delegate void DemoEventDelegate(object obj, int count);

        DemoEventDelegate _myEvent;

        public event DemoEventDelegate Worked { 
            add 
            {
                if(value != null)
                {
                    _myEvent += value;
                }
            }
            remove
            {
                _myEvent -= value;
            }
        }

        public void Run()
        {
            _myEvent?.Invoke(this, ++c);
        }

        public static void Demonstrate()
        {
            EventExampleExecute e = new EventExampleExecute();
            e.Worked += (k, f) => System.Console.WriteLine($"You have called this method {f} times.");
            e.Run();
            e.Run();
            e.Run();
            e.Run();
        }
    }
}
