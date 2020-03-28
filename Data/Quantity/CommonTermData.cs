using System;
using System.Collections.Generic;
using System.Text;
using HW4.Data.Common;

namespace HW4.Data.Quantity
{
    public abstract class CommonTermData : PeriodData
    {
        public string MasterId { get; set; }
        public string TermId { get; set; }
        public int Power { get; set; }

    }
}
