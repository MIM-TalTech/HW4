using HW4.Data.Quantity;
using HW4.Domain.Common;

namespace HW4.Domain.Quantity
{
    public sealed class SystemOfUnits : Entity<SystemOfUnitsData>

    {

        public SystemOfUnits() : this(null) { }

        public SystemOfUnits(SystemOfUnitsData data) : base(data) { }
    }
}
