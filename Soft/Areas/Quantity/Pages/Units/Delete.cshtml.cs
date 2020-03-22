﻿
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HW4.Domain.Common;
using HW4.Domain.Quantity;
using HW4.Pages.Quantity;

namespace Soft.Areas.Quantity.Pages.Units
{
    public class DeleteModel : UnitsPage
    {
        public DeleteModel(IUnitsRepository r, IMeasuresRepository m) : base(r, m) { }
        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
           
            await getObject(id, fixedFilter, fixedValue);
            return Page();


        }
        public async Task<IActionResult> OnPostAsync(string id, string fixedFilter, string fixedValue)
        {
           
            await deleteObject(id, fixedFilter, fixedValue);
            return RedirectToPage(IndexUrl);
        }
    }
}
