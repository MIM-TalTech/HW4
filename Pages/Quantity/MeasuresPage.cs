using Facade;
using HW4.Domain.Quantity;
using HW4.Facade.Quantity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pages
{
    public abstract class MeasuresPage : PageModel
    {
       internal protected readonly IMeasuresRepository data;

        protected internal MeasuresPage(IMeasuresRepository r)
        {
            data = r;
            PageTitle = "Measures";
        }

        [BindProperty]
        public MeasureView Item { get; set; }
        public IList<MeasureView> Items { get; set; }
        public string PageTitle { get; set; }
        public string PageSubTitle { get; set; } = "Mingi pealkiri";
        public string CurrentSort { get; set; } = "Current Sort";
        public string CurrentFilter { get; set; } = "Current Filter";
        public int PageIndex { get; set; } = 3;
        public int TotalPages { get; set; } = 10;
        public string ItemId => Item.Id;
        protected internal async Task<bool> addObject()
        {
            // TODO
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.
            try
            {
                if (!ModelState.IsValid)
            {
                return false;
            }

             await data.Add(MeasureViewFactory.Create(Item)); 
            }
            catch
            {
                return false;
            }
            return true;
        }
        protected internal async Task updateObject()
        {
            // TODO
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.
            await data.Update(MeasureViewFactory.Create(Item));

        }
        protected internal async Task getObject(string id)
        {

            var o = await data.Get(id);
            Item = MeasureViewFactory.Create(o);

           
        }

        protected internal async Task deleteObject(string id)
        {
            await data.Delete(id);
        }
    }


    
}

