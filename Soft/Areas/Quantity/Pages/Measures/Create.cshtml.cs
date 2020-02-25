
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

   

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

          await data.Add(MeasureViewFactory.Create(Item));
            return RedirectToPage("./Index");
        }
    }
}
