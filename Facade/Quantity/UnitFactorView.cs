using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HW4.Facade.Common;

namespace HW4.Facade.Quantity
{
    public sealed class UnitFactorView : PeriodView
    {

        [Required]
        [DisplayName("Unit")]
        public string UnitId { get; set; }
        [DisplayName("System of Units")]
        public string SystemOfUnitsId { get; set; }
        public double Factor { get; set; }
    }
}
