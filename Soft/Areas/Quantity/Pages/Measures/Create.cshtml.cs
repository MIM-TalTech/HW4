
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HW4.Domain.Quantity;
using HW4.Pages.Quantity;



namespace Soft.Areas.Quantity.Pages.Measures
{
    public class CreateModel : MeasuresPage
    {
       public CreateModel(IMeasuresRepository r) : base(r) { }

     

        public IActionResult OnGet(string fixedFilter, string fixedValue)
        {
            FixedValue = fixedValue;
            FixedFilter = fixedFilter;
            return Page();
        }

   

        
        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {
            if (!await addObject(fixedFilter, fixedValue)) return Page();
            return RedirectToPage(IndexUrl);
        }
    }
}
