using Facade;
using HW4.Data;
using HW4.Domain.Quantity;
using System;
using System.Collections.Generic;
using System.Text;
using HW4.Aids;

namespace HW4.Facade.Quantity
{
    public static class MeasureViewFactory
    {
        public static Measure Create(MeasureView v)
        {
            var o = new Measure();
            Copy.Members(v, o.Data);

            return o;
        }
        public static MeasureView Create(Measure o)
        {
            var v = new MeasureView();
            Copy.Members(o.Data, v);
            
            return v;
        }
    }
}

