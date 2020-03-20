using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HW4.Domain.Common;
using HW4.Domain.Quantity;
using HW4.Pages.Quantity;


namespace Soft.Areas.Quantity.Pages.Units
{
    public class CreateModel : UnitsPage
    {
       public CreateModel(IUnitsRepository r, IMeasuresRepository m) : base(r, m) { }




        public IActionResult OnGet(string fixedFilter, string fixedValue)
        {
            FixedValue = fixedValue;
            FixedFilter = fixedFilter;
            return Page();
        }




        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {

            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            if (!await addObject()) return Page();
            return RedirectToPage($"/Quantity/Units/Index?fixedFilter={FixedFilter}&fixedValue={FixedValue}");
        }
    }
}
