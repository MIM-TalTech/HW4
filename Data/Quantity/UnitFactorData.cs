using HW4.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW4.Data.Quantity
{
   public class UnitFactorData : PeriodData
    {
        public string UnitId { get; set; }
        public string SystemOfUnitsId { get; set; }
        public double Factor { get; set; }
    }
}
