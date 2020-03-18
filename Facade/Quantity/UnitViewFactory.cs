using HW4.Data.Quantity;
using HW4.Domain.Quantity;
using System;
using System.Collections.Generic;
using System.Text;
using HW4.Aids;

namespace HW4.Facade.Quantity
{
    public static class UnitViewFactory
    {
        public static Unit Create(UnitView v)
        {
            var o = new Unit();
            Copy.Members(v, o.Data);
            return o;
        }
        public static UnitView Create(Unit o)
        {
            var v = new UnitView();
            Copy.Members(o.Data, v);
            
            return v;
        }
    }
}
