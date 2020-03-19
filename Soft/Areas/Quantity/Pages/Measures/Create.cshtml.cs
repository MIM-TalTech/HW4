
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HW4.Domain.Common;
using HW4.Domain.Quantity;
using Pages;


namespace Soft.Areas.Quantity.Pages.Measures
{
    public class CreateModel : MeasuresPage
    {
       public CreateModel(IMeasuresRepository r) : base(r) { }

     

        public IActionResult OnGet()
        {
            return Page();
        }

   

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!await addObject()) return Page();
            return RedirectToPage("./Index");
        }
    }
}
