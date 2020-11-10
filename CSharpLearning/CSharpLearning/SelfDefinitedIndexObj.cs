namespace CSharpLearning
{
    public class SelfDefinitedIndexObj
    {
        private byte[] _data = new byte[10];

        public byte this[int index]
        {
            get
            {
                if (index < 0 || index >= _data.Length)
                    return 0;
                return _data[index];
            }
            set
            {
                if (index >= 0 || index < _data.Length)
                    _data[index] = value;
            }
        }

        public void PrintAll()
        {
            string msg = string.Join(",", _data);
            System.Console.WriteLine(msg);
        }
    }
}
