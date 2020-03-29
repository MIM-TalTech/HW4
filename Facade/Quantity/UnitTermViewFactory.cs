using HW4.Aids;
using HW4.Data.Quantity;
using HW4.Domain.Quantity;

namespace HW4.Facade.Quantity
{
    public class UnitTermViewFactory
    {
        public static UnitTerm Create(UnitTermView view)
        {
            var d = new UnitTermData(); 
            Copy.Members(view, d);
            return new UnitTerm(d);
        }

        public static UnitTermView Create(UnitTerm obj)
        {
            var view = new UnitTermView();
            Copy.Members(obj.Data, view);
            return view;
        }
    }
}
