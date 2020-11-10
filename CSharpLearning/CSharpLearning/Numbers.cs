using System.Collections;
using System.Collections.Generic;

namespace CSharpLearning
{
    public class Numbers : IEnumerable<decimal>
    {
        decimal[] numberarr = { 7.33M, 16.12M, 800.56M, 1202.633M, 170.9M };
        public IEnumerator<decimal> GetEnumerator()
        {
            return new NumberEnumerator(numberarr);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
