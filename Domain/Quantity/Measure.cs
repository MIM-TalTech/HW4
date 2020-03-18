﻿using HW4.Data;
using HW4.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

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
