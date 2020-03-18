﻿
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pages;
using HW4.Domain.Quantity;
using HW4.Pages.Quantity;

namespace Soft.Areas.Quantity.Pages.Units
{
    public class DeleteModel : UnitsPage
    {
        public DeleteModel(IUnitsRepository r, IMeasuresRepository m) : base(r, m) { }
        public async Task<IActionResult> OnGetAsync(string id)
        {

            await getObject(id);
            return Page();

           
        }
        public async Task<IActionResult> OnPostAsync(string id)
        {

            await deleteObject(id);
            return RedirectToPage("./Index");
        }
    }
}