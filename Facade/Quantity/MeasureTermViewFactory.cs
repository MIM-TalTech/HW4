using HW4.Aids;
using HW4.Data.Quantity;
using HW4.Domain.Quantity;

namespace HW4.Facade.Quantity
{
    public static class MeasureTermViewFactory
    {
        public static object Create(MeasureTermView view)
        {
            var d = new MeasureTermData();
            Copy.Members(view, d);
            return new MeasureTerm(d);
        }


        public static MeasureTermView Create(MeasureTerm obj)
        {
           var v = new MeasureTermView();
           Copy.Members(obj.Data, v);
           return v;
        }
    }
}
