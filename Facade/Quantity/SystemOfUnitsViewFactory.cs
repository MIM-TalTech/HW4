using HW4.Aids;
using HW4.Data.Quantity;
using HW4.Domain.Quantity;

namespace HW4.Facade.Quantity
{
    public static class SystemOfUnitsViewFactory
    {
        public static SystemOfUnits Create(SystemOfUnitsView view)
        {
           var d = new SystemOfUnitsData();
           Copy.Members(view, d);
           return new SystemOfUnits(d);
        }

        public static SystemOfUnitsView Create(SystemOfUnits obj)
        {
            var view = new SystemOfUnitsView();
            Copy.Members(obj.Data, view);
            return view;
        }
    }
}
