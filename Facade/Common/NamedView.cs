using System.ComponentModel.DataAnnotations;

namespace HW4.Facade.Common
{
    public abstract class NamedView : UniqueEntityView
    {
        [Required]
        public string Name { get; set; }

        public string Code { get; set; }

        
       
       
 
    }
}