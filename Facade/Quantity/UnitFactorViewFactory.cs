using HW4.Aids;
using HW4.Data.Quantity;
using HW4.Domain.Quantity;

namespace HW4.Facade.Quantity
{
   public static class UnitFactorViewFactory
    {
        public static UnitFactor Create(UnitFactorView view)
        {
           var d = new UnitFactorData();
           Copy.Members(view, d);
           return new UnitFactor(d);
        }
        public static UnitFactorView Create(UnitFactor obj)
        {
            var view = new UnitFactorView();
            Copy.Members(obj.Data, view);
            return view;
        }
    }
}
