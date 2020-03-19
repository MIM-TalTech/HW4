using HW4.Data;
using HW4.Data.Quantity;
using HW4.Domain.Common;

namespace HW4.Domain.Quantity
{
    public sealed class Measure : Entity<MeasureData>
    {
        public Measure() : this(null)
        {

        }
        public Measure(MeasureData data) : base(data)
        {

        }
    }

    
    
}
