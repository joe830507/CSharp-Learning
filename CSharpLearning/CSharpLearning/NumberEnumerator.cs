using System.Collections;
using System.Collections.Generic;

namespace CSharpLearning
{
    public class NumberEnumerator : IEnumerator<decimal>
    {
        decimal[] srcNumbers;
        int currentIndex;

        public NumberEnumerator(decimal[] source)
        {
            srcNumbers = source;
            currentIndex = -1;
        }
        public decimal Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (++currentIndex >= srcNumbers.Length)
            {
                Current = default;
                return false;
            }
            Current = srcNumbers[currentIndex];
            return true;
        }

        public void Reset()
        {
        }
    }
}
