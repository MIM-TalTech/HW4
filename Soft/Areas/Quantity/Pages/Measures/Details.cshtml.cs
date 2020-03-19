
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pages;
using HW4.Domain.Common;
using HW4.Domain.Quantity;

namespace Soft.Areas.Quantity.Pages.Measures
{
    public class DetailsModel : MeasuresPage
    {
       public DetailsModel(IMeasuresRepository r) : base(r) { }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            await getObject(id);
            return Page();
        }
    }
}
