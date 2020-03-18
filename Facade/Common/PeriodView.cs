using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Facade
{
    public abstract class PeriodView
    {
        [DataType(DataType.Date)]
        [DisplayName("Valid From")]
        public DateTime? ValidFrom { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Valid To")]
        public DateTime? ValidTo { get; set; }
    }
}