using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CSharpLearning
{
    public class MyComparer : Comparer<int>
    {
        public override int Compare([AllowNull] int x, [AllowNull] int y)
        {
            return -(x - y);
        }
    }
}
