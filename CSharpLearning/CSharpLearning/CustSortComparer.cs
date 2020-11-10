using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CSharpLearning
{
    public class CustSortComparer : Comparer<string>
    {
        public override int Compare([AllowNull] string x, [AllowNull] string y)
        {
            return x.Length - y.Length;
        }
    }
}
