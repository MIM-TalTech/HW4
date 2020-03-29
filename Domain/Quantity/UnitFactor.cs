using HW4.Data.Quantity;
using HW4.Domain.Common;

namespace HW4.Domain.Quantity
{
    public sealed class UnitFactor : Entity<UnitFactorData>
    {

        public UnitFactor() : this(null) { }

        public UnitFactor(UnitFactorData data) : base(data) { }
    }
}
