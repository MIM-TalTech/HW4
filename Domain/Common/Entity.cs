using HW4.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW4.Domain.Quantity
{
    public abstract class Entity<T> where T : PeriodData
    {
        public T Data { get; internal set; }
        protected Entity(T data)
        {
            Data = data;
        }
    }
}
