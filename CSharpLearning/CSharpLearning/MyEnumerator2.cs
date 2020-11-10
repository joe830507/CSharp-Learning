using System.Collections;

namespace CSharpLearning
{
    public class MyEnumerator2 : IEnumerator
    {
        string[] _arr;
        int _currentIndex;
        public MyEnumerator2(string[] args)
        {
            _arr = args;
            _currentIndex = -1;
        }
        public object Current { get; private set; }

        public bool MoveNext()
        {
            if (++_currentIndex >= _arr.Length)
            {
                Current = null;
                return false;
            }
            Current = _arr[_currentIndex];
            return true;
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}
