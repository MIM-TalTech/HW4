﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pages;
using HW4.Domain.Quantity;
using HW4.Facade.Quantity;

namespace Soft
{
    public class EditModel : MeasuresPage
    {
        public EditModel(IMeasuresRepository r) : base(r) { }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = MeasureViewFactory.Create(await data.Get(id));

            if (Item == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await data.Update(MeasureViewFactory.Create(Item));

            return RedirectToPage("./Index");
        }

      
    }
}
