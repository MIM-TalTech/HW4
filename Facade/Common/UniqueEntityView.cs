using System.ComponentModel.DataAnnotations;

namespace Facade
{
    public abstract class UniqueEntityView : PeriodView
    {
        [Required]
        public string Id { get; set; }
    }
}