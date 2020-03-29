
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HW4.Domain.Quantity;
using HW4.Pages.Quantity;

namespace Soft.Areas.Quantity.Pages.Measures
{
    public class DetailsModel : MeasuresPage
    {
       public DetailsModel(IMeasuresRepository r) : base(r) { }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
         
            await getObject(id, fixedFilter, fixedValue);
            return Page();
        }
    }
}
