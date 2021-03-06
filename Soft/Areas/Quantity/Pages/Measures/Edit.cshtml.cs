﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HW4.Domain.Quantity;
using HW4.Pages.Quantity;

namespace Soft.Areas.Quantity.Pages.Measures
{
    public class EditModel : MeasuresPage
    {
        public EditModel(IMeasuresRepository r) : base(r) { }
        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            
            await getObject(id, fixedFilter, fixedValue);
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {
          
            await updateObject(fixedFilter, fixedValue);
          
            return RedirectToPage(IndexUrl);
        }

      
    }
}
