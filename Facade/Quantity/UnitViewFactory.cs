using HW4.Aids;
using HW4.Data.Quantity;
using HW4.Domain.Quantity;

namespace HW4.Facade.Quantity
{
    public static class UnitViewFactory
    {
        public static Unit Create(UnitView v)
        {
            var d = new UnitData();
            Copy.Members(v, d);
            return new Unit(d);
        }
        public static UnitView Create(Unit o)
        {
            var v = new UnitView();
            if(!( o?.Data is null))
                Copy.Members(o.Data, v);
            
            return v;
        }
    }
}
