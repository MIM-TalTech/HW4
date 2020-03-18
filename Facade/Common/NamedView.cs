using System.ComponentModel.DataAnnotations;

namespace Facade
{
    public abstract class NamedView : UniqueEntityView
    {
        [Required]
        public string Name { get; set; }

        public string Code { get; set; }

        
       
       
 
    }
}