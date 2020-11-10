using System.Dynamic;
using System.Linq;

namespace CSharpLearning
{

    public partial class ExpandoObjectEx
    {
        public class MyCustDynamic : DynamicObject
        {
            public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
            {
                result = 0;
                int temp = 0;
                foreach (var n in args.Cast<int>())
                {
                    temp += n;
                }
                result = temp;
                return true;
            }
        }
    }
}
