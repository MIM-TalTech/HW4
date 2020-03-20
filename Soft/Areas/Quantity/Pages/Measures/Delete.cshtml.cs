
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pages;
using HW4.Domain.Common;
using HW4.Domain.Quantity;

namespace Soft.Areas.Quantity.Pages
{
    public class DeleteModel : MeasuresPage
    {
        public DeleteModel(IMeasuresRepository r) : base(r) { }
        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            await getObject(id);
            return Page();

           
        }
        public async Task<IActionResult> OnPostAsync(string id, string fixedFilter, string fixedValue)
        {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            await deleteObject(id);
            return RedirectToPage($"/Quantity/Measures/Index?fixedFilter={FixedFilter}&fixedValue={FixedValue}");
        }
    }
}
