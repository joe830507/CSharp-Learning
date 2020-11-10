using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CSharpLearning
{
    public sealed class ContactEqualityComparer : EqualityComparer<Contact>
    {
        public override bool Equals([AllowNull] Contact x, [AllowNull] Contact y)
        {
            if (x == null || y == null)
                return false;
            if (object.ReferenceEquals(x, y))
                return true;
            if (x.ID == y.ID && x.Name == y.Name && x.PhoneNo == y.PhoneNo)
                return true;
            return false;
        }

        public override int GetHashCode([DisallowNull] Contact obj)
        {
            return obj.ID.GetHashCode() ^ obj.Name.GetHashCode() ^ obj.PhoneNo.GetHashCode();
        }
    }
}
