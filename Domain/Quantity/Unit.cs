using HW4.Data.Quantity;
using HW4.Domain.Common;

namespace HW4.Domain.Quantity
{
    public sealed class Unit:Entity<UnitData>
    {
        public Unit() : this(null){}
        public Unit(UnitData d) : base(d) { }
    }
}
