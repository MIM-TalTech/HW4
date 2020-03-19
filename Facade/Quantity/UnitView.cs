
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HW4.Facade.Common;

namespace HW4.Facade.Quantity
{
    public sealed class UnitView : DefinedView
    {
        [Required]
        [DisplayName("Measure")]
        public string MeasureId { get; set; }
    }
}
