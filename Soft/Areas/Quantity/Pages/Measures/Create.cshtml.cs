﻿
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Facade;
using Soft.Data;
using HW4.Domain.Quantity;
using HW4.Facade.Quantity;
using Pages;


namespace Soft
{
    public class CreateModel : MeasuresPage
    {
       public CreateModel(IMeasuresRepository r) : base(r) { }

     

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
