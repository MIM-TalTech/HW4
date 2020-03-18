
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Facade;
using Soft.Data;
using HW4.Domain.Quantity;
using HW4.Facade.Quantity;
using HW4.Pages.Quantity;


namespace Soft.Areas.Quantity.Pages.Units
{
    public class CreateModel : UnitsPage
    {
       public CreateModel(IUnitsRepository r, IMeasuresRepository m) : base(r, m) { }
      


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
