using System;
using System.Collections.Generic;
using System.Text;
using HW4.Data.Quantity;
using HW4.Domain.Common;

namespace HW4.Domain.Quantity
{
    public sealed class MeasureTerm : Entity<MeasureTermData>
    {
        public MeasureTerm() : this(null)
        {
        }


        public MeasureTerm(MeasureTermData data) : base(data) { }

    }
}
