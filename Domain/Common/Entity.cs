using HW4.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW4.Domain.Quantity
{
    public abstract class Entity<TData> where TData : PeriodData, new()
    {
    
        protected internal Entity(TData d = null) => Data = d ?? new TData();
        public TData Data { get; internal set; }
    }
}
