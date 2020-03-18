using HW4.Data.Quantity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW4.Domain.Quantity
{
    public sealed class Unit:Entity<UnitData>
    {
        public Unit() : this(null){}
        public Unit(UnitData d) : base(d) { }
    }
}
