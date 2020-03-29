using HW4.Data.Quantity;
using HW4.Domain.Common;

namespace HW4.Domain.Quantity
{
    public sealed class UnitTerm : Entity<UnitTermData>
    {

        public UnitTerm() : this(null) { }

        public UnitTerm(UnitTermData data) : base(data) { }
    }
}
