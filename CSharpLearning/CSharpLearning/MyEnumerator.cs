using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpLearning
{
    public class MyEnumerator : IEnumerator<int>
    {
        Random random = null;
        int count;
        public int Current { get; private set; }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public MyEnumerator()
        {
            random = new Random();
            count = 0;
            Current = default(int);
        }

        public void Dispose()
        {
            random = null;
        }

        public bool MoveNext()
        {
            if (++count > 10)
                return false;
            Current = random.Next();
            return true;
        }

        public void Reset()
        {
            count = 0;
            Current = default(int);
        }
    }
}
